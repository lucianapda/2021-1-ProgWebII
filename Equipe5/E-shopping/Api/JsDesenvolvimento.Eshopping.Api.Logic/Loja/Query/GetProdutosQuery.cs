using JsDesenvolvimento.Eshopping.Api.Authentication;
using JsDesenvolvimento.Eshopping.Api.Data.Loja.DBModel;
using JsDesenvolvimento.Eshopping.Api.Data.Loja.Model;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace JsDesenvolvimento.Eshopping.Api.Logic.Loja.Query
{
    public class GetProdutosQuery : IRequest<IEnumerable<ProdutoDto>>
    {
        public GetProdutosQuery(ProdutoDto produto, IUserRef userRef)
        {
            this.Filters = produto;
            this.User = userRef;
        }

        public ProdutoDto Filters { get; }
        public IUserRef User { get; private set; }
    }
}
