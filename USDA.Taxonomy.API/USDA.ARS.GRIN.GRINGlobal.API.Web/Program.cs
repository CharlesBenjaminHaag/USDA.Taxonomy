using USDA.ARS.GRIN.GRINGlobal.API.Data;
using USDA.ARS.GRIN.GRINGlobal.API.Data.Models;
using USDA.ARS.GRIN.GRINGlobal.API.Web;
using Microsoft.EntityFrameworkCore;
using USDA.ARS.GRIN.GRINGlobal.API.Web.Services;
using Serilog;

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Debug()
    .WriteTo.File("logs/USDA.ARS.GRIN.GRINGlobal.API.txt", rollingInterval: RollingInterval.Day)
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

builder.Services.AddDbContext<gringlobalContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("GRINGlobalConnectionString")).EnableSensitiveDataLogging().UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking));

builder.Services.AddScoped<ISpeciesRepository, SpeciesRepository>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}
//else
//{
//}

app.UseSwagger();
app.UseSwaggerUI();
app.UseHsts();

app.UseHttpsRedirection();

app.UseRouting();

app.UseCors(MyAllowSpecificOrigins);

//app.UseAuthorization();

app.UseEndpoints(endpoints => { endpoints.MapControllers(); });

app.Run();
