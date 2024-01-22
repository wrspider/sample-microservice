using SecurityServer;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddIdentityServer()
    .AddInMemoryClients(Id4Config.Clients)
    .AddInMemoryIdentityResources(Id4Config.IdentityResources)
    .AddInMemoryApiResources(Id4Config.ApiResources)
    .AddInMemoryApiScopes(Id4Config.ApiScopes)//访问的返回
     .AddTestUsers(Id4Config.GetTestUsers())
    .AddDeveloperSigningCredential();



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

app.Run();
