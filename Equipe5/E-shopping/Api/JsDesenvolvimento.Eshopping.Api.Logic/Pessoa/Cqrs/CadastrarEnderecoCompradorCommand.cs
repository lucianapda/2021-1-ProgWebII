using JsDesenvolvimento.Eshopping.Api.Authentication;
using JsDesenvolvimento.Eshopping.Api.Data.Pessoa.DBModel;
using JsDesenvolvimento.Eshopping.Api.Logic.Pessoa.Model;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace JsDesenvolvimento.Eshopping.Api.Logic.Pessoa.Cqrs
{
    public class CadastrarEnderecoCompradorCommand : IRequest<CadastrarEnderecoCompradorCommandResponse>
    {
        public CadastrarEnderecoCompradorCommand(PessoaEndereco pessoaEndereco, IUserRef userRef)
        {
            PessoaEndereco = pessoaEndereco;
            UserRef = userRef;
        }

        public PessoaEndereco PessoaEndereco { get; }
        public IUserRef UserRef { get; }
    }
}
