namespace MilkWebAPI.Constants
{
    public class ApiEndPointConstant
    {
        public const string RootEndPoint = "/api";
        public const string ApiVersion = "/v1";
        public const string ApiEndpoint = RootEndPoint + ApiVersion;

        public class Authentication()
        {
            public const string LoginEndpoint = ApiEndpoint + "/login";
            public const string RegisterEndpoint = ApiEndpoint + "/register";
        }
    }
}
