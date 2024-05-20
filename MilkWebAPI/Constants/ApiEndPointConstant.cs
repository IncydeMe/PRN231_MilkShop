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

        public class Account()
        {
            public const string AccountsEndpoint = ApiEndpoint + "/accounts";
            public const string AccountEndpoint = AccountsEndpoint + "/{id}";
        }

        public class Voucher()
        {
			public const string VouchersEndpoint = ApiEndpoint + "/vouchers";
			public const string VoucherEndpoint = VouchersEndpoint + "/{id}";
		}

        public class Gift()
        {
			public const string GiftsEndpoint = ApiEndpoint + "/gifts";
			public const string GiftEndpoint = GiftsEndpoint + "/{id}";
		}
    }
}
