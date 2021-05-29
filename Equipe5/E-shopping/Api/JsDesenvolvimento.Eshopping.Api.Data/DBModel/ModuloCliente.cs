using DapperExtensions.Mapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace JsDesenvolvimento.Eshopping.Api.Data.DBModel
{
    public static class ModuloCliente
    {
        public class LojaMapper: AutoClassMapper<Cliente.DBModel.Loja>
        {
            public LojaMapper()
            {
                Table("Loja");
                Map(a => a.IdLoja).Column("IdLoja").Key(KeyType.Identity);
                Map(a => a.Nome).Column("Nome");
                Map(a => a.TipoInscricao).Column("TipoInscricao");
                Map(a => a.Cpf).Column("Cpf");
                Map(a => a.Cnpj).Column("Cnpj");
                Map(a => a.Email).Column("Email");
                Map(a => a.Situacao).Column("Situacao");
                Map(a => a.DataInicio).Column("DataInicio");
                AutoMap();
            }
        }
    }
}
