using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace JsDesenvolvimento.Eshopping.Api.Data.Loja.DBModel
{
    [Table("produto_imagem")]
    public class ImagemProduto
    {
        [ExplicitKey]
        public int idproduto { get; set; }
        [ExplicitKey]
        public int idloja { get; set; }
        [ExplicitKey]
        public int idpropietario { get; set; }
        [Key]
        public int idimagem { get; set; }
        public string nome { get; set; }
        public string caminhodiretorio { get; set; }
        public string situacao { get; set; }
        public string imagemprincipal { get; set; }
    }
}
