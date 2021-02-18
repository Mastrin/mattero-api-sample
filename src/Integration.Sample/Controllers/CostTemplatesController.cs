using AutoMapper;
using Integration.Sample.ApiServer.CostTemplates;
using Integration.Sample.ApiServer.CostTemplates.Lookup;
using Integration.Sample.Controllers.Base;
using Integration.Sample.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace Integration.Sample.Controllers
{
	[Route("cost-templates")]
	[AllowAnonymous]
	public class CostTemplatesController :
		ApiServerControllerBase
	{
		private readonly ICostTemplatesService _practiceAreasService;

		public CostTemplatesController(ICostTemplatesService practiceAreasService)
			: base()
			=> _practiceAreasService = practiceAreasService;

		[HttpGet("search")]
		public async Task<IActionResult> SearchAsync([FromQuery] string term, [FromQuery] string id)
		{
			if (!ModelState.IsValid)
				return BadRequest(ModelState);

			if (!string.IsNullOrWhiteSpace(id))
			{
				var response = await this._practiceAreasService.LookupListAsync(new CostTemplateLookupRequest { Term = id });

				if (response == null)
					return NotFound();

				if (response.TryGetErrorActionResult(out IActionResult result))
					return result;

				return Json
				(
					response.Response
						.Select(item => new { item.Id, Text = item.Name })
						.FirstOrDefault()
				);
			}
			else
			{
				var response = await this._practiceAreasService.LookupListAsync(new CostTemplateLookupRequest { Term = term });

				if (response == null)
					return NotFound();

				if (response.TryGetErrorActionResult(out IActionResult result))
					return result;

				return Json
				(
					response.Response
						.Select(item => new { item.Id, Text = item.Name })
						.OrderBy(item => item.Text)
				);
			}
		}

		protected override void ConfigureMapper(IMapperConfigurationExpression options)
		{
			// Skip
		}
	}
}