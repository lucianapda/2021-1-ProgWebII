using JsDesenvolvimento.Eshopping.Api.Data.Operacao.DBModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace JsDesenvolvimento.Eshopping.Api.Data.Operacao.Model
{
    public class CompraPessoaDto : CompraItem
    {
        public int idpessoa { get; set; }
        public string nome { get; set; }
        public string descricao { get; set; }
        public string imagem { get; set; }
        public string sitcompra { get; set; }
        public DateTimeOffset datacompra { get; set; }
    }
}
