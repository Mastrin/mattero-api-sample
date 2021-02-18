using Integration.Sample.Extensions;
using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Integration.Sample.Serializers.QueryString
{
	public class QueryStringSerializer : IQueryStringSerializer
	{
		public TModel Deserialize<TModel>(string data)
			=> throw new NotSupportedException();

		public Task<TModel> DeserializeAsync<TModel>(string data)
			=> throw new NotSupportedException();

		public string Serialize(object model)
			=> SerializeAsync(model).GetAwaiter().GetResult();

		public async Task<string> SerializeAsync(object model)
		{
			StringBuilder builder = new StringBuilder();
			using (TextWriter writer = new StringWriter(builder))
				await SerializeToQueryString(writer, model, model.GetType());

			return builder.ToString();
		}

		private static async Task SerializeToQueryString(TextWriter writer, object instance, Type type)
		{
			var properties = type
				.GetProperties()
				.OrderBy(property => property.Name)
				.AsEnumerable();

			if (properties != null && properties.Any())
			{
				bool useDelimiter = false;
				foreach (var property in properties)
				{
					bool success = await tryWriteProperty(property, useDelimiter);

					if (!useDelimiter && success)
						useDelimiter = true;
				}
			}

			async Task<bool> tryWriteProperty(PropertyInfo property, bool useDelimiter = true)
			{
				var value = property.GetValue(instance);

				if (value != null)
				{
					var field = $"{property.Name.ToLowerCamelCase()}={value}";

					if (useDelimiter)
						field = $"&{field}";

					await writer.WriteAsync(field);
					return true;
				}

				return false;
			}
		}
	}
}
