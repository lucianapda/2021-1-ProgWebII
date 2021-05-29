using JsDesenvolvimento.Eshopping.Api.Authentication;
using JsDesenvolvimento.Eshopping.Api.Logic.Pessoa.Model;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace JsDesenvolvimento.Eshopping.Api.Logic.Pessoa.Cqrs
{
    public class CadastrarCompradorCommand: IRequest<CadastrarCompradorCommandResponse>
    {
        public CadastrarCompradorCommand(Data.Pessoa.DBModel.Pessoa pessoa, IUserRef userRef)
        {
            Pessoa = pessoa;
            UserRef = userRef;
        }

        public Data.Pessoa.DBModel.Pessoa Pessoa { get; }
        public IUserRef UserRef { get; }
    }
}
