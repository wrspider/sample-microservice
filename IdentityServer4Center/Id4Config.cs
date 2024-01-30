using IdentityServer4.Models;
using IdentityServer4.Test;

using System.Xml.Linq;

namespace SecurityServer
{
    public class Id4Config
    {
        /// <summary>
        /// 添加客户端，定义一个可以访问此api的客户端
        /// </summary>
        public static IEnumerable<Client> Clients =>
          new List<Client>
          {
            new Client()
            {

                AllowedGrantTypes =GrantTypes.ClientCredentials ,//密码模式
                ClientId = "client",//使用者端唯一標識
                ClientSecrets = { new Secret("secret".Sha256()) },//使用者端密碼，進行了加密
                AllowedScopes = new List<string>//客户端有权访问的范围（Scopes）
                               {
                                    "API_1",
                                    "API_2"
                               },//允許存取的資源
            },
             new Client()
            {

                AllowedGrantTypes =GrantTypes.ResourceOwnerPassword,//客户端授权类型，ClientCredentials:客户端凭证方式
                ClientId = "client-password",//使用者端唯一標識
                ClientSecrets = { new Secret("pwd".Sha256()) },//使用者端密碼，進行了加密
                AllowedScopes = new List<string>//客户端有权访问的范围（Scopes）  顾名思义就是对一个 OAuth API 的范围定义,ApiScope 主要用于定义一个 Api 的作用域范围，该范围可以很小。只有当客户端配置的域名与该域名相匹配时才验证通过，否则返回 invalid_scope。
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

        //public static IEnumerable<IdentityResource> IdentityResources =>
        //        new List<IdentityResource> { };
        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new IdentityResource[]
            {
        new IdentityResources.OpenId(),
        new IdentityResources.Profile(),
            };
        }
        //ApiResource 定义的是一个 web API 资源。它代表客户端需要访问的功能。通常，它们是基于 HTTP 的终点（API），亦可是消息队列终点或类似的终点。
        public static IEnumerable<ApiResource> ApiResources =>
            new List<ApiResource> {
                  new ApiResource(){ Name="API_1"},
                  new ApiResource(){ Name="API_2"},
                  new ApiResource("user", "user service")};
        public static List<TestUser> GetTestUsers()
        {
            return new List<TestUser> {
                new TestUser{
                    SubjectId="1",
                    Password="111",
                    Username="111",
                }
            };
        }

    }
}
