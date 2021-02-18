using Integration.Sample.ApiServer.Common.Models.Base;

namespace Integration.Sample.ApiServer.CostTemplates.Lookup
{
	public class CostTemplateLookupRequest : LookupRequestBase
	{
		public string Term { get; set; }
	}
}
