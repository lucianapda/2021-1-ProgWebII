using DapperExtensions;
using DapperExtensions.Sql;
using JsDesenvolvimento.Data.Repository.Impl;
using JsDesenvolvimento.Eshopping.Api.Data.Loja.DBModel;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Dapper;

namespace JsDesenvolvimento.Eshopping.Api.Data.Loja.Impl
{
    public class DefaultCategoriaRepository : AbstractDefaultRepository<DBModel.Categoria>, ICategoriaRepository
    {
        public DefaultCategoriaRepository(ISqlGenerator sqlGenerator)
        {
            SqlGenerator = sqlGenerator;
        }

        public ISqlGenerator SqlGenerator { get; }

        public override Task<IList<Categoria>> Fetch(IPredicate predicate, CancellationToken cancellationToken)
        {
            return Task.Factory.StartNew<IList<Categoria>>(() =>
            {
                string sql = $@"SELECT idcategoria, idloja, idpropietario, nome, descricao, situacao
	                              FROM categoria";
                IDictionary<string, object> parametros = new Dictionary<string, object>();
                string predicado = predicate.GetSql(this.SqlGenerator, parametros);

                string sqlMontado = $@"{sql}
                   {(!string.IsNullOrEmpty(predicado) ? "WHERE " + predicado : "")}";

                return this.AttachedContext.InnerConnection.Query<Categoria>(sqlMontado,
                                                                    param: parametros,
                                                                    transaction: this.AttachedContext.InnerTransaction).ToList();
            });
        }
    }
}
