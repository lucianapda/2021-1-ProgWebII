using Autofac;
using Autofac.Core;
using Dapper;
using DapperExtensions.Mapper;
using JsDesenvolvimento.Data;
using JsDesenvolvimento.Data.Common.Impl;
using JsDesenvolvimento.Data.Postgresql.Impl;
using JsDesenvolvimento.Eshopping.Api.Data;
using JsDesenvolvimento.Eshopping.Api.Data.Infraestructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JsDesenvolvimento.Eshopping.Api.Rest
{
    public static class DbInfraestrutura
    {
        private static DapperExtensions.Sql.ISqlDialect GetDialeto()
        {
            return new DapperExtensions.Sql.PostgreSqlDialect();
        }

        public static void ConfigurarProviderBanco(this ContainerBuilder builder, AppSettings appSettings)
        {
            DapperExtensions.DapperExtensions.ClearCache();
            DapperExtensions.Sql.ISqlDialect sqlDialect = GetDialeto();

            DapperExtensions.IDapperExtensionsConfiguration config = new DapperExtensions.DapperExtensionsConfiguration(
                typeof(AutoClassMapper<>),
                new[]
                {
                    typeof(Data.DBModel.ModuloCliente).Assembly,
                    typeof(Data.DBModel.ModuloLoja).Assembly,
                },
                GetDialeto()
            );
            DapperExtensions.DapperExtensions.Configure(config);
            
            SqlMapper.RemoveTypeMap(typeof(bool));
            SqlMapper.AddTypeHandler(typeof(bool), new BoolSqlMapper());

            builder.Register<DapperExtensions.Sql.ISqlGenerator>(a => new DapperExtensions.Sql.SqlGeneratorImpl(config));

            builder.Register<IDbProvider>(ctx => new DefaultPostgresqlDbProvider(appSettings.DBProviderFactory)).AsImplementedInterfaces().SingleInstance();
            //Conexão com banco
            builder.Register<IDbConnectionFactory>(ctx => new DefaultConnectionFactory(ctx.Resolve<IDbProvider>(), appSettings.ConnectionString)).AsImplementedInterfaces();

            builder.Register<IDbContextFactory>(ctx => new DefaultContextFactory<DefaultDbContext>(ctx.Resolve<IServiceProvider>(), ctx.Resolve<IDbConnectionFactory>())).AsImplementedInterfaces();
        }
    }
}
