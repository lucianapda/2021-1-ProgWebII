using System;
using System.Collections.Generic;
using System.Text;

namespace JsDesenvolvimento.Eshopping.Api.Logic.Pessoa.Model
{
    public class FazerLoginCommandResponse
    {
        public bool autenticado { get; set; }
        public int idpessoa { get; set; }
        public string email { get; set; }
    }
}
