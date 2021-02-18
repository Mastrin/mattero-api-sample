using Integration.Sample.Models.Common;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Integration.Sample.Extensions
{
	public static class HttpOperationResultExtensions
	{
		public static bool TryGetErrorActionResult(this HttpOperationResult response, out IActionResult result)
		{
			if (response.IsSuccessful)
			{
				result = null;
				return false;
			}

			result = response.Status switch
			{
				HttpStatusCode.BadRequest => new BadRequestResult(),
				HttpStatusCode.NotFound => new NotFoundResult(),
				HttpStatusCode.Unauthorized => new UnauthorizedResult(),
				HttpStatusCode.Forbidden => new ForbidResult(),
				_ => new StatusCodeResult((int)HttpStatusCode.InternalServerError)
			};

			return true;
		}
	}
}