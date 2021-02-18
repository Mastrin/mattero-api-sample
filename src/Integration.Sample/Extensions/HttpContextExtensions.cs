using Integration.Sample.Models.Common;
using Microsoft.AspNetCore.Http;
using System;
using System.Linq;

namespace Integration.Sample.Extensions
{
	public static class HttpContextExtensions
	{
		private const string AlertMessagePrefix = "mattero-forms-alert-message-";
		private const string AlertSeverityPrefix = "mattero-forms-alert-severity-";

		public static void AddAlert(this HttpContext httpContext, string name, string message, AlertSeverity severity)
		{
			if (httpContext == null)
				throw new ArgumentNullException(nameof(httpContext));

			if (name == null)
				throw new ArgumentNullException(nameof(name));

			if (string.IsNullOrWhiteSpace(name))
				throw new ArgumentException(nameof(name));

			if (message == null)
				throw new ArgumentNullException(nameof(message));

			var messageKey = $"{AlertMessagePrefix}{name.ToLower()}";
			var severityKey = $"{AlertSeverityPrefix}{name.ToLower()}";

			if (httpContext.Session.Keys.Contains(messageKey))
				httpContext.Session.Remove(messageKey);

			if (httpContext.Session.Keys.Contains(severityKey))
				httpContext.Session.Remove(severityKey);

			httpContext.Session.SetString(messageKey, message);
			httpContext.Session.SetInt32(severityKey, (int)severity);
		}

		public static void AddSuccessAlert(this HttpContext httpContext, string name, string message)
			=> AddAlert(httpContext, name, message, AlertSeverity.Success);

		public static void AddWarningAlert(this HttpContext httpContext, string name, string message)
			=> AddAlert(httpContext, name, message, AlertSeverity.Warning);

		public static void AddErrorAlert(this HttpContext httpContext, string name, string message)
			=> AddAlert(httpContext, name, message, AlertSeverity.Error);

		public static AlertModel GetAlert(this HttpContext httpContext, string name)
		{
			if (httpContext == null)
				throw new ArgumentNullException(nameof(httpContext));

			if (name == null)
				throw new ArgumentNullException(nameof(name));

			if (string.IsNullOrWhiteSpace(name))
				throw new ArgumentException(nameof(name));

			var messageKey = $"{AlertMessagePrefix}{name.ToLower()}";
			var severityKey = $"{AlertSeverityPrefix}{name.ToLower()}";

			if (httpContext.Session.Keys.Contains(messageKey) && httpContext.Session.Keys.Contains(severityKey))
			{
				var message = httpContext.Session.GetString(messageKey);
				var severity = httpContext.Session.GetInt32(severityKey);

				httpContext.Session.Remove(messageKey);
				httpContext.Session.Remove(severityKey);

				if
				(
					!string.IsNullOrWhiteSpace(message) &&
					severity.HasValue &&
					severity.Value <= (int)AlertSeverity.Error &&
					severity.Value >= (int)AlertSeverity.Success
				)
				{
					return new AlertModel
					{
						Message = message,
						Severity = (AlertSeverity)severity.Value
					};
				}
			}

			return null;
		}
	}
}
