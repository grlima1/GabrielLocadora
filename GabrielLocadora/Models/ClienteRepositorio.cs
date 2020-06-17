using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GabrielLocadora.Models
{
    public class ClienteRepositorio : IClienteRepositorio
    {
        private List<Cliente> Clientes = new List<Cliente>();
        private int _nextId = 1;
        public ClienteRepositorio()
        {
            Add(new Cliente { nome = "Gabriel", Id = 1 });
            Add(new Cliente { nome = "Isabele", Id = 2 });
            Add(new Cliente { nome = "João", Id = 3});
            Add(new Cliente { nome = "Vitor", Id = 4 });
            Add(new Cliente { nome = "Vanessa", Id = 5});
        }
        public IEnumerable<Cliente> GetAll()
        {
            return Clientes;
        }
        public Cliente Get(int id)
        {
            return Clientes.Find(s => s.Id == id);
        }
        public bool Add(Cliente Cliente)
        {
            bool addResult = false;
            if (Cliente == null)
            {
                return addResult;
            }
            int index = Clientes.FindIndex(s => s.Id == Cliente.Id);
            if (index == -1)
            {
                Clientes.Add(Cliente);
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
            Clientes.RemoveAll(s => s.Id == id);
        }
        public bool Update(Cliente Cliente)
        {
            if (Cliente == null)
            {
                throw new ArgumentNullException("Cliente");
            }
            int index = Clientes.FindIndex(s => s.Id == Cliente.Id);
            if (index == -1)
            {
                return false;
            }
            Clientes.RemoveAt(index);
            Clientes.Add(Cliente);
            return true;
        }
    }
}