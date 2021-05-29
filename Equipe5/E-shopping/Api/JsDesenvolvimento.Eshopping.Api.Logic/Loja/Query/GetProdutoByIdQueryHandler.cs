using DapperExtensions;
using JsDesenvolvimento.Data;
using JsDesenvolvimento.Eshopping.Api.Data.Loja;
using JsDesenvolvimento.Eshopping.Api.Data.Loja.Model;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;


namespace JsDesenvolvimento.Eshopping.Api.Logic.Loja.Query
{
    public class GetProdutoByIdQueryHandler : IRequestHandler<GetProdutoByIdQuery, ProdutoDto>
    {
        private IDbConnectionFactory DbConnectionFactory { get; set; }
        private IDbContextFactory DbContextFactory { get; set; }

        public GetProdutoByIdQueryHandler(IDbConnectionFactory dbConnectionFactory, IDbContextFactory contextFactory)
        {
            this.DbConnectionFactory = dbConnectionFactory;
            this.DbContextFactory = contextFactory;
        }

        public Task<ProdutoDto> Handle(GetProdutoByIdQuery request, CancellationToken cancellationToken)
        {
            using (var ctx = this.DbContextFactory.NewContext())
            {
                var repo = ctx.AcquireRepository<IProdutoRepository>();

                IPredicateGroup filtros = Predicates.Group(GroupOperator.And,
                     Predicates.Field<ProdutoDto>(a => a.idpropietario, Operator.Eq, request.User.Loja.Propietario)
                    , Predicates.Field<ProdutoDto>(a => a.idloja, Operator.Eq, request.User.Loja.Loja)
                    , Predicates.Field<ProdutoDto>(a => a.idproduto, Operator.Eq, request.Filters.idproduto)                    
                );

                var produtos = repo.FetchDto(filtros, cancellationToken).Result;
                return Task.FromResult<ProdutoDto>(produtos.First());
            }
        }
    }
}
