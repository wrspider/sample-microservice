using Consul;
using System.Net;

namespace Extensions
{
    public static class ConsulRegister
    {
        /// <summary>
        /// 服务注册到consul
        /// </summary>
        /// <param name="app"></param>
        /// <param name="lifetime"></param>
        public static IApplicationBuilder RegisterConsul_test(this IApplicationBuilder app, IConfiguration configuration, IHostApplicationLifetime lifetime, int Port = 0)
        {
            var consulClient = new ConsulClient(c =>
            {
                //consul地址
                c.Address = new Uri(configuration["ConsulSetting:ConsulAddress"]);
            });
            string ServiceName = configuration["ConsulSetting:ServiceName"];
            string ServiceIP = configuration["ConsulSetting:ServiceIP"];
            int ServicePort = Port == 0 ? Port : int.Parse(configuration["ConsulSetting:ServicePort"]);
            var registration = new AgentServiceRegistration()
            {
                ID = Guid.NewGuid().ToString(),//服务实例唯一标识
                Name = ServiceName,//服务名
                Address = ServiceIP, //服务IP
                Port = ServicePort,//服务端口 因为要运行多个实例，端口不能在appsettings.json里配置，在docker容器运行时传入
                Check = new AgentServiceCheck()
                {
                    DeregisterCriticalServiceAfter = TimeSpan.FromSeconds(5),//服务启动多久后注册
                    Interval = TimeSpan.FromSeconds(10),//健康检查时间间隔
                    HTTP = $"http://{ServiceIP}:{ServicePort}/Health",//健康检查地址
                    Timeout = TimeSpan.FromSeconds(5)//超时时间
                }
            };
            //健康检查，不需要新建Controller
            app.MapWhen(context => context.Request.Path.Equals("/Health"), applicationBuilder => applicationBuilder.Run(async context =>
            {
                context.Response.StatusCode = (int)HttpStatusCode.OK;
                await context.Response.WriteAsync("OK");
            }));
            //服务注册
            consulClient.Agent.ServiceRegister(registration).Wait();

            //应用程序终止时，取消注册
            lifetime.ApplicationStopping.Register(() =>
            {
                consulClient.Agent.ServiceDeregister(registration.ID).Wait();
            });
            Console.WriteLine($"{ServiceName}服务注册成功");
            return app;
        }
    }
}
