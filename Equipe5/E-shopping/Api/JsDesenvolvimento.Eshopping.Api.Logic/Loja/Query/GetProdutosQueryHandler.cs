using DapperExtensions;
using JsDesenvolvimento.Data;
using JsDesenvolvimento.Eshopping.Api.Data.Loja;
using JsDesenvolvimento.Eshopping.Api.Data.Loja.DBModel;
using MediatR;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using JsDesenvolvimento.Eshopping.Api.Data.Loja.Model;

namespace JsDesenvolvimento.Eshopping.Api.Logic.Loja.Query
{
    public class GetProdutosQueryHandler : IRequestHandler<GetProdutosQuery, IEnumerable<ProdutoDto>>
    {
        private IDbConnectionFactory DbConnectionFactory { get; set; }
        private IDbContextFactory DbContextFactory { get; set; }

        public GetProdutosQueryHandler(IDbConnectionFactory dbConnectionFactory, IDbContextFactory contextFactory)
        {
            this.DbConnectionFactory = dbConnectionFactory;
            this.DbContextFactory = contextFactory;
        }

        public Task<IEnumerable<ProdutoDto>> Handle(GetProdutosQuery request, CancellationToken cancellationToken)
        {
            using(var ctx = this.DbContextFactory.NewContext())
            {
                var repo = ctx.AcquireRepository<IProdutoRepository>();

                IPredicateGroup filtros = Predicates.Group(GroupOperator.And,
                     Predicates.Field<ProdutoDto>(a => a.idpropietario, Operator.Eq, request.User.Loja.Propietario)
                    , Predicates.Field<ProdutoDto>(a => a.idloja, Operator.Eq, request.User.Loja.Loja)
                    , Predicates.Field<ProdutoDto>(a => a.situacao, Operator.Eq, "A")
                );

                var produtos = repo.FetchDto(filtros, cancellationToken).Result;
                return Task.FromResult<IEnumerable<ProdutoDto>>(produtos);
            }
        }
    }
}
