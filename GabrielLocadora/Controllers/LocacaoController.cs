using GabrielLocadora.Models;
using GabrielLocadora.Models.Interfaces;
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
    public class LocacaoController : ApiController
    {
        static readonly ILocacaoRepositorio LocacaoRepositorio = new LocacaoRepositorio();
        public HttpResponseMessage GetAllLocacaos()
        {
            List<Locacao> listaLocacaos = LocacaoRepositorio.GetAll().ToList();
            return Request.CreateResponse<List<Locacao>>(HttpStatusCode.OK, listaLocacaos);
        }
        public HttpResponseMessage GetLocacao(int id)
        {
            Locacao Locacao = LocacaoRepositorio.Get(id);
            if (Locacao == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Locação não localizada para o Id informado");
            }
            else
            {
                return Request.CreateResponse<Locacao>(HttpStatusCode.OK, Locacao);
            }
        }
        public HttpResponseMessage PostLocacao(Locacao Locacao)
        {
            bool result = LocacaoRepositorio.Add(Locacao);
            if (result)
            {
                var response = Request.CreateResponse<Locacao>(HttpStatusCode.Created, Locacao);
                string uri = Url.Link("DefaultApi", new { id = Locacao.Id });
                response.Headers.Location = new Uri(uri);
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Locação não foi incluída com sucesso");
            }
        }
        public HttpResponseMessage PutLocacao(int id, Locacao Locacao)
        {
            Locacao.Id = id;
            if (!LocacaoRepositorio.Update(Locacao))
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound,
 "Não foi possível atualizar a Locação para o id informado");
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.OK);
            }
        }
        public HttpResponseMessage DeleteLocacao(int id)
        {
            return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Não é permitido excluir fisicamente um registro");
        }

        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("Devolucao")]
        public HttpResponseMessage Devolucao(int id)
        {
            var locacao = LocacaoRepositorio.Get(id);
            if(locacao == null)
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Locação não localizada para o Id informado");

            var result = LocacaoRepositorio.Devolucao(locacao.Id);
            if (result)
                return Request.CreateResponse(HttpStatusCode.OK, "Devolução efetuada dentro do Prazo");
            else
                return Request.CreateResponse(HttpStatusCode.OK, "Devolução efetuada fora do Prazo");
        }
    }
}