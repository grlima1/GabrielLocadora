using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GabrielLocadora.Models
{
    public class FilmeRepositorio : IFilmeRepositorio
    {
        private List<Filme> Filmes = new List<Filme>();
        private int _nextId = 1;
        public FilmeRepositorio()
        {
            Add(new Filme { nome = "Shrek", Id = 1, ano_lancamento = 2001, categoria = Categoria.Comedia });
            Add(new Filme { nome = "Gigantes de Aço", Id = 2, ano_lancamento = 2011, categoria = Categoria.Acao });
            Add(new Filme { nome = "O Chamado", Id = 3, ano_lancamento = 2002, categoria = Categoria.Terror });
            Add(new Filme { nome = "A Origem", Id = 4, ano_lancamento = 2010, categoria = Categoria.Acao });
            Add(new Filme { nome = "As Branquelas", Id = 5, ano_lancamento = 2004, categoria = Categoria.Comedia });
        }
        public IEnumerable<Filme> GetAll()
        {
            return Filmes;
        }
        public Filme Get(int id)
        {
            return Filmes.Find(s => s.Id == id);
        }
        public bool Add(Filme Filme)
        {
            bool addResult = false;
            if (Filme == null)
            {
                return addResult;
            }
            int index = Filmes.FindIndex(s => s.Id == Filme.Id);
            if (index == -1)
            {
                Filmes.Add(Filme);
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
            Filmes.RemoveAll(s => s.Id == id);
        }
        public bool Update(Filme Filme)
        {
            if (Filme == null)
            {
                throw new ArgumentNullException("Filme");
            }
            int index = Filmes.FindIndex(s => s.Id == Filme.Id);
            if (index == -1)
            {
                return false;
            }
            Filmes.RemoveAt(index);
            Filmes.Add(Filme);
            return true;
        }
    }
}