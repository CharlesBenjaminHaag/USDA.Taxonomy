using Microsoft.EntityFrameworkCore;
using Serilog;
using USDA.ARS.GRINGlobal.Data.Models;
using USDA.ARS.GRINGlobal.Domain.Services;

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Debug()
    .WriteTo.File("logs/USDA.ARS.GRINGlobal.API.txt", rollingInterval: RollingInterval.Day)
    .CreateLogger();

var MyAllowSpecificOrigins = "DefaultPolicy";

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
        policy =>
        {
            policy.AllowAnyOrigin();
            policy.AllowAnyMethod();
            policy.AllowAnyHeader();
        });
});

builder.Host.UseSerilog();

builder.Services.AddControllers(options =>
{
    options.ReturnHttpNotAcceptable = false;
}).AddNewtonsoftJson()
.AddXmlDataContractSerializerFormatters();

builder.Services.AddProblemDetails();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//builder.Services.AddDbContext<gringlobalContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("GRINGlobalConnectionString")).EnableSensitiveDataLogging().UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking));

builder.Services.AddDbContext<gringlobalContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("GRINGlobalConnectionString"))
           .EnableSensitiveDataLogging() // optional, shows parameter values
           .LogTo(Log.Information, new[] { DbLoggerCategory.Database.Command.Name }, LogLevel.Information);
});

builder.Services.AddScoped<IAccessionRepository, AccessionRepository>();
builder.Services.AddScoped<IAccessionIprRepository, AccessionIprRepository>();
builder.Services.AddScoped<ISiteRepository, SiteRepository>();
builder.Services.AddScoped<ICropGermplasmCommitteeRepository, CropGermplasmCommitteeRepository>();
builder.Services.AddScoped<IRhizobiumRepository, RhizobiumRepository>();
builder.Services.AddScoped<ICodeValueRepository, CodeValueRepository>();
builder.Services.AddScoped<IGeographyRepository, GeographyRepository>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();
app.UseHsts();
app.UseHttpsRedirection();
app.UseRouting();
app.UseCors(MyAllowSpecificOrigins);
app.UseDeveloperExceptionPage();
//app.UseAuthorization();
app.UseEndpoints(endpoints => { endpoints.MapControllers(); });

app.Run();
