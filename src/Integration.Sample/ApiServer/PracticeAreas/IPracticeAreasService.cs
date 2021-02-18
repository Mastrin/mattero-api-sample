using Integration.Sample.ApiServer.Common.Services;
using Integration.Sample.ApiServer.PracticeAreas.Item;
using Integration.Sample.ApiServer.PracticeAreas.Lookup;

namespace Integration.Sample.ApiServer.PracticeAreas
{
	public interface IPracticeAreasService :
		ILookupService<PracticeAreaLookupRequest, PracticeAreaLookupItem>,
		IViewService<PracticeAreaViewItem>
	{ }
}