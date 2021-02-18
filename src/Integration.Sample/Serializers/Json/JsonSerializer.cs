using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using NJsonSerializer = Newtonsoft.Json.JsonSerializer;

namespace Integration.Sample.Serializers.Json
{
	public class JsonSerializer : IJsonSerializer
	{
		private readonly NJsonSerializer _serializer;

		public JsonSerializer()
		{
			var settings = new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() };
			_serializer = NJsonSerializer.CreateDefault(settings);
		}

		public TModel Deserialize<TModel>(string data)
		{
			using (TextReader reader = new StringReader(data))
			using (JsonReader jsonReader = new JsonTextReader(reader))
				return _serializer.Deserialize<TModel>(jsonReader);
		}

		public Task<TModel> DeserializeAsync<TModel>(string data)
			=> Task.FromResult(Deserialize<TModel>(data));

		public string Serialize(object model)
		{
			StringBuilder builder = new StringBuilder();
			using (TextWriter writer = new StringWriter(builder))
				_serializer.Serialize(writer, model);

			return builder.ToString();
		}

		public Task<string> SerializeAsync(object model)
			=> Task.FromResult(Serialize(model));
	}
}