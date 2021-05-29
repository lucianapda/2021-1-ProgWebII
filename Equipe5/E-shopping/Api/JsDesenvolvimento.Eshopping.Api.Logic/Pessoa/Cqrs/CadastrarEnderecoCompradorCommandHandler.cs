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
    public class CadastrarEnderecoCompradorCommandHandler : IRequestHandler<CadastrarEnderecoCompradorCommand, CadastrarEnderecoCompradorCommandResponse>
    {
        private IDbConnectionFactory DbConnectionFactory { get; set; }
        private IDbContextFactory DbContextFactory { get; set; }

        public CadastrarEnderecoCompradorCommandHandler(IDbConnectionFactory dbConnectionFactory, IDbContextFactory contextFactory)
        {
            this.DbConnectionFactory = dbConnectionFactory;
            this.DbContextFactory = contextFactory;
        }

        public Task<CadastrarEnderecoCompradorCommandResponse> Handle(CadastrarEnderecoCompradorCommand request, CancellationToken cancellationToken)
        {
            using (var ctx = this.DbContextFactory.NewContext())
            {
                try
                {
                    var repo = ctx.AcquireRepository<IPessoaEnderecoRepository>();
                    var endereco = request.PessoaEndereco;
                    var pessoaEndereco = repo.InsertAsync(new Data.Pessoa.DBModel.PessoaEndereco()
                    {
                        idpessoa = endereco.idpessoa,
                        bairro = endereco.bairro,
                        cep = endereco.cep,
                        cidade = endereco.cidade,
                        complemento = endereco.complemento,
                        ddd = endereco.ddd,
                        numero = endereco.numero,
                        rua = endereco.rua,
                        telefone = endereco.telefone,
                        uf = endereco.uf
                    }, cancellationToken).Result;

                    return Task.FromResult(new CadastrarEnderecoCompradorCommandResponse()
                    {
                        Endereco = pessoaEndereco
                    });
                }
                catch (Exception ex)
                {
                    throw new Exception("Problema encontrado cadastrando endereco do comprador. ", ex);
                }
            }
        }
    }
}
