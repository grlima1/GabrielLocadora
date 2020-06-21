using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GabrielLocadora.Models
{
    public class Locacao
    {
        public int Id { get; set; }
        public Filme filme { get; set; }
        public Cliente cliente { get; set; }
        public DateTime dtLocacao { get; set; }
        public DateTime? dtDevolucaoPrevista { get; set; }
        public DateTime? dtDevolucaoReal { get; set; }
    }
}