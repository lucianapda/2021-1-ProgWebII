using JsDesenvolvimento.Eshopping.Api.Data.Pessoa;
using System;
using System.Collections.Generic;
using System.Text;

namespace JsDesenvolvimento.Eshopping.Api.Logic.Loja.Model
{
    public class FinalizarCompraRequest
    {
        public IList<ProdutoCompradoDto> ProdutosCompra { get; set; }
        public Data.Pessoa.DBModel.Pessoa Comprador { get; set; }
        public Data.Pessoa.DBModel.PessoaEndereco Endereco { get; set; }
    }
}
