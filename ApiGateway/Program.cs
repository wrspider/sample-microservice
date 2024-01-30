using IdentityServer4.AccessTokenValidation;



using Microsoft.AspNetCore.Authentication.JwtBearer;

using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using Ocelot.Provider.Consul;

using SecurityServer;

using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Configuration.AddJsonFile("ocelot.json", optional: false, reloadOnChange: true);

JWTTokenOptions tokenOptions = new JWTTokenOptions();
builder.Configuration.Bind("JWTTokenOptions", tokenOptions);


// 添加跨域
builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", builder => builder
        .AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader()
        .AllowCredentials()
    );
});

//.AddJwtBearer("APIKey_1", options =>
//{
//    options.Authority = "http://localhost:5055";//id4服務地址
//    options.TokenValidationParameters = new TokenValidationParameters
//    {
//        ValidateAudience = false
//    };
//    options.RequireHttpsMetadata = false;

//}).AddIdentityServerAuthentication("APIKey_2", options =>
//{
//    options.Authority = tokenOptions.Audience;//id4服務地址
//                                              //options.ApiName = "API_2";//id4 api資源裡的apiname
//    options.RequireHttpsMetadata = false; //不使用https
//    options.SupportedTokens = SupportedTokens.Both;
//});
/// 授权认证
// Webapi中是否设置鉴权声明不重要，这里以网关统一认证来说明，Webapi中不加入任何鉴权代码。
// AddJwtBearer用於保護API，而AddIdentityServerAuthentication用於保護Web應用程序。
//客户端
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)

     .AddJwtBearer("APIKey_1", options =>
     {
         options.RequireHttpsMetadata = false; //不使用https
         options.Authority = tokenOptions.Audience;//id4服務地址
         //options.ForwardDefaultSelector = context => "Introspection";
         options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
         {
             ValidateIssuer = false,//是否验证Issuer
             ValidateAudience = false,//是否验证Audience
             ValidateLifetime = true,//是否验证失效时间---默认还添加了300s后才过期
             ClockSkew = TimeSpan.FromSeconds(0),//token过期后立马过期
             ValidateIssuerSigningKey = false,//是否验证SecurityKey
             ValidAudience = tokenOptions.Audience,//Audience,需要跟前面签发jwt的设置一致
                                                   // ValidIssuer = tokenOptions.Issuer,//Issuer，这两项和前面签发jwt的设置一致

             //IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenOptions.SecurityKey)),//拿到SecurityKey
         };

     }).
     AddIdentityServerAuthentication("APIKey_2", options =>
     {
         options.Authority = tokenOptions.Audience;//id4服務地址
         //options.ApiName = "API_2";//id4 api資源裡的apiname
         options.RequireHttpsMetadata = false; //不使用https
         options.SupportedTokens = SupportedTokens.Both;
     });
// 添加网关
builder.Services.AddOcelot().AddConsul();


var app = builder.Build();
IConfiguration _configuration = builder.Configuration;
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
//注册Consul服务
//app.RegisterConsul(_configuration, app.Lifetime);
//app.UseCors("CorsPolicy");
app.UseHttpsRedirection();

//app.UseAuthorization();
app.UseAuthentication();

app.MapControllers();

app.UseOcelot().Wait();

// Welcome
Console.WriteLine(Welcome());

app.Run();


static string Welcome()
{
    var builder = new StringBuilder();
    builder.AppendLine("Initializing ...");
    builder.AppendLine();
    builder.AppendLine("***************************************************************");
    builder.AppendLine("*                                                             *");
    builder.AppendLine("*                Welcome To ApiGateway                        *");
    builder.AppendLine("*                                                             *");
    builder.AppendLine("***************************************************************");
    return builder.ToString();
}