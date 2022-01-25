using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using EscolaVirtual.Vendas.Data.Context;
using EscolaVirtual.Vendas.Domain.Pedidos;
using EscolaVirtual.Vendas.Domain.Pedidos.Interfaces.Repository;

namespace EscolaVirtual.Vendas.Data.Repository
{
    public class PedidoRepository : IPedidoRepository
    {
        private readonly VendasContext _db;

        public PedidoRepository(VendasContext db)
        {
            _db = db;
        }

        public Pedido AdicionarPedido(Pedido pedido)
        {
            var pedidoReturn = _db.Pedidos.Add(pedido);
            return pedidoReturn;
        }

        public void AdicionarPedidoItem(PedidoItem pedidoItem)
        {
            _db.PedidoItems.Add(pedidoItem);
        }

        public void AtualizarPedido(Pedido pedido)
        {
            var entry = _db.Entry(pedido);
            _db.Set<Pedido>().Attach(pedido);
            entry.State = EntityState.Modified;
        }

        public Pedido ObterPedidoPendente(Guid alunoId)
        {
            return
                _db.Pedidos.Include("PedidoItems")
                    .Where(p => p.AlunoId == alunoId && p.StatusPedido == StatusPedido.Iniciado)
                    .OrderByDescending(p => p.DataPedido)
                    .FirstOrDefault();
        }

        public Pedido ObterPedidoPorId(Guid pedidoId)
        {
            return _db.Pedidos.Include("PedidoItems").FirstOrDefault(p => p.PedidoId == pedidoId);
        }

        public IEnumerable<Pedido> ObterPedidosPagos(Guid alunoId)
        {
            return _db.Pedidos.Where(p => p.AlunoId == alunoId && p.StatusPedido == StatusPedido.Pago);
        }

        public void Dispose()
        {
            _db.Dispose();
        }
    }
}