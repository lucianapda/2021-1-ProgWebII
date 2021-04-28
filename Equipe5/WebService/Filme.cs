using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebService
{
    public class Filme
    {
        public string nome { get; set; }
        public string descricao { get; set; }
        public double duracao { get; set; }
        public string dataLancamento { get; set; }
    }
}