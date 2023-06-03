




using Autofac;
using Autofac.Core;
using Autofac.Extensions.DependencyInjection;
using Business.DependencyResolvers;
using Core.DependencyResolvers;
using Core.Extensions;
using Core.Utilities.IoC;
using Microsoft.Extensions.Caching.Memory;
using Serilog;
using WebAPI.Loging;

var builder = WebApplication.CreateBuilder(args);

//IoC -- autofac
//builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory())
	//.ConfigureContainer<ContainerBuilder>(builder =>
	//{
		//builder.RegisterModule(new AutofacBusinessModule());
	//});


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
builder.Services.AddMemoryCache();
//builder.Services.AddDependencyResolvers(new ICoreModule[] {
		//	   new CoreModule()
	//		});


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
