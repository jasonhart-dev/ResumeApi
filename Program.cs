using Microsoft.Extensions.Options;
using ResumeApi.Services;
using ResumeApi.Middleware;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Reader;
using Serilog;
using ResumeApi.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .Enrich.FromLogContext()
    .Enrich.WithEnvironmentName()
    .Enrich.WithProcessId()
    .Enrich.WithThreadId()
    .WriteTo.Console()
    .WriteTo.File(
        "Logs/log-.txt",
        rollingInterval: Serilog.RollingInterval.Day,
        retainedFileCountLimit: 7)
    .CreateLogger();

builder.Host.UseSerilog();

// Add DbContext
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<IVisitCounterService, VisitCounterService>();
builder.Services.AddScoped<IEmailPersistenceService, EmailPersistenceService>();


// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddRazorPages();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddOpenApi();

builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<IResumeService, ResumeService>();
builder.Services.AddSingleton<IEmailService, EmailService>();
builder.Services.AddApiVersioning(options =>
{
    options.DefaultApiVersion = new ApiVersion(1, 0);
    options.AssumeDefaultVersionWhenUnspecified = true;
    options.ReportApiVersions = true;
});

builder.Services.AddSingleton<IHireMeService, HireMeService>();

builder.Services.AddHttpClient();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseSwagger();
app.UseSwaggerUI();


app.UseMiddleware<GlobalExceptionMiddleware>();
// Customize request logging to avoid duplicate exception stack traces.
// Exceptions are logged centrally by GlobalExceptionMiddleware.
app.UseSerilogRequestLogging(options =>
{
    options.GetLevel = (httpContext, elapsed, ex) =>
    {
        var statusCode = httpContext.Response.StatusCode;
        return statusCode >= 400
            ? Serilog.Events.LogEventLevel.Warning
            : Serilog.Events.LogEventLevel.Information;
    };
});

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.UseAuthorization();

app.MapControllers();
app.MapRazorPages();

app.Run();
