using AutoMapper;
using Integration.Sample.ApiServer.Common.Models.Base;
using Integration.Sample.ApiServer.Common.Services;
using Integration.Sample.Extensions;
using Integration.Sample.Models.Common;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace Integration.Sample.Controllers.Base
{
	public abstract class ApiServerControllerBase<TListRequest, TListItem, TListModel> :
		ApiServerControllerBase
		where TListRequest : ListRequestBase
		where TListItem : ListItemBase
	{
		private readonly IListService<TListRequest, TListItem> _listService;

		public ApiServerControllerBase(IListService<TListRequest, TListItem> listService)
			: base()
			=> _listService = listService;

		protected async Task<IActionResult> GetListActionResultAsync(SearchModel model)
		{
			if (model == null)
				return BadRequest("Body cannot be empty");

			if (!ModelState.IsValid)
				return BadRequest(ModelState);

			SearchResponseModel<TListModel> list = null;
			if (model.Page > 0)
			{
				var request = Mapper.Map<TListRequest>(model);
				var response = await _listService.GetListAsync(request);

				if (response.TryGetErrorActionResult(out IActionResult result))
					return result;

				list = Mapper.Map<SearchResponseModel<TListModel>>(response.Response);
			}

			if (list == null)
				list = new SearchResponseModel<TListModel> { Page = model.Page };

			list.Search = model.Search;
			list.PageSize = model.PageSize;

			var editLinks = list.Items
				.Where(model => typeof(IEditLinkModel).IsAssignableFrom(model.GetType()))
				.Select(model => (IEditLinkModel)model);

			if (editLinks != null && editLinks.Any())
			{
				foreach (var editLink in editLinks)
					SetUpdateLink(editLink);
			}

			return View(list);
		}

		protected abstract void SetUpdateLink(IEditLinkModel model);
	}

	public abstract class ApiServerControllerBase :
		Controller
	{
		protected IMapper Mapper { get; }

		public ApiServerControllerBase()
			=> Mapper = new MapperConfiguration(ConfigureMapper).CreateMapper();

		protected abstract void ConfigureMapper(IMapperConfigurationExpression options);
	}
}
