using Integration.Sample.ApiServer.Common.Models.Base;
using Integration.Sample.ApiServer.Tasks.Common;
using System;

namespace Integration.Sample.ApiServer.Tasks.Item
{
	public class TaskCreateUpdateRequest : CreateUpdateRequestBase
	{
		public string Description { get; set; }
		public TaskStatus Status { get; set; }
		public DateTime? DueDate { get; set; }
		public string AssociatedContactId { get; set; }
		public string AssociatedMatterId { get; set; }
		public string AssignedToId { get; set; }
	}
}