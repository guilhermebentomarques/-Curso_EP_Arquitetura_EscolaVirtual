using System;
using System.Linq;
using System.Web.Mvc;
using EscolaVirtual.Vendas.Application.Interfaces;
using EscolaVirtual.Vendas.Application.ViewModels;

namespace EscolaVirtual.Site.Controllers
{
    [Authorize]
    [RoutePrefix("pagamento")]
    public class PagamentoController : BaseController
    {
        private readonly IPedidoAppService _pedidoAppService;
        private readonly IPagamentoAppService _pagamentoAppService;

        public PagamentoController(IPedidoAppService pedidoAppService, IPagamentoAppService pagamentoAppService)
        {
            _pedidoAppService = pedidoAppService;
            _pagamentoAppService = pagamentoAppService;
        }

        [Route("")]
        public ActionResult Checkout()
        {
            var pedido = _pedidoAppService.ObterPedidoPendente(AlunoId);

            var pagamento = new PagamentoViewModel()
            {
                AlunoId = AlunoId,
                Valor = pedido.PedidoItems.Sum(p => p.Valor),
                PedidoId = pedido.PedidoId,
                Pedido = pedido
            };

            return View(pagamento);
        }

        [Route("")]
        [HttpPost]
        public ActionResult Checkout(PagamentoViewModel pagamentoViewModel)
        {
            var pedido = _pedidoAppService.ObterPedidoPendente(AlunoId);
            pagamentoViewModel.PedidoId = pedido.PedidoId;
            pagamentoViewModel.Pedido = pedido;
            pagamentoViewModel.Valor = pedido.PedidoItems.Sum(p => p.Valor);

            _pagamentoAppService.Adicionar(pagamentoViewModel);

            return ValidarErrosDominio() ? View(pagamentoViewModel) : View("Confirmacao", pagamentoViewModel);
        }
    }
}