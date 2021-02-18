using Integration.Sample.ApiServer.Common.Models.Base;

namespace Integration.Sample.ApiServer.PracticeAreas.Item
{
	public class PracticeAreaViewItem : ViewItemBase
	{
		public string Name { get; set; }

		public StageViewItem[] Stages { get; set; }
	}
}