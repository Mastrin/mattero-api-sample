using Integration.Sample.ApiServer.Common.Models;
using Integration.Sample.ApiServer.Common.Models.Base;
using Integration.Sample.ApiServer.Matters.Common;
using Integration.Sample.ApiServer.Tasks.Common;
using System;

namespace Integration.Sample.ApiServer.Tasks.List
{
	public class TaskListItem : ListItemBase
	{
		public string Description { get; set; }
		public TaskStatus Status { get; set; }
		public DateTime? DueDate { get; set; }
		public EntityReference AssociatedContact { get; set; }
		public MatterReference AssociatedMatter { get; set; }
		public EntityReference AssignedTo { get; set; }
	}
}