using Integration.Sample.Attributes;
using Integration.Sample.Models.Common;
using System;
using System.ComponentModel.DataAnnotations;

namespace Integration.Sample.Models.Tasks
{
	public class TasksModel : IEditLinkModel
	{
		[TableIgnore]
		public string Id { get; set; }

		public DateTime? DueDate { get; set; }

		public string Description { get; set; }

		public string Status { get; set; }

		[Display(Name = "Related To")]
		public string RelatedToName { get; set; }

		[Display(Name = "Assigned To")]
		public string AssignedToName { get; set; }

		[TableIgnore]
		[TablePropertyLink(nameof(Description))]
		public string EditLink { get; set; }
	}
}