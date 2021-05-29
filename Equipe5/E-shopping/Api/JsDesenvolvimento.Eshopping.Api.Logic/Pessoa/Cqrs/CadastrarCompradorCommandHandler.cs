using JsDesenvolvimento.Data;
using JsDesenvolvimento.Eshopping.Api.Data.Pessoa;
using JsDesenvolvimento.Eshopping.Api.Logic.Pessoa.Model;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace JsDesenvolvimento.Eshopping.Api.Logic.Pessoa.Cqrs
{
    public class CadastrarCompradorCommandHandler : IRequestHandler<CadastrarCompradorCommand, CadastrarCompradorCommandResponse>
    {
        private IDbConnectionFactory DbConnectionFactory { get; set; }
        private IDbContextFactory DbContextFactory { get; set; }

        public CadastrarCompradorCommandHandler(IDbConnectionFactory dbConnectionFactory, IDbContextFactory contextFactory)
        {
            this.DbConnectionFactory = dbConnectionFactory;
            this.DbContextFactory = contextFactory;
        }

        public Task<CadastrarCompradorCommandResponse> Handle(CadastrarCompradorCommand request, CancellationToken cancellationToken)
        {
            using (var ctx = this.DbContextFactory.NewContext())
            {
                try
                {
                    var repo = ctx.AcquireRepository<IPessoaRepository>();
                    var comprador = repo.InsertAsync(new Data.Pessoa.DBModel.Pessoa()
                    {
                        cnpj = request.Pessoa.cnpj,
                        cpf = request.Pessoa.cpf,
                        nome = request.Pessoa.nome,
                        tipoinscricao = !string.IsNullOrEmpty(request.Pessoa.cpf) ? "F" : "J",
                        email = request.Pessoa.email,
                        senha = request.Pessoa.senha,                        
                    }, cancellationToken).Result;

                    return Task.FromResult(new CadastrarCompradorCommandResponse()
                    {
                        Comprador = comprador
                    });
                }catch(Exception ex)
                {
                    throw new Exception("Problema encontrado cadastrando comprador. ", ex);
                }
            }
        }
    }
}
