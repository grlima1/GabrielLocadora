using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GabrielLocadora.Models
{
    interface IFilmeRepositorio
    {
        IEnumerable<Filme> GetAll();
        Filme Get(int id);
        bool Add(Filme estudante);
        void Remove(int id);
        bool Update(Filme estudante);
    }
}
