using Integration.Sample.ApiServer.Common.Models.Base;

namespace Integration.Sample.ApiServer.PracticeAreas.Lookup
{
	public class PracticeAreaLookupRequest : LookupRequestBase
	{
		public string Term { get; set; }
	}
}
