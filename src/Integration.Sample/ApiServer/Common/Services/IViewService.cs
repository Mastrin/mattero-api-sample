using Integration.Sample.ApiServer.Common.Models.Base;
using Integration.Sample.Models.Common;
using System.Threading.Tasks;

namespace Integration.Sample.ApiServer.Common.Services
{
	public interface IViewService<TView>
		where TView : ViewItemBase
	{
		Task<HttpOperationResult<TView>> GetItemAsync(string id);
	}
}