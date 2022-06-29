using EFaturaTakip.API.Filters;
using EFaturaTakip.API.Middlewares;
using EFaturaTakip.API.UyumSoft;
using EFaturaTakip.Business.Abstract;
using EFaturaTakip.Business.Concrete;
using EFaturaTakip.Common.EMail;
using EFaturaTakip.DataAccess.Abstract;
using EFaturaTakip.DataAccess.Concrete;
using EFaturaTakip.Entities;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using System.Reflection;
using System.Text;

namespace EFaturaTakip.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(options =>
            {
                options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
                {
                    Description = "Standard Authorization header using the Bearer scheme (\"bearer {token}\")",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                });

                options.OperationFilter<SecurityRequirementsOperationFilter>();
            });
            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
             {
                 options.TokenValidationParameters = new TokenValidationParameters
                 {
                     ValidateIssuerSigningKey = true,
                     IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8
                         .GetBytes(builder.Configuration.GetSection("AppSettings:Token").Value)),
                     ValidateIssuer = false,
                     ValidateAudience = false,
                     RequireExpirationTime = true,
                     ValidateLifetime = true,
                 };
             });
            builder.Services.AddDbContext<EFaturaTakipContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("DbEFaturaTakip")));
            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            var uiOriginUrl = builder.Configuration.GetSection("AppSettings:UIOriginUrl").Value;
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("eFaturaTakipOrigin", builder =>
                {
                    builder.WithOrigins(uiOriginUrl).AllowAnyHeader().AllowAnyMethod();
                });
            });


            builder.Services.AddControllers().AddFluentValidation(options =>
            {
                options.ImplicitlyValidateChildProperties = true;
                options.ImplicitlyValidateRootCollectionElements = true;
                options.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            });

            builder.Services.AddScoped<ValidationFilter>();
            builder.Services.Configure<ApiBehaviorOptions>(options
                => options.SuppressModelStateInvalidFilter = true);
            builder.Services.AddHttpClient("UyumSoftClient", config =>
            {
                config.BaseAddress = new Uri(builder.Configuration.GetSection("UyumSoft:BaseUrl").Value);
            });
            builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            builder.Services.AddScoped<UyumSoftClient>();
            builder.Services.AddTransient<IUserManager, UserManager>();
            builder.Services.AddTransient<IUserDao, UserDao>();
            builder.Services.AddTransient<IRoleManager, RoleManager>();
            builder.Services.AddTransient<IRoleDao, RoleDao>();
            builder.Services.AddTransient<IStockManager, StockManager>();
            builder.Services.AddTransient<IStockDao, StockDao>();

            var emailConfig = builder.Configuration
             .GetSection("EmailConfiguration")
             .Get<EmailConfiguration>();
            builder.Services.AddSingleton(emailConfig);
            builder.Services.AddScoped<IEMailSender, EMailSender>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseCors("eFaturaTakipOrigin");

            app.UseAuthentication();

            app.UseAuthorization();

            app.MapControllers();

            app.UseMiddleware<ErrorHandlerMiddleware>();

            app.Run();
        }
    }
}