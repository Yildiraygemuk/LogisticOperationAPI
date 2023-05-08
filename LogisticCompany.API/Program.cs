using Autofac;
using Autofac.Extensions.DependencyInjection;
using LogisticCompany.Business.DependencyResolvers.Autofac;
using LogisticCompany.Core.CrossCuttingConcerns.Logging.SeriLog;
using LogisticCompany.Core.Helpers;
using LogisticCompany.Core.Middleware;
using LogisticCompany.Core.Utilities.IoC;
using LogisticCompany.Core.Utilities.Security.Encryption;
using LogisticCompany.Core.Utilities.Security.Jwt;
using LogisticCompany.DataAccess.Concrete.Contexts;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<LogisticContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("LogisticDb")));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

var assemblies = AppDomain.CurrentDomain.GetAssemblies().ToList();
var assembly = Assembly.Load("LogisticCompany.Business");
assemblies.Add(assembly);

builder.Services.AddAutoMapper(assemblies.ToArray());


builder.Services.AddHttpClient();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddSingleton<IJwtHelper, JwtHelper>();
builder.Services.AddSingleton<ISeriLogService, SerilogService>();
builder.Services.AddSingleton<IMemoryCache, MemoryCache>();
builder.Services.TryAddSingleton<IHttpAccessorHelper, HttpAccessorHelper>();

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory())
    .ConfigureContainer<ContainerBuilder>(builder =>
    {
        builder.RegisterModule(new AutofacBusinessModule());

    });

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "XOOI API", Version = "v1" });
    // Swagger UI için JWT kimlik doðrulama eklentisi yapýlandýrmasý
    var securityScheme = new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Description = "JWT Authorization header using the Bearer scheme (Example: 'Bearer 12345abcdef')",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "bearer",
        BearerFormat = "JWT",
        Reference = new OpenApiReference
        {
            Type = ReferenceType.SecurityScheme,
            Id = "Bearer"
        }
    };

    c.AddSecurityDefinition("Bearer", securityScheme);

    var securityRequirement = new OpenApiSecurityRequirement
            {
                { securityScheme, new[] { "Bearer" } }
            };

    c.AddSecurityRequirement(securityRequirement);
});

builder.Services.AddSwaggerGen();

var tokenOptions = builder.Configuration.GetSection("TokenOptions").Get<TokenOptions>();


builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
 .AddJwtBearer(options =>
 {
     options.TokenValidationParameters = new TokenValidationParameters
     {
         ValidateIssuer = true,
         ValidateAudience = true,
         ValidateLifetime = true,
         ValidIssuer = tokenOptions.Issuer,
         ValidAudience = tokenOptions.Audience,
         ValidateIssuerSigningKey = true,
         IssuerSigningKey = SecurityKeyHelper.CreateSecurityKey(tokenOptions.SecurityKey),
         ClockSkew = TimeSpan.Zero
     };
 });
var app = builder.Build();


ServiceTool.Create(null, app.Services);
// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();
app.UseMiddleware<JwtMiddleware>();

app.UseAuthentication();
app.UseAuthorization();


app.MapControllers();

app.Run();
