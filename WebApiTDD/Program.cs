using WebApiTDD.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//void ConfigureServices(IServiceCollection services)
//{
//    services.AddTransient<IUsersService, UsersService>();
//}
//ConfigureServices(builder.Services);
// Uso del Dependency Injection
var services = builder.Services;
services.AddTransient<IUsersService, UsersService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
