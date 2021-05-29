using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace JsDesenvolvimento.Eshopping.Api.Data.Pessoa.DBModel
{
    [Table("pessoa")]
    public class Pessoa
    {
        [Key]
        public int idpessoa { get; set; }
        public string tipoinscricao { get; set; }
        public string cpf { get; set; }
        public string cnpj { get; set; }
        public string nome { get; set; }
        public string email { get; set; }
        public string senha { get; set; }
    }
}
