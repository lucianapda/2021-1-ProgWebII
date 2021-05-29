using System;
using System.Collections.Generic;
using System.Text;

namespace JsDesenvolvimento.Eshopping.Api.Authentication.Model
{
    public class LojaAutenticada
    {
        public LojaAutenticada(int propietario, int loja, string login)
        {
            this.Propietario = propietario;
            this.Loja = loja;
            this.Login = login;
        }

        public int Propietario { get; private set; }
        public int Loja { get; private set; }
        public string Login { get; private set; }
    }
}
