using Integration.Sample.ApiServer.Common.Services;
using Integration.Sample.ApiServer.Contacts.Common;
using Integration.Sample.ApiServer.Contacts.Item;
using Integration.Sample.ApiServer.Contacts.List;
using Integration.Sample.ApiServer.Contacts.Lookup;
using Integration.Sample.Constants;
using Integration.Sample.Models.Common;
using Integration.Sample.Serializers.Json;
using System;
using System.Threading.Tasks;

namespace Integration.Sample.ApiServer.Contacts
{
	public class ContactsService :
		QueryLookupServiceBase
		<
			ContactViewItem,
			ContactListRequest,
			ContactListItem,
			ContactLookupRequest,
			ContactLookupItem
		>,
		IContactsService
	{
		private readonly IJsonSerializer _jsonSerializer;

		public ContactsService(IHttpService httpService, IJsonSerializer jsonSerializer)
			: base(httpService, ApiServerConstants.Endpoints.Contacts.Uri)
			=> _jsonSerializer = jsonSerializer;

		public Task<HttpOperationResult<ContactReference>> CreateCompanyContactAsync(CompanyContactCreateUpdateRequest dto)
			=> HttpService.PostAsync<ContactReference>(ApiServerConstants.Endpoints.Contacts.CompanyUri, dto);

		public Task<HttpOperationResult<ContactReference>> CreatePersonContactAsync(PersonContactCreateUpdateRequest dto)
			=> HttpService.PostAsync<ContactReference>(ApiServerConstants.Endpoints.Contacts.PersonUri, dto);

		public Task<HttpOperationResult> UpdateCompanyContactAsync(string id, CompanyContactCreateUpdateRequest dto)
			=> HttpService.PatchAsync($"{ApiServerConstants.Endpoints.Contacts.CompanyUri}/{id}", dto);

		public Task<HttpOperationResult> UpdatePersonContactAsync(string id, PersonContactCreateUpdateRequest dto)
			=> HttpService.PatchAsync($"{ApiServerConstants.Endpoints.Contacts.PersonUri}/{id}", dto);

		public override Task<HttpOperationResult<ContactViewItem>> GetItemAsync(string id)
			=> HttpService.GetAsync($"{ApiServerConstants.Endpoints.Contacts.Uri}/{id}", deserializer: async json =>
			{
				return json.Contains("\"firstname\":", StringComparison.OrdinalIgnoreCase)
					? (ContactViewItem)await _jsonSerializer.DeserializeAsync<PersonContactViewItem>(json)
					: await _jsonSerializer.DeserializeAsync<CompanyContactViewItem>(json);
			});
	}
}