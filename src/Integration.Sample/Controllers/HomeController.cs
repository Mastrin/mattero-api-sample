using Integration.Sample.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Integration.Sample.Controllers
{
	[Route("")]
	[AllowAnonymous]
	public class HomeController : Controller
	{
		[HttpGet]
		public IActionResult Index()
			=> RedirectToAction
			(
				nameof(MattersController.IndexAsync).FormatActionName(),
				nameof(MattersController).FormatControllerName()
			);
	}
}