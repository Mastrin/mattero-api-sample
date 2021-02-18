using Integration.Sample.Extensions;

namespace Microsoft.AspNetCore.Mvc
{
	public static class ControllerExtensions
	{
		public static void AddSuccessAlert(this ControllerBase controller, string name, string message)
			=> controller.HttpContext.AddSuccessAlert(name, message);

		public static void AddSuccessAlert(this ControllerBase controller, string message)
			=> AddSuccessAlert(controller, controller.GetType().Name.FormatControllerName(), message);

		public static void AddWarningAlert(this ControllerBase controller, string name, string message)
			=> controller.HttpContext.AddWarningAlert(name, message);

		public static void AddWarningAlert(this ControllerBase controller, string message)
			=> AddWarningAlert(controller, controller.GetType().Name.FormatControllerName(), message);

		public static void AddErrorAlert(this ControllerBase controller, string name, string message)
			=> controller.HttpContext.AddErrorAlert(name, message);

		public static void AddErrorAlert(this ControllerBase controller, string message)
			=> AddErrorAlert(controller, controller.GetType().Name.FormatControllerName(), message);
	}
}
