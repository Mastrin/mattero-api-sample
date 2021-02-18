using System.Threading.Tasks;

namespace Integration.Sample.Serializers
{
	public interface ISerializer
	{
		string Serialize(object model);
		Task<string> SerializeAsync(object model);

		TModel Deserialize<TModel>(string data);
		Task<TModel> DeserializeAsync<TModel>(string data);
	}
}