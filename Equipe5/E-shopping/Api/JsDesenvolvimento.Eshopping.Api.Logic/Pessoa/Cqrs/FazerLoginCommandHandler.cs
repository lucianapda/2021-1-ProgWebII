using DapperExtensions;
using JsDesenvolvimento.Data;
using JsDesenvolvimento.Eshopping.Api.Data.Pessoa;
using JsDesenvolvimento.Eshopping.Api.Logic.Pessoa.Model;
using MediatR;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace JsDesenvolvimento.Eshopping.Api.Logic.Pessoa.Cqrs
{
    public class FazerLoginCommandHandler : IRequestHandler<FazerLoginCommand, FazerLoginCommandResponse>
    {
        private IDbConnectionFactory DbConnectionFactory { get; set; }
        private IDbContextFactory DbContextFactory { get; set; }

        public FazerLoginCommandHandler(IDbConnectionFactory dbConnectionFactory, IDbContextFactory contextFactory)
        {
            this.DbConnectionFactory = dbConnectionFactory;
            this.DbContextFactory = contextFactory;
        }

        public Task<FazerLoginCommandResponse> Handle(FazerLoginCommand request, CancellationToken cancellationToken)
        {
            using (var ctx = this.DbContextFactory.NewContext())
            {
                try
                {
                    var repo = ctx.AcquireRepository<IPessoaRepository>();
                    var infoLogin = request.Informacoes;
                    IPredicate predicado = Predicates.Field<Data.Pessoa.DBModel.Pessoa>(a => a.email, Operator.Eq, infoLogin.Pessoa.email);
                    var pessoa = repo.Fetch(predicado, cancellationToken).Result;

                    if(pessoa.Count > 1)
                    {
                        throw new ArgumentException("Existem mais de um usuário com o mesmo e-mail.");
                    }

                    if (pessoa.Count == 1 && pessoa.First().senha.Equals(infoLogin.Pessoa.senha))
                        return Task.FromResult(new FazerLoginCommandResponse()
                        {
                            idpessoa = pessoa.First().idpessoa,
                            email = pessoa.First().email,
                            autenticado = true
                        });

                    return Task.FromResult(new FazerLoginCommandResponse()
                    {
                        autenticado = false,
                    });
                }
                catch (Exception ex)
                {
                    throw new Exception("Problema encontrado fazendo login. ", ex);
                }
            }
        }
    }
}
