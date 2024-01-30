using Dapper;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

using Service.Helper.Const;

namespace Service.Helper.Dapper
{
    public class DapperFactory : IDapperFactory
    {
        // IServiceProvider 視為一個工廠，用於在運行時動態取得服務的實例，而 IServiceCollection 則是用於配置這些服務的設計時機制。
        private readonly IServiceProvider _services;

        public DapperFactory(IServiceProvider services)
        {
            _services = services ?? throw new ArgumentNullException(nameof(services));
        }

        public SqlDapper CreateClient()
        {
            Connection _connectionString = _services.GetRequiredService<IOptions<Connection>>().Value;

            var client = new SqlDapper(_connectionString);

            return client;
        }

    }


}
