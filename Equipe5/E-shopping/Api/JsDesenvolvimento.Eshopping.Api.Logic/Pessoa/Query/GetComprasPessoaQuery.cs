using JsDesenvolvimento.Eshopping.Api.Authentication;
using JsDesenvolvimento.Eshopping.Api.Data.Operacao.Model;
using JsDesenvolvimento.Eshopping.Api.Logic.Loja.Model;
using JsDesenvolvimento.Eshopping.Api.Logic.Pessoa.Model;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace JsDesenvolvimento.Eshopping.Api.Logic.Pessoa.Query
{
    public class GetComprasPessoaQuery: IRequest<IList<CompraPessoaLote>>
    {
        public GetComprasPessoaQuery(JsDesenvolvimento.Eshopping.Api.Data.Pessoa.DBModel.Pessoa pessoa, IUserRef userRef)
        {
            Pessoa = pessoa;
            UserRef = userRef;
        }

        public Data.Pessoa.DBModel.Pessoa Pessoa { get; }
        public IUserRef UserRef { get; }
    }
}
