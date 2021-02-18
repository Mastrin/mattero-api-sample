using Integration.Sample.Attributes;
using Integration.Sample.Models.Common;
using System;
using System.ComponentModel.DataAnnotations;

namespace Integration.Sample.Models.Matters
{
	public class MattersModel : IEditLinkModel
	{
		[TableIgnore]
		public string Id { get; set; }

		public string Title { get; set; }

		[Display(Name = "Client")]
		public string ClientName { get; set; }

		[Display(Name = "Practice Area")]
		public string PracticeAreaName { get; set; }

		[Display(Name = "Stage")]
		public string StageName { get; set; }

		[Display(Name = "Open Date")]
		public DateTime? OpenDate { get; set; }

		[Display(Name = "Last Change")]
		public DateTime LastChanged { get; set; }

		[TableIgnore]
		[TablePropertyLink(nameof(Title))]
		public string EditLink { get; set; }
	}
}