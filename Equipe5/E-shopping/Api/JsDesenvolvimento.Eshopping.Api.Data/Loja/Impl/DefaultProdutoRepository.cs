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
using JsDesenvolvimento.Eshopping.Api.Data.Loja.Model;
using DapperExtensions.Mapper;

namespace JsDesenvolvimento.Eshopping.Api.Data.Loja.Impl
{
    public class DefaultProdutoRepository : AbstractDefaultRepository<DBModel.Produto>, IProdutoRepository
    {
        private readonly ISqlGenerator SqlGenerator;

        public DefaultProdutoRepository(ISqlGenerator sqlGenerator)
        {
            this.SqlGenerator = sqlGenerator;
        }

        public override Task<IList<Produto>> Fetch(IPredicate predicate, CancellationToken cancellationToken)
        {
            return Task.Factory.StartNew<IList<Produto>>(() =>
            {
                string sql = $@"SELECT idproduto
	                                    ,idloja
                                        ,idpropietario
                                        ,idcategoria
                                        ,nome
                                        ,descricao
                                        ,precounitario
                                        ,situacao
                                    FROM produto";
                IDictionary<string, object> parametros = new Dictionary<string, object>();
                string predicado = predicate.GetSql(this.SqlGenerator, parametros);

                string sqlMontado = $@"{sql}
                   {(!string.IsNullOrEmpty(predicado) ? "WHERE " + predicado : "")}";

                return this.AttachedContext.InnerConnection.Query<Produto>(sqlMontado,
                                                                    param: parametros,
                                                                    transaction: this.AttachedContext.InnerTransaction).ToList();
            });
        }

        public Task<IList<ProdutoDto>> FetchDto(IPredicate predicate, CancellationToken cancellationToken)
        {
            return Task.Factory.StartNew<IList<ProdutoDto>>(() =>
            {
                string sql = $@"SELECT idproduto, 
                                        idloja,
                                        idpropietario,
                                        idcategoria,
                                        nome,
                                        descricao,
                                        precounitario,
                                        datacadastro,
                                        situacao,
                                        marca,
                                        (SELECT ima.caminhodiretorio
                                           FROM produto_imagem ima
                                          WHERE ima.idproduto = produto.idproduto
                                            AND ima.idloja = produto.idloja
                                            AND ima.idpropietario = produto.idpropietario
                                            AND ima.imagemprincipal = 'S'
                                          limit 1) imagem
                                    FROM produto";
                IDictionary<string, object> parametros = new Dictionary<string, object>();
                string predicado = predicate.GetSql(this.SqlGenerator, parametros);

                string sqlMontado = $@"{sql}
                   {(!string.IsNullOrEmpty(predicado) ? "WHERE " + predicado : "")}";

                return this.AttachedContext.InnerConnection.Query<ProdutoDto>(sqlMontado,
                                                                    param: parametros,
                                                                    transaction: this.AttachedContext.InnerTransaction).ToList();
            });
        }
    }

    public class teste : IClassMapper
    {
        public string SchemaName => throw new NotImplementedException();

        public string TableName => throw new NotImplementedException();

        public IList<IPropertyMap> Properties => throw new NotImplementedException();

        public Type EntityType => throw new NotImplementedException();
    }
}
