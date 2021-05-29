using DapperExtensions;
using JsDesenvolvimento.Data;
using JsDesenvolvimento.Eshopping.Api.Data.Pessoa;
using JsDesenvolvimento.Eshopping.Api.Data.Pessoa.DBModel;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace JsDesenvolvimento.Eshopping.Api.Logic.Pessoa.Query
{
    public class GetEnderecosCompradorQueryHandler : IRequestHandler<GetEnderecosCompradorQuery, IList<PessoaEndereco>>
    {
        private IDbConnectionFactory DbConnectionFactory { get; set; }
        private IDbContextFactory DbContextFactory { get; set; }

        public GetEnderecosCompradorQueryHandler(IDbConnectionFactory dbConnectionFactory, IDbContextFactory contextFactory)
        {
            this.DbConnectionFactory = dbConnectionFactory;
            this.DbContextFactory = contextFactory;
        }

        public Task<IList<PessoaEndereco>> Handle(GetEnderecosCompradorQuery request, CancellationToken cancellationToken)
        {
            using (var ctx = this.DbContextFactory.NewContext())
            {
                var repo = ctx.AcquireRepository<IPessoaEnderecoRepository>();

                IPredicateGroup filtros = Predicates.Group(GroupOperator.And,
                     Predicates.Field<PessoaEndereco>(a => a.idpessoa, Operator.Eq, request.Pessoa.idpessoa)
                );

                var enderecos = repo.Fetch(filtros, cancellationToken).Result;
                return Task.FromResult<IList<PessoaEndereco>>(enderecos);
            }
        }
    }
}
