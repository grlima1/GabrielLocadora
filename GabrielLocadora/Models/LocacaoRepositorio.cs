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
        private IEnumerable<Filme> Filmes = new List<Filme>();
        private IEnumerable<Cliente> Clientes = new List<Cliente>();
        private int _nextId = 1;
        public LocacaoRepositorio()
        {
            Clientes = new ClienteRepositorio().GetAll();
            Filmes = new FilmeRepositorio().GetAll();
            Add(new Locacao { Id = 1, cliente = Clientes.ElementAt(0), filme = Filmes.ElementAt(0), dtLocacao = DateTime.Today });
            Add(new Locacao { Id = 2, cliente = Clientes.ElementAt(3), filme = Filmes.ElementAt(3), dtLocacao = DateTime.Today.AddDays(-5) });
            foreach (var loc in Locacoes)
                RentMovie(loc);
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
        //regra 3: Não permitir alugar um filme que não está disponível
        private bool isMovieAvailable(Filme filme)
        {
            foreach (var mov in Filmes)
                if (mov.nome == filme.nome)
                    return mov.isAvailable();
            return false; //retorna falso também se filme não existe
        }
        private void RentMovie(Locacao locacao)
        {
            Filmes.Where(x => x.nome == locacao.filme.nome).First().rent();
            locacao.dtDevolucaoPrevista = locacao.dtLocacao.AddDays(3);
        }
        public bool Add(Locacao Locacao)
        {
            bool addResult = false;
            if (Locacao == null)
            {
                return addResult;
            }
            int index = Locacoes.FindIndex(s => s.Id == Locacao.Id);

            if (index == -1 && isPossibleToRent(Locacao) && isMovieAvailable(Locacao.filme))
            {
                Locacoes.Add(Locacao);
                RentMovie(Locacao);
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
        //regra 4: Alertar na devolução se o filme está com atraso
        public bool Devolucao(int id)
        {
            var locacao = Locacoes.Where(x => x.Id == id).FirstOrDefault();
            locacao.dtDevolucaoReal = DateTime.Now;
            if (locacao.dtDevolucaoPrevista.Value.CompareTo(DateTime.Now) <  0)
                return false;
            return true;
        }
    }
}