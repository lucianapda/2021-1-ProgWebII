using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JsDesenvolvimento.Eshopping.Api.Rest
{
    public static class Infraestrutura
    {
        public static void RegistrarAutofacModulos(this ContainerBuilder builder)
        {
            builder.RegisterModule(new Data.DIModule());
            builder.RegisterModule(new Logic.DIModule());
        }

        public static void AddAutofac(this IServiceCollection services)
        {
            services.AddSingleton<IServiceProviderFactory<ContainerBuilder>>(new AutofacServiceProviderFactory());
        }
    }
}
