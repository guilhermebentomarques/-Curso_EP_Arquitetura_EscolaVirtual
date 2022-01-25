using System;
using System.Web.Mvc;
using EscolaVirtual.Conteudo.Application.Interfaces;
using EscolaVirtual.Vendas.Application.Interfaces;
using EscolaVirtual.Vendas.Application.ViewModels;
using Microsoft.AspNet.Identity;

namespace EscolaVirtual.Site.Controllers
{
    [Authorize]
    [RoutePrefix("carrinho")]
    public class PedidosController : BaseController
    {
        private readonly ICursoAppService _cursoAppService;
        private readonly IPedidoAppService _pedidoAppService;

        public PedidosController(ICursoAppService cursoAppService, IPedidoAppService pedidoAppService)
        {
            _cursoAppService = cursoAppService;
            _pedidoAppService = pedidoAppService;
        }

        [Route("")]
        public ActionResult Index()
        {
            var pedido = _pedidoAppService.ObterPedidoPendente(AlunoId);

            return View("Carrinho", pedido);  
        }

        [Route("adicionar/{id:guid}")]
        public ActionResult AdicionarCurso(Guid id)
        {
            var curso = _cursoAppService.ObterCurso(id);

            var item = new PedidoItemViewModel()
            {
                CursoId = curso.CursoId,
                Valor = curso.Valor,
                Descricao = curso.Nome,
                Quantidade = 1
            };

            var pedido = _pedidoAppService.AdicionarPedidoItem(item, AlunoId);

            if (ValidarErrosDominio())
            {
                return View("Carrinho", pedido);
            }

            return RedirectToAction("Index");
        }
    }
}