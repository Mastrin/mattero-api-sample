using System.ComponentModel.DataAnnotations;

namespace Integration.Sample.Models.Contacts
{
	public class CreateUpdateCompanyContactModel : CreateUpdateContactModel
	{
		[Required]
		public string Name { get; set; }

		[Display(Name = "Australian Company Number")]
		public string Acn { get; set; }
	}
}
