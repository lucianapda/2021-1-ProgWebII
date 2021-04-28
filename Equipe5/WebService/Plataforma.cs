using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebService
{
    public class Plataforma
    {

        public string nome { get; set; }
        public string tipo { get; set; }
        public double valor { get; set; }
        public IList<Filme> filmes { get; set; }
    }
}