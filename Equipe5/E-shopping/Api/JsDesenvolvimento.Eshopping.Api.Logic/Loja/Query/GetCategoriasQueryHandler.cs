using DapperExtensions;
using JsDesenvolvimento.Data;
using JsDesenvolvimento.Eshopping.Api.Data.Loja;
using JsDesenvolvimento.Eshopping.Api.Data.Loja.DBModel;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace JsDesenvolvimento.Eshopping.Api.Logic.Loja.Query
{
    public class GetCategoriasQueryHandler : IRequestHandler<GetCategoriasQuery, IEnumerable<Categoria>>
    {
        private IDbConnectionFactory DbConnectionFactory { get; set; }
        private IDbContextFactory DbContextFactory { get; set; }

        public GetCategoriasQueryHandler(IDbConnectionFactory dbConnectionFactory, IDbContextFactory contextFactory)
        {
            this.DbConnectionFactory = dbConnectionFactory;
            this.DbContextFactory = contextFactory;
        }

        public Task<IEnumerable<Categoria>> Handle(GetCategoriasQuery request, CancellationToken cancellationToken)
        {
            using (var ctx = this.DbContextFactory.NewContext())
            {
                var repo = ctx.AcquireRepository<ICategoriaRepository>();

                IPredicateGroup filtros = Predicates.Group(GroupOperator.And,
                     Predicates.Field<Produto>(a => a.idpropietario, Operator.Eq, request.User.Loja.Propietario)
                    , Predicates.Field<Produto>(a => a.idloja, Operator.Eq, request.User.Loja.Loja)
                    , Predicates.Field<Produto>(a => a.situacao, Operator.Eq, "A")
                );

                var categorias = repo.Fetch(filtros, cancellationToken).Result;
                return Task.FromResult<IEnumerable<Categoria>>(categorias);
            }
        }
    }
}
