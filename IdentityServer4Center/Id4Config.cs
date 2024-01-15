using IdentityServer4.Models;

namespace IdentityServer4Center
{
    public class Id4Config
    {
        public static IEnumerable<Client> Clients =>
          new List<Client>
          {
            new Client()
            {
                AllowedGrantTypes = GrantTypes.ClientCredentials,
                ClientId = "client",//使用者端唯一標識
                ClientSecrets = { new Secret("secret".Sha256()) },//使用者端密碼，進行了加密
                AllowedScopes = new List<string>//允許存取的資源
                               {
                                    "API_1",
                                    "API_2"
                               },//允許存取的資源
            }
          };

        public static IEnumerable<ApiScope> ApiScopes =>
            new List<ApiScope>
            {
                new ApiScope(){Name = "API_1"},
                new ApiScope(){Name = "API_2"},
            };

        public static IEnumerable<IdentityResource> IdentityResources =>
                new List<IdentityResource> { };

        public static IEnumerable<ApiResource> ApiResources =>
            new List<ApiResource> { };

    }
}
