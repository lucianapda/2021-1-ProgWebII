using JsDesenvolvimento.Eshopping.Api.Authentication;
using JsDesenvolvimento.Eshopping.Api.Logic.Pessoa.Model;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace JsDesenvolvimento.Eshopping.Api.Logic.Pessoa.Cqrs
{
    public class FazerLoginCommand: IRequest<FazerLoginCommandResponse>
    {
        public FazerLoginCommand(FazerLoginCommandRequest Informacoes, IUserRef userRef)
        {
            this.Informacoes = Informacoes;
            UserRef = userRef;
        }

        public FazerLoginCommandRequest Informacoes { get; }
        public IUserRef UserRef { get; }
    }
}
