using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Converters;
using ToolPedia.Api.Middleware;

namespace ToolPedia.Api
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApiServices(
            this IServiceCollection services,
            IConfiguration configuration
        )
        {
            services
                .AddControllers()
                .AddNewtonsoftJson(options =>
                {
                    options.SerializerSettings.NullValueHandling = Newtonsoft
                        .Json
                        .NullValueHandling
                        .Ignore;
                    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft
                        .Json
                        .ReferenceLoopHandling
                        .Ignore;
                    options.SerializerSettings.Converters.Add(new StringEnumConverter());
                });

            services.Configure<RouteOptions>(options => options.LowercaseUrls = true);
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            var jwtSettings = configuration.GetSection("JwtSettings");
            var key = Encoding.UTF8.GetBytes(jwtSettings["Secret"]);
            var sha256 = SHA256.Create();
            var hashedBytes = sha256.ComputeHash(key);

            services
                .AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = jwtSettings["Issuer"],
                        ValidAudience = jwtSettings["Audience"],
                        IssuerSigningKey = new SymmetricSecurityKey(hashedBytes)
                    };
                });

            services.AddAuthorization();

            services.AddTransient<ErrorHandlingMiddleware>();

            // Inside ConfigureServices method
            services.AddCors(options =>
            {
                options.AddPolicy(
                    "AllowFrontend",
                    builder =>
                    {
                        builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
                    }
                );
            });

            services.AddSwaggerGen();

            return services;
        }
    }
}
