using System.Net;

namespace Integration.Sample.Models.Common
{
	public class HttpOperationResult<TResponse> : HttpOperationResult
	{
		public HttpOperationResult(HttpStatusCode status, TResponse response)
			: base(status)
			=> Response = response;

		public TResponse Response { get; }
	}

	public class HttpOperationResult
	{
		public HttpOperationResult(HttpStatusCode status)
		{
			Status = status;

			IsSuccessful = status == HttpStatusCode.OK || status == HttpStatusCode.NoContent;
		}

		public HttpStatusCode Status { get; }

		public bool IsSuccessful { get; }
	}
}