using JsDesenvolvimento.Eshopping.Api.Data.Operacao.DBModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace JsDesenvolvimento.Eshopping.Api.Logic.Loja.Model
{
    public class FinalizarCompraResponse
    {

        public FinalizarCompraResponse(Compra compraPendente, string erro)
        {
            CompraPendente = compraPendente;
            Erro = erro;
        }

        public Compra CompraPendente { get; }
        public string Erro { get; }

        public static FinalizarCompraResponse Ok(Compra compra)
        {
            return new FinalizarCompraResponse(compra, string.Empty);
        }

        public static FinalizarCompraResponse Falha(string erro)
        {
            return new FinalizarCompraResponse(null, erro);
        }
    }
}
