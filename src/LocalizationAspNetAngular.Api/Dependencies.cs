using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace LocalizationAspNetAngular.Api
{
    public static class Dependencies
    {
        public static void Configure(IServiceCollection services, IConfiguration configuration)
        {
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Localization using Asp.Net and Angular",
                    Description = "Localization using Asp.Net and Angular",
                    TermsOfService = new Uri("https://example.com/terms"),
                    Contact = new OpenApiContact
                    {
                        Name = "Quinntyne Brown",
                        Email = "quinntynebrown@gmail.com"
                    },
                    License = new OpenApiLicense
                    {
                        Name = "Use under MIT",
                        Url = new Uri("https://opensource.org/licenses/MIT"),
                    }
                });

                options.CustomSchemaIds(x => x.FullName);
            });

            services.AddCors(options => options.AddPolicy("CorsPolicy",
                builder => builder
                .WithOrigins("http://localhost:4200")
                .AllowAnyMethod()
                .AllowAnyHeader()
                .SetIsOriginAllowed(isOriginAllowed: _ => true)
                .AllowCredentials()));

            services.AddHttpContextAccessor();

            services.AddMediatR(typeof(Startup));

            services.AddControllers();

            services.AddLocalization();

            services.Configure<RequestLocalizationOptions>( options =>
            {
                var supportedCultures = new List<CultureInfo>
                {
                    new CultureInfo("en-CA"),
                    new CultureInfo("fr-CA")
                };

                options.DefaultRequestCulture = new RequestCulture(culture: "en-CA", uiCulture: "en-CA");
                options.SupportedCultures = supportedCultures;
                options.SupportedUICultures = supportedCultures;
            });
        }
    }
}
