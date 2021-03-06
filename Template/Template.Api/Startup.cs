﻿using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerUI;
using Template.Api.Configuration;

namespace Template.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            ConfigureCors(services);
            ConfigureMvc(services);
            ConfigureSwagger(services);
            services
                .AddPatterns()
                .AddServicesAndRepositories();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            ConfigureMvc(app, env);
            ConfigureCors(app);
            ConfigureSwagger(app);
        }

        #region Mvc

        private static void ConfigureMvc(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        private static void ConfigureMvc(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseMvc();
        }

        #endregion

        #region Cors

        private static void ConfigureCors(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(
                    "AllowSpecificOrigin",
                    builder => builder.WithOrigins("http://localhost:4200")
                        .AllowAnyMethod()
                        .AllowAnyHeader().AllowCredentials());
            });
        }

        private static void ConfigureCors(IApplicationBuilder application)
        {
            application.UseCors("AllowSpecificOrigin");
        }

        #endregion

        #region Swagger

        private static void ConfigureSwagger(IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new Info {Title = $"{nameof(Template)} API", Version = "v1"});
                options.IncludeXmlComments($@"{AppDomain.CurrentDomain.BaseDirectory}{nameof(Template)}.Api.xml");
                options.DescribeAllEnumsAsStrings();
            });
        }

        private static void ConfigureSwagger(IApplicationBuilder application)
        {
            application
                .UseSwagger()
                .UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Template API v1");
                    c.DocExpansion(DocExpansion.None);
                    c.RoutePrefix = string.Empty;
                    c.DisplayRequestDuration();
                });
        }

        #endregion
    }
}