﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GabrielLocadora.Models
{
    interface IClienteRepositorio
    {
        IEnumerable<Cliente> GetAll();
        Cliente Get(int id);
        bool Add(Cliente estudante);
        void Remove(int id);
        bool Update(Cliente estudante);
    }
}
