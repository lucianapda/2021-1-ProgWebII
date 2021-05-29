using JsDesenvolvimento.Eshopping.Api.Authentication;
using JsDesenvolvimento.Eshopping.Api.Data.Loja.DBModel;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace JsDesenvolvimento.Eshopping.Api.Logic.Loja.Query
{
    public class GetCategoriasQuery : IRequest<IEnumerable<Categoria>>
    {
        public GetCategoriasQuery(Categoria request, IUserRef userRef)
        {
            this.Request = request;
            this.User = userRef;
        }

        public Categoria Request { get; set; }
        public IUserRef User { get; private set; }
    }
}
