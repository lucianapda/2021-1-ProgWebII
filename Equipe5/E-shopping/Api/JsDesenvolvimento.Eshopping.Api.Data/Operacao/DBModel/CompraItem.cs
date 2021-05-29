using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace JsDesenvolvimento.Eshopping.Api.Data.Operacao.DBModel
{
    [Table("compra_item")]
    public class CompraItem
    {
        [Key]
        public int id { get; set; }
        [ExplicitKey]
        public long idcompra { get; set; }
        public int idproduto { get; set; }
	    public int idloja { get; set; }
	    public int idpropietario { get; set; }
	    public int quantidade { get; set; }
	    public decimal valorunitario { get; set; }
    }
}
