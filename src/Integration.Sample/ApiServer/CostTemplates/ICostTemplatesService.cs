using Integration.Sample.ApiServer.Common.Services;
using Integration.Sample.ApiServer.CostTemplates.Lookup;

namespace Integration.Sample.ApiServer.CostTemplates
{
	public interface ICostTemplatesService :
		ILookupService<CostTemplateLookupRequest, CostTemplateLookupItem>
	{ }
}