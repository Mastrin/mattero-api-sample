using AutoMapper;
using Integration.Sample.ApiServer.Common.Models;
using Integration.Sample.ApiServer.Matters;
using Integration.Sample.ApiServer.Matters.Item;
using Integration.Sample.ApiServer.Matters.List;
using Integration.Sample.Controllers.Base;
using Integration.Sample.Extensions;
using Integration.Sample.Models.Common;
using Integration.Sample.Models.Matters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Integration.Sample.Controllers
{
	[Route("matters")]
	[AllowAnonymous]
	public class MattersController :
		ApiServerControllerBase<MatterListRequest, MatterListItem, MattersModel>
	{
		private readonly IMattersService _mattersService;

		public MattersController(IMattersService mattersService)
			: base(mattersService)
			=> _mattersService = mattersService;

		[HttpGet]
		public Task<IActionResult> IndexAsync([FromQuery] SearchModel model)
			=> GetListActionResultAsync(model);

		[HttpGet("create")]
		public IActionResult Create()
			=> View("CreateUpdate", new CreateUpdateMatterModel());

		[HttpPost("create")]
		public async Task<IActionResult> CreateAsync([FromForm] CreateUpdateMatterModel model)
		{
			if (model == null)
				return View("CreateUpdate", new CreateUpdateMatterModel());

			if (ModelState.IsValid)
			{
				var request = Mapper.Map<MatterCreateUpdateRequest>(model);
				var result = await this._mattersService.CreateMatterAsync(request);

				if (result.IsSuccessful)
				{
					this.AddSuccessAlert("Successfuly added matter");
					return RedirectToAction(nameof(IndexAsync).FormatActionName());
				}

				this.AddErrorAlert("Failed to add matter");
			}

			return View("CreateUpdate", model);
		}

		[HttpGet("{id}/update")]
		public async Task<IActionResult> UpdateAsync([FromRoute] string id)
		{
			var result = await _mattersService.GetItemAsync(id);

			if (result.IsSuccessful)
			{
				var model = Mapper.Map<UpdateMatterModel>(result.Response);
				model.Id = id;

				return View("CreateUpdate", model);
			}

			this.AddErrorAlert("Failed to get data");
			return View("CreateUpdate", new UpdateMatterModel { Id = id });
		}

		[HttpPost("{id}/update")]
		public async Task<IActionResult> UpdateAsync([FromRoute] string id, [FromForm] CreateUpdateMatterModel model)
		{
			if (model == null)
				return View("CreateUpdate", new UpdateMatterModel { Id = id });

			if (ModelState.IsValid)
			{
				var request = Mapper.Map<MatterCreateUpdateRequest>(model);
				var result = await this._mattersService.UpdateMatterAsync(id, request);

				if (result.IsSuccessful)
				{
					this.AddSuccessAlert("Successfuly updated matter");
					return RedirectToAction(nameof(IndexAsync).FormatActionName());
				}

				this.AddErrorAlert("Failed to update matter");
			}

			var returnModel = Mapper.Map<UpdateMatterModel>(model);
			returnModel.Id = id;
			return View("CreateUpdate", returnModel);
		}

		protected override void SetUpdateLink(IEditLinkModel model)
			=> model.EditLink = $"/matters/{model.Id}/update";

		protected override void ConfigureMapper(IMapperConfigurationExpression options)
		{
			options
				.CreateMap<SearchModel, MatterListRequest>()
				.ForMember(newDto => newDto.PageIndex, config =>
				{
					config.MapFrom(oldDto => oldDto.Page);
					config.AddTransform(member => member.HasValue ? member.Value - 1 : 0);
				});

			options
				.CreateMap<ListResponse<MatterListItem>, SearchResponseModel<MattersModel>>()
				.ForMember(newDto => newDto.Items, config => config.MapFrom(oldDto => oldDto.Records))
				.ForMember(newDto => newDto.Page, config =>
				{
					config.MapFrom(oldDto => oldDto.PageIndex);
					config.AddTransform(member => member + 1);
				});

			options
				.CreateMap<MatterListItem, MattersModel>()
				.ForMember(newDto => newDto.ClientName, config => config.MapFrom(oldDto => oldDto.Client.Name))
				.ForMember(newDto => newDto.OpenDate, config => config.MapFrom(oldDto => oldDto.DateOpen))
				.ForMember(newDto => newDto.LastChanged, config => config.MapFrom(oldDto => oldDto.LastActivity));

			options
				.CreateMap<MatterViewItem, UpdateMatterModel>()
				.ForMember(newDto => newDto.StageId, config => config.MapFrom(oldDto => oldDto.PracticeAreaStageId))
				.ForMember(newDto => newDto.ReferredById, config => config.MapFrom(oldDto => oldDto.ReferredBy.Id))
				.ForMember(newDto => newDto.CostTemplateId, config => config.MapFrom(oldDto => oldDto.CostTemplate));

			options
				.CreateMap<CreateUpdateMatterModel, MatterCreateUpdateRequest>();

			options
				.CreateMap<CreateUpdateMatterModel, UpdateMatterModel>();
		}
	}
}