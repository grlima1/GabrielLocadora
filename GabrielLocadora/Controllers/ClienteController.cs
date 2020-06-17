using GabrielLocadora.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GabrielLocadora.Controllers
{
    public class ClienteController : ApiController
    {
        static readonly IClienteRepositorio ClienteRepositorio = new ClienteRepositorio();
        public HttpResponseMessage GetAllClientes()
        {
            List<Cliente> listaClientes = ClienteRepositorio.GetAll().ToList();
            return Request.CreateResponse<List<Cliente>>(HttpStatusCode.OK, listaClientes);
        }
        public HttpResponseMessage GetCliente(int id)
        {
            Cliente Cliente = ClienteRepositorio.Get(id);
            if (Cliente == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Cliente não localizado para o Id informado");
            }
            else
            {
                return Request.CreateResponse<Cliente>(HttpStatusCode.OK, Cliente);
            }
        }
        public HttpResponseMessage PostCliente(Cliente Cliente)
        {
            bool result = ClienteRepositorio.Add(Cliente);
            if (result)
            {
                var response = Request.CreateResponse<Cliente>(HttpStatusCode.Created, Cliente);
                string uri = Url.Link("DefaultApi", new { id = Cliente.Id });
                response.Headers.Location = new Uri(uri);
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Cliente não foi incluído com sucesso");
            }
        }
        public HttpResponseMessage PutCliente(int id, Cliente Cliente)
        {
            Cliente.Id = id;
            if (!ClienteRepositorio.Update(Cliente))
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound,
 "Não foi possível atualizar o Cliente para o id informado");
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.OK);
            }
        }
        public HttpResponseMessage DeleteCliente(int id)
        {
            ClienteRepositorio.Remove(id);
            return new HttpResponseMessage(HttpStatusCode.NoContent);
        }
    }
}
