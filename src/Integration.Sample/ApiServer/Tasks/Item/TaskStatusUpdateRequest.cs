using Integration.Sample.ApiServer.Common.Models.Base;
using Integration.Sample.ApiServer.Tasks.Common;

namespace Integration.Sample.ApiServer.Tasks.Item
{
	public class TaskStatusUpdateRequest : RequestBase
	{
		public TaskStatus Status { get; set; }
	}
}