using AutoMapper;
using Integration.Sample.ApiServer.Common.Models;
using Integration.Sample.ApiServer.Tasks;
using Integration.Sample.ApiServer.Tasks.Item;
using Integration.Sample.ApiServer.Tasks.List;
using Integration.Sample.Controllers.Base;
using Integration.Sample.Extensions;
using Integration.Sample.Models.Common;
using Integration.Sample.Models.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Integration.Sample.Controllers
{
	[Route("tasks")]
	[AllowAnonymous]
	public class TasksController :
		ApiServerControllerBase<TaskListRequest, TaskListItem, TasksModel>
	{
		private readonly ITasksService _tasksService;

		public TasksController(ITasksService tasksService)
			: base(tasksService)
			=> _tasksService = tasksService;

		[HttpGet]
		public Task<IActionResult> IndexAsync([FromQuery] SearchModel model)
			=> GetListActionResultAsync(model);

		[HttpGet("create")]
		public IActionResult Create()
			=> View("CreateUpdate", new CreateUpdateTaskModel());

		[HttpPost("create")]
		public async Task<IActionResult> CreateAsync([FromForm] CreateUpdateTaskModel model)
		{
			if (model == null)
				return View("CreateUpdate", new CreateUpdateTaskModel());

			if (ModelState.IsValid)
			{
				var request = Mapper.Map<TaskCreateUpdateRequest>(model);
				var result = await this._tasksService.CreateTaskAsync(request);

				if (result.IsSuccessful)
				{
					this.AddSuccessAlert("Successfuly added task");
					return RedirectToAction(nameof(IndexAsync).FormatActionName());
				}

				this.AddErrorAlert("Failed to add task");
			}

			return View("CreateUpdate", model);
		}

		[HttpGet("{id}/update")]
		public async Task<IActionResult> UpdateAsync([FromRoute] string id)
		{
			var result = await _tasksService.GetItemAsync(id);

			if (result.IsSuccessful)
			{
				var model = Mapper.Map<UpdateTaskModel>(result.Response);
				model.IsContact = !string.IsNullOrWhiteSpace(model.AssociatedContactId);
				model.Id = id;

				return View("CreateUpdate", model);
			}

			this.AddErrorAlert("Failed to get data");
			return View("CreateUpdate", new UpdateTaskModel { Id = id });
		}

		[HttpPost("{id}/update")]
		public async Task<IActionResult> UpdateAsync([FromRoute] string id, [FromForm] CreateUpdateTaskModel model)
		{
			if (model == null)
				return View("CreateUpdate", new UpdateTaskModel { Id = id });

			if (ModelState.IsValid)
			{
				var request = Mapper.Map<TaskCreateUpdateRequest>(model);
				var result = await this._tasksService.UpdateTaskAsync(id, request);

				if (result.IsSuccessful)
				{
					this.AddSuccessAlert("Successfuly updated task");
					return RedirectToAction(nameof(IndexAsync).FormatActionName());
				}

				this.AddErrorAlert("Failed to update task");
			}

			var returnModel = Mapper.Map<UpdateTaskModel>(model);
			returnModel.Id = id;
			return View("CreateUpdate", returnModel);
		}

		protected override void SetUpdateLink(IEditLinkModel model)
			=> model.EditLink = $"/tasks/{model.Id}/update";

		protected override void ConfigureMapper(IMapperConfigurationExpression options)
		{
			options
				.CreateMap<SearchModel, TaskListRequest>()
				.ForMember(newDto => newDto.PageIndex, config =>
				{
					config.MapFrom(oldDto => oldDto.Page);
					config.AddTransform(member => member.HasValue ? member.Value - 1 : 0);
				});

			options
				.CreateMap<ListResponse<TaskListItem>, SearchResponseModel<TasksModel>>()
				.ForMember(newDto => newDto.Items, config => config.MapFrom(oldDto => oldDto.Records))
				.ForMember(newDto => newDto.Page, config =>
				{
					config.MapFrom(oldDto => oldDto.PageIndex);
					config.AddTransform(member => member + 1);
				});

			options
				.CreateMap<TaskListItem, TasksModel>()
				.ForMember
				(
					newDto => newDto.RelatedToName,
					config => config.MapFrom
					(
						oldDto => oldDto.AssociatedContact != null
							? oldDto.AssociatedContact.Name
							: oldDto.AssociatedMatter != null
								? oldDto.AssociatedMatter.Name
								: null
					)
				)
				.ForMember(newDto => newDto.AssignedToName, config => config.MapFrom(oldDto => oldDto.AssignedTo.Name));

			options
				.CreateMap<TaskViewItem, UpdateTaskModel>();

			options
				.CreateMap<CreateUpdateTaskModel, TaskCreateUpdateRequest>();

			options
				.CreateMap<CreateUpdateTaskModel, UpdateTaskModel>();
		}
	}
}