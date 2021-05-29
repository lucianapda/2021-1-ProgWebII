using JsDesenvolvimento.Eshopping.Api.Data.Loja.DBModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace JsDesenvolvimento.Eshopping.Api.Logic.Loja.Model
{
    public class ProdutoCompradoDto: Produto
    {
        public int quantidade { get; set; }
        public decimal valorCompra { get; set; }
    }
}
