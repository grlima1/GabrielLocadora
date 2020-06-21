using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GabrielLocadora.Models
{
    public class Filme
    {
        public int Id { get; set; }
        public string nome { get; set; }
        public Categoria categoria { get; set; }
        public int ano_lancamento { get; set; }
        public bool disponivel { get; set; }

        public Filme()
        {
            disponivel = true;
        }
    }

    public enum Categoria
    {
        Comedia,
        Terror,
        Suspense,
        Drama,
        Acao
    }
}