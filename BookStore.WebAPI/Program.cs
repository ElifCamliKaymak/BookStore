using AspNetCoreRateLimit;
using BookStore.Services.Contracts;
using BookStore.WebAPI.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NLog;

var builder = WebApplication.CreateBuilder(args);

LogManager.LoadConfiguration(String.Concat(Directory.GetCurrentDirectory(), "/nlog.config"));
// Add services to the container.

builder.Services.AddControllers(config =>
{
    //accept pazarlýðýna açýklýk için true ya çekildi
    config.SuppressAsyncSuffixInActionNames = true;
    //bir istek geldiðinde dönüþ yapmasý için true ya çevirildi
    config.ReturnHttpNotAcceptable = true;
})
    .AddCustonCvsFormatter()
    //xml formatýnda çýkýþ verilebilmesi için
    .AddXmlDataContractSerializerFormatters()
    .AddApplicationPart(typeof(BookStore.Presentation.AssemblyRefence).Assembly)
    .AddNewtonsoftJson();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.ConfigureSqlContext(builder.Configuration);
builder.Services.ConfigureRepositoryManager();
builder.Services.ConfigureServiceManager();
builder.Services.ConfigureLoggerService();
builder.Services.AddAutoMapper(typeof(Program));

var app = builder.Build();

var logger = app.Services.GetRequiredService<ILoggerService>();
app.ConfigureExceptionHandler(logger);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

if (app.Environment.IsProduction())
{
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
