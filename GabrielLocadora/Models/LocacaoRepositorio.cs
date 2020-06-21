using GabrielLocadora.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GabrielLocadora.Models
{
    public class LocacaoRepositorio : ILocacaoRepositorio
    {
        private List<Locacao> Locacoes = new List<Locacao>();
        private int _nextId = 1;
        public LocacaoRepositorio()
        {
            var clientes = new ClienteRepositorio().GetAll();
            var filmes = new FilmeRepositorio().GetAll();
            Add(new Locacao { Id = 1, cliente = clientes.ElementAt(0), filme = filmes.ElementAt(0), dtLocacao = DateTime.Today });
            Add(new Locacao { Id = 2, cliente = clientes.ElementAt(1), filme = filmes.ElementAt(1), dtLocacao = DateTime.Today });
            Add(new Locacao { Id = 3, cliente = clientes.ElementAt(2), filme = filmes.ElementAt(2), dtLocacao = DateTime.Today });
            Add(new Locacao { Id = 4, cliente = clientes.ElementAt(3), filme = filmes.ElementAt(3), dtLocacao = DateTime.Today.AddDays(-3), dtDevolucaoPrevista = DateTime.Today, dtDevolucaoReal = DateTime.Today.AddDays(1) });
        }
        public IEnumerable<Locacao> GetLocacaoNaoFinalizada()
        {
            return Locacoes.Where(x => x.dtDevolucaoReal == null);
        }
        public IEnumerable<Locacao> GetAll()
        {
            return Locacoes;
        }
        public Locacao Get(int id)
        {
            return Locacoes.Find(s => s.Id == id);
        }
        //regra 1: Um locador não pode se repetir
        private bool isPossibleToRent(Locacao locacao)
        {
            bool result = true;
            foreach (var loc in GetLocacaoNaoFinalizada())
                if (loc.cliente.Id == locacao.cliente.Id)
                {
                    result = false;
                    break;
                }

            return result;
        }
        public bool Add(Locacao Locacao)
        {
            bool addResult = false;
            if (Locacao == null)
            {
                return addResult;
            }
            int index = Locacoes.FindIndex(s => s.Id == Locacao.Id);

            if (index == -1 && isPossibleToRent(Locacao))
            {
                Locacoes.Add(Locacao);
                addResult = true;
                return addResult;
            }
            else
            {
                return addResult;
            }
        }

        public void Remove(int id)
        {
            Locacoes.RemoveAll(s => s.Id == id);
        }
        public bool Update(Locacao Locacao)
        {
            if (Locacao == null)
            {
                throw new ArgumentNullException("Locacao");
            }
            int index = Locacoes.FindIndex(s => s.Id == Locacao.Id);
            if (index == -1)
            {
                return false;
            }
            Locacoes.RemoveAt(index);
            Locacoes.Add(Locacao);
            return true;
        }
    }
}