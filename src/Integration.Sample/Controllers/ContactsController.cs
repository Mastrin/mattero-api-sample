using AutoMapper;
using Integration.Sample.ApiServer.Common.Models;
using Integration.Sample.ApiServer.Contacts;
using Integration.Sample.ApiServer.Contacts.Common;
using Integration.Sample.ApiServer.Contacts.Item;
using Integration.Sample.ApiServer.Contacts.List;
using Integration.Sample.ApiServer.Contacts.Lookup;
using Integration.Sample.Controllers.Base;
using Integration.Sample.Extensions;
using Integration.Sample.Models.Common;
using Integration.Sample.Models.Contacts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Integration.Sample.Controllers
{
	[Route("contacts")]
	[AllowAnonymous]
	public class ContactsController :
		ApiServerControllerBase<ContactListRequest, ContactListItem, ContactsModel>
	{
		private readonly IContactsService _contactsService;

		public ContactsController(IContactsService contactsService)
			: base(contactsService)
			=> _contactsService = contactsService;

		[HttpGet]
		public Task<IActionResult> IndexAsync([FromQuery] SearchModel model)
			=> GetListActionResultAsync(model);

		[HttpGet("create/person")]
		public IActionResult CreatePerson()
			=> View("CreateUpdatePerson", new CreateUpdatePersonContactModel());

		[HttpPost("create/person")]
		public async Task<IActionResult> CreatePersonAsync([FromForm] CreateUpdatePersonContactModel model)
		{
			if (model == null)
				return View("CreateUpdatePerson", new CreateUpdatePersonContactModel());

			if (ModelState.IsValid)
			{
				var request = Mapper.Map<PersonContactCreateUpdateRequest>(model);
				var result = await this._contactsService.CreatePersonContactAsync(request);

				if (result.IsSuccessful)
				{
					this.AddSuccessAlert("Successfuly added contact");
					return RedirectToAction(nameof(IndexAsync).FormatActionName());
				}

				this.AddErrorAlert("Failed to add contact");
			}

			return View("CreateUpdatePerson", model);
		}

		[HttpGet("{id}/update/person")]
		public async Task<IActionResult> UpdatePersonAsync([FromRoute] string id)
		{
			var result = await _contactsService.GetItemAsync(id);

			if (result.IsSuccessful)
			{
				var model = Mapper.Map<UpdatePersonContactModel>(result.Response);
				model.Id = id;

				return View("CreateUpdatePerson", model);
			}

			this.AddErrorAlert("Failed to get data");
			return View("CreateUpdatePerson", new UpdatePersonContactModel { Id = id });
		}

		[HttpPost("{id}/update/person")]
		public async Task<IActionResult> UpdatePersonAsync([FromRoute] string id, [FromForm] CreateUpdatePersonContactModel model)
		{
			if (model == null)
				return View("CreateUpdatePerson", new UpdatePersonContactModel { Id = id });

			if (ModelState.IsValid)
			{
				var request = Mapper.Map<PersonContactCreateUpdateRequest>(model);
				var result = await this._contactsService.UpdatePersonContactAsync(id, request);

				if (result.IsSuccessful)
				{
					this.AddSuccessAlert("Successfuly updated contact");
					return RedirectToAction(nameof(IndexAsync).FormatActionName());
				}

				this.AddErrorAlert("Failed to update contact");
			}

			var returnModel = Mapper.Map<UpdatePersonContactModel>(model);
			returnModel.Id = id;
			return View("CreateUpdatePerson", returnModel);
		}

		[HttpGet("create/company")]
		public IActionResult CreateCompany()
			=> View("CreateUpdateCompany", new CreateUpdateCompanyContactModel());

		[HttpPost("create/company")]
		public async Task<IActionResult> CreateCompanyAsync([FromForm] CreateUpdateCompanyContactModel model)
		{
			if (model == null)
				return View("CreateUpdateCompany", new CreateUpdateCompanyContactModel());

			if (ModelState.IsValid)
			{
				var request = Mapper.Map<CompanyContactCreateUpdateRequest>(model);
				var result = await this._contactsService.CreateCompanyContactAsync(request);

				if (result.IsSuccessful)
				{
					this.AddSuccessAlert("Successfuly added contact");
					return RedirectToAction(nameof(IndexAsync).FormatActionName());
				}

				this.AddErrorAlert("Failed to add contact");
			}

			return View("CreateUpdateCompany", model);
		}

		[HttpGet("{id}/update/company")]
		public async Task<IActionResult> UpdateCompanyAsync([FromRoute] string id)
		{
			var result = await _contactsService.GetItemAsync(id);

			if (result.IsSuccessful)
			{
				var model = Mapper.Map<UpdateCompanyContactModel>(result.Response);
				model.Id = id;

				return View("CreateUpdateCompany", model);
			}

			this.AddErrorAlert("Failed to get data");
			return View("CreateUpdateCompany", new UpdateCompanyContactModel { Id = id });
		}

		[HttpPost("{id}/update/company")]
		public async Task<IActionResult> UpdateCompanyAsync([FromRoute] string id, [FromForm] CreateUpdateCompanyContactModel model)
		{
			if (model == null)
				return View("CreateUpdateCompany", new UpdateCompanyContactModel { Id = id });

			if (ModelState.IsValid)
			{
				var request = Mapper.Map<CompanyContactCreateUpdateRequest>(model);
				var result = await this._contactsService.UpdateCompanyContactAsync(id, request);

				if (result.IsSuccessful)
				{
					this.AddSuccessAlert("Successfuly updated contact");
					return RedirectToAction(nameof(IndexAsync).FormatActionName());
				}

				this.AddErrorAlert("Failed to update contact");
			}

			var returnModel = Mapper.Map<UpdateCompanyContactModel>(model);
			returnModel.Id = id;
			return View("CreateUpdateCompany", returnModel);
		}

		[HttpGet("search")]
		public async Task<IActionResult> SearchAsync([FromQuery] string term, [FromQuery] string id)
		{
			if (!ModelState.IsValid)
				return BadRequest(ModelState);

			if (!string.IsNullOrWhiteSpace(id))
			{
				var response = await this._contactsService.GetItemAsync(id);

				if (response == null)
					return NotFound();

				if (response.TryGetErrorActionResult(out IActionResult result))
					return result;

				return Json
				(
					new { response.Response.Id, Text = response.Response.FullName }
				);
			}
			else
			{
				var response = await this._contactsService.LookupListAsync(new ContactLookupRequest { Term = term });

				if (response == null)
					return NotFound();

				if (response.TryGetErrorActionResult(out IActionResult result))
					return result;

				return Json
				(
					response.Response
						.Select(item => new { item.Id, Text = item.FullName })
						.OrderBy(item => item.Text)
				);
			}
		}

		[HttpGet("search/staff")]
		public async Task<IActionResult> SearchStaffAsync([FromQuery] string term, [FromQuery] string id)
		{
			if (!ModelState.IsValid)
				return BadRequest(ModelState);

			if (!string.IsNullOrWhiteSpace(id))
			{
				var response = await this._contactsService.GetItemAsync(id);

				if (response.TryGetErrorActionResult(out IActionResult result))
					return result;

				return Json
				(
					new { response.Response.Id, Text = response.Response.FullName }
				);
			}
			else
			{
				var response = await this._contactsService.LookupListAsync(new ContactLookupRequest { Term = term, Type = ContactLookupType.EnabledStaff });

				if (response.TryGetErrorActionResult(out IActionResult result))
					return result;

				return Json
				(
					response.Response
						.Select(item => new { item.Id, Text = item.FullName })
						.OrderBy(item => item.Text)
				);
			}
		}

		protected override void SetUpdateLink(IEditLinkModel model)
		{
			model.EditLink = ((ContactsModel)model)?.Type switch
			{
				"Person" => $"/contacts/{model.Id}/update/person",
				"Company" => $"/contacts/{model.Id}/update/company",
				_ => throw new ArgumentException(nameof(model))
			};
		}

		protected override void ConfigureMapper(IMapperConfigurationExpression options)
		{
			options
				.CreateMap<SearchModel, ContactListRequest>()
				.ForMember(newDto => newDto.PageIndex, config =>
				{
					config.MapFrom(oldDto => oldDto.Page);
					config.AddTransform(member => member.HasValue ? member.Value - 1 : 0);
				});

			options
				.CreateMap<ListResponse<ContactListItem>, SearchResponseModel<ContactsModel>>()
				.ForMember(newDto => newDto.Items, config => config.MapFrom(oldDto => oldDto.Records))
				.ForMember(newDto => newDto.Page, config =>
				{
					config.MapFrom(oldDto => oldDto.PageIndex);
					config.AddTransform(member => member + 1);
				});

			options
				.CreateMap<PersonContactViewItem, UpdatePersonContactModel>();

			options
				.CreateMap<CompanyContactViewItem, UpdateCompanyContactModel>()
				.ForMember(newDto => newDto.Name, config => config.MapFrom(oldDto => oldDto.FullName));

			options
				.CreateMap<ContactListItem, ContactsModel>();

			options
				.CreateMap<CreateUpdatePersonContactModel, PersonContactCreateUpdateRequest>();

			options
				.CreateMap<CreateUpdatePersonContactModel, UpdatePersonContactModel>();

			options
				.CreateMap<CreateUpdateCompanyContactModel, CompanyContactCreateUpdateRequest>();

			options
				.CreateMap<CreateUpdateCompanyContactModel, UpdateCompanyContactModel>();
		}
	}
}