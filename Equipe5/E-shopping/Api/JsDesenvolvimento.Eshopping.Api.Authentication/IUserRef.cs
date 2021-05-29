using JsDesenvolvimento.Eshopping.Api.Authentication.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace JsDesenvolvimento.Eshopping.Api.Authentication
{
    public interface IUserRef
    {
        LojaAutenticada Loja { get; }
        string Nome { get; }
    }
}
