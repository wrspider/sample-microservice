using Microsoft.Extensions.Configuration;

using Service.Helper;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
IConfiguration _configuration = builder.Configuration;
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.RegisterConsul(_configuration, app.Lifetime);
app.UseHttpsRedirection();

app.UseAuthentication();
//app.UseAuthorization();

app.MapControllers();

app.Run();
