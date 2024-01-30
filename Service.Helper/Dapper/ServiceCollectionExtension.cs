using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Options;

using MySqlConnector;

using Npgsql;

using Service.Helper.Const;
using Service.Helper.Enums;
using Service.Helper.Extensions;

using System.Data;

namespace Service.Helper.Dapper
{
    public static class ServiceCollectionExtension
    {
        public static IConfiguration? _Configuration { get; private set; }
        private static Connection? _connection;
        private static Dictionary<string, string> ConnectionPool = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
        private static string DefaultDBName = "defalut";

        public static IServiceCollection AddDapperDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));
            //初始化配置文件
            Init(services, configuration);

            services.AddSingleton<DapperFactory>();
            services.TryAddSingleton<IDapperFactory>(serviceProvider => serviceProvider.GetRequiredService<DapperFactory>());


            //if (connectOptions != null)
            //{
            //    foreach (var option in connectOptions)
            //    {
            //        if (contextLifetime == ServiceLifetime.Scoped)
            //            services.AddScoped(s => new BucketSqlSugarClient(option));
            //        if (contextLifetime == ServiceLifetime.Singleton)
            //            services.AddSingleton(s => new BucketSqlSugarClient(option));
            //        if (contextLifetime == ServiceLifetime.Transient)
            //            services.AddTransient(s => new BucketSqlSugarClient(option));
            //    }
            //    if (contextLifetime == ServiceLifetime.Singleton)
            //        services.AddSingleton<ISqlSugarDbContextFactory, SqlSugarDbContextFactory>();
            //    if (contextLifetime == ServiceLifetime.Scoped)
            //        services.AddScoped<ISqlSugarDbContextFactory, SqlSugarDbContextFactory>();
            //    if (contextLifetime == ServiceLifetime.Transient)
            //        services.AddTransient<ISqlSugarDbContextFactory, SqlSugarDbContextFactory>();
            //}
            return services;
        }

        public static void Init(IServiceCollection services, IConfiguration configuration)
        {
            _Configuration = configuration;
            services.Configure<Connection>(configuration.GetSection("Connection"));
            services.Configure<RedisConfig>(configuration.GetSection("RedisConfig"));
            services.Configure<Secret>(configuration.GetSection("Secret"));
            var provider = services.BuildServiceProvider();
            _connection = provider.GetRequiredService<IOptions<Connection>>().Value;
            var _secret = provider.GetRequiredService<IOptions<Secret>>().Value;

            DBType.Name = _connection.DBType;
            DefaultDBName = _connection.DefaultDBName;//資料庫名稱
            if (string.IsNullOrEmpty(_connection.DbConnectionString))
                throw new System.Exception("未配置好数据库默认连接");
            try
            {
                _connection.DbConnectionString = _connection.DbConnectionString.DecryptDES(_secret.DB);
            }
            catch { }
            if (!string.IsNullOrEmpty(_connection.RedisConnectionString))
            {
                try
                {
                    _connection.RedisConnectionString = _connection.RedisConnectionString.DecryptDES(_secret.Redis);
                }
                catch { }
            }

        }


    }


}
