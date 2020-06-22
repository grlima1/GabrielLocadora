using GabrielLocadora.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Results;

namespace GabrielLocadora.Tests.Controllers
{
    [TestClass]
    class LocacaoControllerTest
    {
        [TestMethod]
        public void GetAllLocacoes()
        {
            var controller = new LocacaoRepositorio();
            var item = GetDemoLocacao();

            var result = controller.Devolucao(item.Id);

            Assert.IsNotNull(result);
            Assert.AreEqual(true, false);
        }

        Locacao GetDemoLocacao()
        {
            return new Locacao()
            {
                cliente = new Cliente() { Id = 10, nome = "Maria" },
                filme = new Filme() { Id = 50, nome = "Batman vs Superman", ano_lancamento = 2016, categoria = Categoria.Acao },
                Id = 7,
                dtLocacao = DateTime.Now
            };
        }
    }
}
