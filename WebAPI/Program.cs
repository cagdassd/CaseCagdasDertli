




using Microsoft.Extensions.Caching.Memory;
using Serilog;
using WebAPI.Caching;
using WebAPI.Caching.Microsoft;
using WebAPI.Loging;

var builder = WebApplication.CreateBuilder(args);


builder.Host.UseSerilog();
Log.Logger = new LoggerConfiguration()
	.WriteTo.Debug(Serilog.Events.LogEventLevel.Information)
	.CreateLogger();

// Add services to the container.

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
//builder.Services.AddMemoryCache();
//builder.Services.AddSingleton<IMemoryCache, MemoryCache>();




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
