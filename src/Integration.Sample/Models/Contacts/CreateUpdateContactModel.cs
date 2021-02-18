using System.ComponentModel.DataAnnotations;

namespace Integration.Sample.Models.Contacts
{
	public abstract class CreateUpdateContactModel
	{
		public string Website { get; set; }

		public string Notes { get; set; }

		[Display(Name = "Australian Business Number")]
		public string Abn { get; set; }

		//public IEnumerable<Address> Addresses { get; set; }

		//public IEnumerable<string> Phones { get; set; }

		//public IEnumerable<string> Emails { get; set; }
	}
}