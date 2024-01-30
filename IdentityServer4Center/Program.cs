
using Auth;
using Auth.Application;

using IdentityServer4.AspNetIdentity;

using SecurityServer;

using Service.Helper.Dapper;

using static IdentityServer4.Models.IdentityResources;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

#region 添加跨域
//builder.Services.AddCors(options =>
//{
//    options.AddPolicy("CorsPolicy", builder => builder
//        .AllowAnyOrigin()
//        .AllowAnyMethod()
//        .AllowAnyHeader()
//        .AllowCredentials()
//    );
//});
#endregion
builder.Services.AddDapperDbContext(builder.Configuration);
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddIdentityServer()
    .AddInMemoryClients(Id4Config.Clients)
    .AddInMemoryIdentityResources(Id4Config.GetIdentityResources())
    .AddInMemoryApiResources(Id4Config.ApiResources)
    .AddInMemoryApiScopes(Id4Config.ApiScopes)//访问的返回
                                              //.AddTestUsers(Id4Config.GetTestUsers())
    .AddDeveloperSigningCredential()
    .AddResourceOwnerValidator<ResourceOwnerPasswordValidator>()

    .AddProfileService<CustomProfileService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseIdentityServer();
app.UseAuthorization();

app.MapControllers();

app.UseRouting();
//app.Run("http://localhost:5001");
app.Run();
