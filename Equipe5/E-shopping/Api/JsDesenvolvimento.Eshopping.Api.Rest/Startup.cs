using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Autofac;
using Autofac.Extensions;
using Autofac.Extensions.DependencyInjection;
using JsDesenvolvimento.Eshopping.Api.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using JsDesenvolvimento.Eshopping.Api.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using JsDesenvolvimento.Eshopping.Api.Authentication.Impl;
using MediatR;
using Microsoft.AspNetCore.Http;
using JsDesenvolvimento.Eshopping.Api.Authentication.Model;

namespace JsDesenvolvimento.Eshopping.Api.Rest
{
    public class Startup
    {
        private AppSettings _appSettings;

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;

            _appSettings = new AppSettings();
            configuration.GetSection(AppSettings.SectionName).Bind(_appSettings);
        }

        public IConfiguration Configuration { get; }

        public ILifetimeScope AutofacContainer { get; private set; }

        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            // Add services to the collection
            services.AddOptions();
            services.AddMediatR(typeof(Startup).Assembly);
            
            services.AddMvc(config =>
            {
                var policy = new AuthorizationPolicyBuilder()
                                .RequireAuthenticatedUser()
                                .Build();
                config.Filters.Add(new AuthorizeFilter(policy));
            }).SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddCors(o => o.AddPolicy("MyPolicy", policy =>
            {
                policy.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            }));

            services.AddAuthenticationConfig(Configuration);
            services.AddSingleton<IAuthenticateService>(a => new DefaultAuthenticateService(a.GetRequiredService<IConfiguration>()));

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IUserRef>(a => new UsuarioAplicacao(a.GetRequiredService<IHttpContextAccessor>()));

            // Create a container-builder and register dependencies
            var builder = new ContainerBuilder();

            // Populate the service-descriptors added to `IServiceCollection`
            // BEFORE you add things to Autofac so that the Autofac
            // registrations can override stuff in the `IServiceCollection`
            // as needed
            builder.Populate(services);

            ConfigureContainer(builder);

            AutofacContainer = builder.Build();

            // this will be used as the service-provider for the application!
            return new AutofacServiceProvider(AutofacContainer);
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            // Mediator itself
            builder
                .RegisterType<Mediator>()
                .As<IMediator>()
                .InstancePerLifetimeScope();

            // request & notification handlers
            builder.Register<ServiceFactory>(context =>
            {
                var c = context.Resolve<IComponentContext>();
                return t => c.Resolve(t);
            });

            builder.RegistrarAutofacModulos();
            builder.ConfigurarProviderBanco(_appSettings);
        }
        
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseAuthentication();
            app.UseCors("MyPolicy");
            app.UseMvc();
            app.UseHttpsRedirection();
        }
    }
}
