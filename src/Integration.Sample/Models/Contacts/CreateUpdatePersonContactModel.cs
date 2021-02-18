using Integration.Sample.ApiServer.Contacts.Common;
using System;
using System.ComponentModel.DataAnnotations;

namespace Integration.Sample.Models.Contacts
{
	public class CreateUpdatePersonContactModel : CreateUpdateContactModel
	{
		[Required]
		[Display(Name = "First Name")]
		public string FirstName { get; set; }

		[Display(Name = "Middle Name")]
		public string MiddleName { get; set; }

		[Required]
		[Display(Name = "Last Name")]
		public string LastName { get; set; }

		public DateTime? Birthday { get; set; }

		public string Company { get; set; }

		[Display(Name = "Job Title")]
		public string JobTitle { get; set; }

		public string Title { get; set; }

		public Gender Gender { get; set; }
	}
}
