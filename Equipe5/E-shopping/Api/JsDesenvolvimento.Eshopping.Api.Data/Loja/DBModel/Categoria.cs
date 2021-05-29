using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace JsDesenvolvimento.Eshopping.Api.Data.Loja.DBModel
{
    [Table("categoria")]
    public class Categoria
    {
        [ExplicitKey]
        public int idcategoria { get; set; }
        [ExplicitKey]
        public int idloja { get; set; }
        [ExplicitKey]
        public int idpropietario { get; set; }
        public string nome { get; set; }
        public string descricao { get; set; }
        public string situacao { get; set; }
    }
}
