using DapperExtensions;
using JsDesenvolvimento.Data;
using JsDesenvolvimento.Eshopping.Api.Data.Loja;
using JsDesenvolvimento.Eshopping.Api.Data.Loja.DBModel;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace JsDesenvolvimento.Eshopping.Api.Logic.Loja.Query
{
    public class GetProdutoImagensQueryHandler : IRequestHandler<GetProdutoImagensQuery, IEnumerable<ImagemProduto>>
    {
        private IDbConnectionFactory DbConnectionFactory { get; set; }
        private IDbContextFactory DbContextFactory { get; set; }

        public GetProdutoImagensQueryHandler(IDbConnectionFactory dbConnectionFactory, IDbContextFactory contextFactory)
        {
            this.DbConnectionFactory = dbConnectionFactory;
            this.DbContextFactory = contextFactory;
        }

        public Task<IEnumerable<ImagemProduto>> Handle(GetProdutoImagensQuery request, CancellationToken cancellationToken)
        {
            using (var ctx = this.DbContextFactory.NewContext())
            {
                var repo = ctx.AcquireRepository<IImagemProdutoRepository>();

                IPredicateGroup filtros = Predicates.Group(GroupOperator.And,
                     Predicates.Field<ImagemProduto>(a => a.idpropietario, Operator.Eq, request.UserRef.Loja.Propietario)
                    , Predicates.Field<ImagemProduto>(a => a.idloja, Operator.Eq, request.UserRef.Loja.Loja)
                    , Predicates.Field<ImagemProduto>(a => a.idproduto, Operator.Eq, request.Filters.idproduto)
                    , Predicates.Field<ImagemProduto>(a => a.situacao, Operator.Eq, "A")
                );

                var produtos = repo.Fetch(filtros, cancellationToken).Result;
                return Task.FromResult<IEnumerable<ImagemProduto>>(produtos);
            }
        }
    }
}
