using Client.WebServico;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Client.Models
{
    public class PlataformaModels
    {
        public string nome { get; set; }
        public string tipo { get; set; }
        public double valor { get; set; }
        public IList<Filme> filmes { get; set; }
    }
}