using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Helper.Const
{
    public class CommonType
    {
    }
    /// <summary>
    /// appsetting中数据库配置信息
    /// </summary>
    /// <summary>
    /// appsetting中数据库配置信息
    /// </summary>
    public class Connection
    {
        public string DBType { get; set; }
        public string DbConnectionString { get; set; }
        public string RedisConnectionString { get; set; }
        public bool UseRedis { get; set; }
        public string DefaultDBName { get; set; } = string.Empty;
    }

    public class CreateMember : TableDefaultColumns
    {
    }
    public class ModifyMember : TableDefaultColumns
    {
    }

    public abstract class TableDefaultColumns
    {
        public string UserIdField { get; set; }
        public string UserNameField { get; set; }
        public string DateField { get; set; }
        public string UserName { get; set; }
        public string DateField2 { get; set; }
        public string PlantCode { get; set; }
    }
    public class GlobalFilter
    {
        public string Message { get; set; }
        public bool Enable { get; set; }
        public string[] Actions { get; set; }
    }

    public class Kafka
    {
        public bool UseProducer { get; set; }
        public ProducerSettings ProducerSettings { get; set; }
        public bool UseConsumer { get; set; }
        public bool IsConsumerSubscribe { get; set; }
        public ConsumerSettings ConsumerSettings { get; set; }
        public Topics Topics { get; set; }
    }
    public class ProducerSettings
    {
        public string BootstrapServers { get; set; }
        public string SaslMechanism { get; set; }
        public string SecurityProtocol { get; set; }
        public string SaslUsername { get; set; }
        public string SaslPassword { get; set; }
    }
    public class ConsumerSettings
    {
        public string BootstrapServers { get; set; }
        public string SaslMechanism { get; set; }
        public string SecurityProtocol { get; set; }
        public string SaslUsername { get; set; }
        public string SaslPassword { get; set; }
        public string GroupId { get; set; }
    }
    public class Topics
    {
        public string TestTopic { get; set; }
    }

    public class OktaSecret
    {
        public string Issuer { get; set; }
    }

    public class Ldap
    {
        public string Path { get; set; }
    }

    public class Hangfire
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string SchemaName { get; set; }
        public bool Enable { get; set; }
    }

    public class PispngUrl
    {
        public string Url { get; set; }
    }
    public class ProtalUrl
    {
        public string Url { get; set; }
    }
    public class MetalUrl
    {
        public string Url { get; set; }
        public string Token { get; set; }
    }

    public class CpcUrl
    {
        public string Url { get; set; }
    }
    public class PispMobileUrl
    {
        public string Url { get; set; }
    }
    public class RedisConfig
    {
        public string NameSpace { get; set; }
        public int DB { get; set; }
        public string RealTimeKeyPattern { get; set; }
        public string AlarmKeyPattern { get; set; }
    }
}
