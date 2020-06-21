using GabrielLocadora.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace GabrielLocadora.Controllers
{
    public class FilmeController : ApiController
    {
        static readonly IFilmeRepositorio FilmeRepositorio = new FilmeRepositorio();
        public HttpResponseMessage GetAllFilmes()
        {
            List<Filme> listaFilmes = FilmeRepositorio.GetAll().ToList();
            return Request.CreateResponse<List<Filme>>(HttpStatusCode.OK, listaFilmes);
        }
        public HttpResponseMessage GetFilme(int id)
        {
            Filme Filme = FilmeRepositorio.Get(id);
            if (Filme == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Filme não localizado para o Id informado");
            }
            else
            {
                return Request.CreateResponse<Filme>(HttpStatusCode.OK, Filme);
            }
        }
        public HttpResponseMessage PostFilme(Filme Filme)
        {
            bool result = FilmeRepositorio.Add(Filme);
            if (result)
            {
                var response = Request.CreateResponse<Filme>(HttpStatusCode.Created, Filme);
                string uri = Url.Link("DefaultApi", new { id = Filme.Id });
                response.Headers.Location = new Uri(uri);
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Filme não foi incluído com sucesso");
            }
        }
        public HttpResponseMessage PutFilme(int id, Filme Filme)
        {
            Filme.Id = id;
            if (!FilmeRepositorio.Update(Filme))
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound,
 "Não foi possível atualizar o Filme para o id informado");
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.OK);
            }
        }
        public HttpResponseMessage DeleteFilme(int id)
        {
            return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Não é permitido excluir fisicamente um registro");
        }
    }
}