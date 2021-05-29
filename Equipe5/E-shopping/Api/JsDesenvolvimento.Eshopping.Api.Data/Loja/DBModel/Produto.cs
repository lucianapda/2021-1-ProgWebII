using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace JsDesenvolvimento.Eshopping.Api.Data.Loja.DBModel
{
    [Table("produto")]
    public class Produto
    {
        [ExplicitKey]
        public int idproduto { get; set; }
        [ExplicitKey]
        public int idloja { get; set; }
        [ExplicitKey]
        public int idpropietario { get; set; }
        public int? idcategoria { get; set; }
        public string nome { get; set; }
        public string descricao { get; set; }
        public decimal precounitario { get; set; }
        public DateTime datacadastro { get; set; }
        public string situacao { get; set; }
        public string marca { get; set; }
    }
}
