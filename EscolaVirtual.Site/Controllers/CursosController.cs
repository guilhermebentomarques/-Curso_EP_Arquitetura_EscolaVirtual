using System;
using System.Web.Mvc;
using EscolaVirtual.Conteudo.Application.Interfaces;
using Microsoft.AspNet.Identity;

namespace EscolaVirtual.Site.Controllers
{
    [RoutePrefix("cursos")]
    public class CursosController : Controller
    {
        private readonly ICursoAppService _cursoAppService;

        public CursosController(ICursoAppService cursoAppService)
        {
            _cursoAppService = cursoAppService;
        }

        [Route("lista-de-cursos")]
        public ActionResult Index()
        {
            return View(_cursoAppService.ObterTodos());
        }
    }
}