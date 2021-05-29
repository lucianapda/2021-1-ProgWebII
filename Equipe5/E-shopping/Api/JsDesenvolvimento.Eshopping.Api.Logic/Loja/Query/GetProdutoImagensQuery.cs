using JsDesenvolvimento.Eshopping.Api.Authentication;
using JsDesenvolvimento.Eshopping.Api.Data.Loja.DBModel;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace JsDesenvolvimento.Eshopping.Api.Logic.Loja.Query
{
    public class GetProdutoImagensQuery: IRequest<IEnumerable<ImagemProduto>>
    {
        public GetProdutoImagensQuery(ImagemProduto filters, IUserRef userRef)
        {
            Filters = filters;
            UserRef = userRef;
        }

        public ImagemProduto Filters { get; }
        public IUserRef UserRef { get; }
    }
}
