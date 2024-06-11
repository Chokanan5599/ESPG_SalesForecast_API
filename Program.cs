using ESPG_SalesForecast_API.Model;
using ESPG_SalesForecast_API.Entity;
using ESPG_SalesForecast_API.Services_Businesslogic;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using ESPG_SalesForecast_API.Helpers;

var builder = WebApplication.CreateBuilder(args);

//*********************** Add services to the container.***********************
builder.Services.AddSingleton<IWeb_SalesForecast_UserPermissionService, Web_SalesForecast_UserPermissionService>();
//*********************** Add services to the container end.***********************

//*********************** Register DbContext and provide ConnectionString .***********************
builder.Services.AddDbContext<TAAX63TEST_DbContext>(db => db.UseSqlServer(builder.Configuration.GetConnectionString("OurHeroConnectionString")), ServiceLifetime.Singleton);
//*********************** Register DbContext end.***********************

builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));
builder.Services.AddScoped<IWeb_SalesForecast_UserPermissionService, Web_SalesForecast_UserPermissionService>();
// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSwaggerGen(swagger =>
{
    //This is to generate the Default UI of Swagger Documentation
    swagger.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "JWT Token Authentication API",
        Description = ".NET 8 Web API"
    });
    // To Enable authorization using Swagger (JWT)
    swagger.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 12345abcdef\"",
    });
    swagger.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                          new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = "Bearer"
                                }
                            },
                            new string[] {}

                    }
                });
});
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAnyOrigin", builder =>
    {
        // Allow "Access-Control-Allow-Origin: *"
        builder.AllowAnyOrigin();
        // Allow "Access-Control-Allow-Header: *"
        builder.AllowAnyHeader();

        builder.AllowAnyMethod();

    });
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseCors("AllowAnyOrigin");//Allow "Access-Control-Allow-Origin: *
    app.UseCors("AllowAnyHeader");//Allow "Access-Control-Allow-Header: *
    app.UseCors("AllowAnyMethod");//Allow "Access-Control-Allow-Header: *
}
app.UseMiddleware<JwtMiddleware>();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
