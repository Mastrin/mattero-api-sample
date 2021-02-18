using Integration.Sample.ApiServer.Common.Models;
using Integration.Sample.ApiServer.Common.Services;
using Integration.Sample.ApiServer.Tasks.Item;
using Integration.Sample.ApiServer.Tasks.List;
using Integration.Sample.Constants;
using Integration.Sample.Models.Common;
using System.Threading.Tasks;

namespace Integration.Sample.ApiServer.Tasks
{
	public class TasksService :
		QueryServiceBase
		<
			TaskViewItem,
			TaskListRequest,
			TaskListItem
		>,
		ITasksService
	{
		public TasksService(IHttpService httpService)
			: base(httpService, ApiServerConstants.Endpoints.Tasks.Uri)
		{ }

		public Task<HttpOperationResult<EntityReference>> CreateTaskAsync(TaskCreateUpdateRequest dto)
			=> HttpService.PostAsync<EntityReference>(ApiServerConstants.Endpoints.Tasks.Uri, dto);

		public Task<HttpOperationResult> UpdateTaskAsync(string id, TaskCreateUpdateRequest dto)
			=> HttpService.PatchAsync($"{ApiServerConstants.Endpoints.Tasks.Uri}/{id}", dto);
	}
}