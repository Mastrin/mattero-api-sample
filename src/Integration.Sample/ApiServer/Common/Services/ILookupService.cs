using Integration.Sample.ApiServer.Common.Models.Base;
using Integration.Sample.Models.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Integration.Sample.ApiServer.Common.Services
{
	public interface ILookupService<TLookupRequest, TLookupItem>
		where TLookupRequest : LookupRequestBase
		where TLookupItem : LookupItemBase
	{
		Task<HttpOperationResult<List<TLookupItem>>> LookupListAsync(TLookupRequest request);
	}
}
