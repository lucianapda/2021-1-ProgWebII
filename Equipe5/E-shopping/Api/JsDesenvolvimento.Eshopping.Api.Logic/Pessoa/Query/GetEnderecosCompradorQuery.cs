using JsDesenvolvimento.Eshopping.Api.Authentication;
using JsDesenvolvimento.Eshopping.Api.Data.Pessoa.DBModel;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace JsDesenvolvimento.Eshopping.Api.Logic.Pessoa.Query
{
    public class GetEnderecosCompradorQuery: IRequest<IList<PessoaEndereco>>
    {
        public GetEnderecosCompradorQuery(Data.Pessoa.DBModel.Pessoa pessoa, IUserRef userRef)
        {
            Pessoa = pessoa;
            UserRef = userRef;
        }

        public Data.Pessoa.DBModel.Pessoa Pessoa { get; }
        public IUserRef UserRef { get; }
    }
}
