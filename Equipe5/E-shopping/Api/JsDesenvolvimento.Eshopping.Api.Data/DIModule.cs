using Autofac;
using Autofac.Core;
using Autofac.Core.Registration;
using JsDesenvolvimento.Data.Repository;
using JsDesenvolvimento.Eshopping.Api.Data.DBModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace JsDesenvolvimento.Eshopping.Api.Data
{
    public class DIModule : Autofac.Module
    {
        protected override void Load(Autofac.ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(this.ThisAssembly)
                .AsClosedTypesOf(typeof(IDefaultRepository<>))
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();
        }
    }
}
