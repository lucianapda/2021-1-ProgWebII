using JsDesenvolvimento.Eshopping.Api.Authentication;
using JsDesenvolvimento.Eshopping.Api.Logic.Loja.Model;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace JsDesenvolvimento.Eshopping.Api.Logic.Loja.Cqrs
{
    public class FinalizarCompraCommand: IRequest<FinalizarCompraResponse>
    {
        public FinalizarCompraCommand(FinalizarCompraRequest finalizarCompraRequest, IUserRef userRef)
        {
            FinalizarCompraRequest = finalizarCompraRequest;
            UserRef = userRef;
        }

        public FinalizarCompraRequest FinalizarCompraRequest { get; }
        public IUserRef UserRef { get; }
    }
}
