using Integration.Sample.ApiServer.Common.Models;
using Integration.Sample.ApiServer.Common.Services;
using Integration.Sample.ApiServer.Tasks.Item;
using Integration.Sample.ApiServer.Tasks.List;
using Integration.Sample.Models.Common;
using System.Threading.Tasks;

namespace Integration.Sample.ApiServer.Tasks
{
	public interface ITasksService :
		IQueryService
		<
			TaskViewItem,
			TaskListRequest,
			TaskListItem
		>
	{
		Task<HttpOperationResult<EntityReference>> CreateTaskAsync(TaskCreateUpdateRequest dto);
		Task<HttpOperationResult> UpdateTaskAsync(string id, TaskCreateUpdateRequest dto);
	}
}