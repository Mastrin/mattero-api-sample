using Integration.Sample.ApiServer.Common.Services;
using Integration.Sample.ApiServer.Contacts.Common;
using Integration.Sample.ApiServer.Contacts.Item;
using Integration.Sample.ApiServer.Contacts.List;
using Integration.Sample.ApiServer.Contacts.Lookup;
using Integration.Sample.Models.Common;
using System.Threading.Tasks;

namespace Integration.Sample.ApiServer.Contacts
{
	public interface IContactsService :
		IQueryLookupService
		<
			ContactViewItem,
			ContactListRequest,
			ContactListItem,
			ContactLookupRequest,
			ContactLookupItem
		>
	{
		Task<HttpOperationResult<ContactReference>> CreatePersonContactAsync(PersonContactCreateUpdateRequest dto);
		Task<HttpOperationResult<ContactReference>> CreateCompanyContactAsync(CompanyContactCreateUpdateRequest dto);
		Task<HttpOperationResult> UpdatePersonContactAsync(string id, PersonContactCreateUpdateRequest dto);
		Task<HttpOperationResult> UpdateCompanyContactAsync(string id, CompanyContactCreateUpdateRequest dto);
	}
}