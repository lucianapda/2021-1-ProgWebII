using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace JsDesenvolvimento.Eshopping.Api.Data.Operacao.DBModel
{
    [Table("compra")]
    public class Compra
    {
        [Key]
        public long idcompra { get; set; }
        public int idloja { get; set; }
        public int idpropietario { get; set; }
        public int? idpessoa { get; set; }
        public DateTimeOffset datacompra { get; set; }
        public string situacao { get; set; }
        public int idendereco { get; set; }
    }
}
