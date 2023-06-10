using Microsoft.AspNetCore.Mvc;
using Serilog;
using WebAPI.Loging;

var builder = WebApplication.CreateBuilder(args);
builder.Host.UseSerilog();




Log.Logger = new LoggerConfiguration()
	.WriteTo.Debug(Serilog.Events.LogEventLevel.Information)
	.WriteTo.File("Logs.txt")
	.CreateLogger();

// Add services to the container.




builder.Services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
builder.Services.AddStackExchangeRedisCache(redis =>
{
	redis.Configuration = "127.0.0.1:6379";
});



builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddLogging(i =>
{
	i.ClearProviders();
	i.SetMinimumLevel(LogLevel.Information);

	i.AddProvider(new MyCustomLoggerFactory());
});



builder.Services.AddMemoryCache();
builder.Services.AddAutoMapper(typeof(Program));

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
