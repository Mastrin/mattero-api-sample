using AutoMapper;
using Integration.Sample.ApiServer.PracticeAreas;
using Integration.Sample.ApiServer.PracticeAreas.Item;
using Integration.Sample.ApiServer.PracticeAreas.Lookup;
using Integration.Sample.Controllers.Base;
using Integration.Sample.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Integration.Sample.Controllers
{
	[Route("practice-areas")]
	[AllowAnonymous]
	public class PracticeAreasController :
		ApiServerControllerBase
	{
		private readonly IPracticeAreasService _practiceAreasService;

		public PracticeAreasController(IPracticeAreasService practiceAreasService)
			: base()
			=> _practiceAreasService = practiceAreasService;

		[HttpGet("search")]
		public async Task<IActionResult> SearchAsync([FromQuery] string term, [FromQuery] string id)
		{
			if (!ModelState.IsValid)
				return BadRequest(ModelState);

			if (!string.IsNullOrWhiteSpace(id))
			{
				var response = await this._practiceAreasService.GetItemAsync(id);

				if (response == null)
					return NotFound();

				if (response.TryGetErrorActionResult(out IActionResult result))
					return result;

				return Json
				(
					new { response.Response.Id, Text = response.Response.Name }
				);
			}
			else
			{
				var response = await this._practiceAreasService.LookupListAsync(new PracticeAreaLookupRequest { Term = term });

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

		[HttpGet("search/stages")]
		public async Task<IActionResult> SearchAsync([FromQuery][Required] string parentId, [FromQuery] int? id, [FromQuery] string term)
		{
			if (!ModelState.IsValid)
				return BadRequest(ModelState);

			if (id != null)
			{
				var response = await this._practiceAreasService.GetItemAsync(parentId);

				if (response.TryGetErrorActionResult(out IActionResult result))
					return result;

				var stage = response.Response
					?.Stages
					?.FirstOrDefault(stage => stage.Id == id);

				if (stage == null)
					return NotFound();

				return Json
				(
					new { stage.Id, Text = stage.Name }
				);
			}
			else
			{
				var response = await this._practiceAreasService.GetItemAsync(parentId);

				if (response.TryGetErrorActionResult(out IActionResult result))
					return result;


				if (response.Response?.Stages == null || !response.Response.Stages.Any())
					return NotFound();

				IEnumerable<StageViewItem> stages = response.Response.Stages;

				if (!string.IsNullOrWhiteSpace(term))
					stages = stages.Where(stage => stage.Name.Contains(term, StringComparison.OrdinalIgnoreCase));

				stages = stages
					.OrderBy(stage => stage.Id)
					.Take(5);

				if (stages == null || !stages.Any())
					return NotFound();

				return Json
				(
					stages
						.Select(stage => new { Id = stage.Id.ToString(), Text = stage.Name })
						.OrderBy(stage => stage.Text)
				);
			}
		}


		protected override void ConfigureMapper(IMapperConfigurationExpression options)
		{
			// Skip
		}
	}
}