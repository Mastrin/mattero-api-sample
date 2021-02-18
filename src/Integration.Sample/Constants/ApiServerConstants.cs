namespace Integration.Sample.Constants
{
	public static class ApiServerConstants
	{
		public const string AuthenticationScheme = "Bearer";

		public static class Endpoints
		{
			public const string Uri = "/public/api/v1";

			public static class Ping
			{
				public const string Name = "ping";
				public const string Uri = Endpoints.Uri + "/" + Name;
			}

			public static class Contacts
			{
				public const string Name = "contacts";
				public const string Uri = Endpoints.Uri + "/" + Name;
				public const string PersonUri = Uri + "/person";
				public const string CompanyUri = Uri + "/company";
			}

			public static class Matters
			{
				public const string Name = "matters";
				public const string Uri = Endpoints.Uri + "/" + Name;
			}

			public static class Tasks
			{
				public const string Name = "tasks";
				public const string Uri = Endpoints.Uri + "/" + Name;
			}

			public static class PracticeAreas
			{
				public const string Name = "practice-areas";
				public const string Uri = Endpoints.Uri + "/" + Name;
			}

			public static class CostTemplates
			{
				public const string Name = "cost-templates";
				public const string Uri = Endpoints.Uri + "/" + Name;
			}

			public static class Webhooks
			{
				public const string Name = "webhooks";
				public const string Uri = Endpoints.Uri + "/" + Name;
			}
		}
	}
}