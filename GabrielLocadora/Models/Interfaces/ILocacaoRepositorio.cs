using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GabrielLocadora.Models.Interfaces
{
    interface ILocacaoRepositorio
    {
        IEnumerable<Locacao> GetAll();
        Locacao Get(int id);
        bool Add(Locacao estudante);
        void Remove(int id);
        bool Update(Locacao estudante);
    }
}
