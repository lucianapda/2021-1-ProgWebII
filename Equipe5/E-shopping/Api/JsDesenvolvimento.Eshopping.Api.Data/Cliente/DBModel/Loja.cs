using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace JsDesenvolvimento.Eshopping.Api.Data.Cliente.DBModel
{
    [Table("\"Loja\"")]
    public class Loja
    {
        [Key]
        public long IdLoja { get; set; }
        public string Nome { get; set; }
        public string TipoInscricao { get; set; }
        public string Cpf { get; set; }
        public string Cnpj { get; set; }
        public string Email { get; set; }
        public string Situacao { get; set; }
        public DateTime DataInicio { get; set; }
    }
}
