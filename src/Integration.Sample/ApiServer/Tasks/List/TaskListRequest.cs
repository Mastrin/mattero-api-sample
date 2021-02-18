using Integration.Sample.ApiServer.Common.Models.Base;
using Integration.Sample.ApiServer.Tasks.Common;
using System;
using System.Collections.Generic;

namespace Integration.Sample.ApiServer.Tasks.List
{
	public class TaskListRequest : ListRequestBase
	{
		public DateTime? DueDateStart { get; set; }
		public DateTime? DueDateEnd { get; set; }
		public ICollection<TaskStatus> Status { get; set; }
		public TaskType? TaskType { get; set; }
		public bool My { get; set; }
		public string AssignedToId { get; set; }
		public string AssociatedMatterId { get; set; }
		public string AssociatedContactId { get; set; }
	}
}
