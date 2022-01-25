using System;
using System.Collections.Generic;
using System.Linq;
using EscolaVirtual.Cadastro.Domain.Alunos.Interfaces;
using EscolaVirtual.Core.Domain.Interfaces;
using EscolaVirtual.Vendas.Domain.Pagamentos.Events;
using EscolaVirtual.Vendas.Domain.Pedidos.Interfaces.Repository;

namespace EscolaVirtual.Vendas.Domain.Pagamentos.Handlers
{
    public class AlunoPremiumHandler : IHandler<AlunoPremiumEvent>
    {
        private readonly IAlunoRepository _alunoRepository;
        private readonly IPedidoRepository _pedidoRepository;

        private List<AlunoPremiumEvent> _notifications;

        public AlunoPremiumHandler(IAlunoRepository alunoRepository, IPedidoRepository pedidoRepository)
        {
            _alunoRepository = alunoRepository;
            _pedidoRepository = pedidoRepository;
        }

        public void Handle(AlunoPremiumEvent args)
        {
            // Obtem Aluno
            var aluno = _alunoRepository.ObterPorId(args.AlunoId);

            if (aluno.Premium) return;
            
            var totalPedidosPagos = _pedidoRepository.ObterPedidosPagos(args.AlunoId).Sum(p => p.Valor);
            if (totalPedidosPagos >= 1000M)
            {
                // Envia email para aluno

                // Atualiza o aluno com o novo status
                _alunoRepository.DefinirStatusPremium(aluno.AlunoId);
            }
        }

        public IEnumerable<AlunoPremiumEvent> Notify()
        {
            return GetValues();
        }

        public bool HasNotifications()
        {
            return GetValues().Count > 0;
        }

        public List<AlunoPremiumEvent> GetValues()
        {
            return _notifications;
        }

        public void Dispose()
        {
            _notifications = new List<AlunoPremiumEvent>();
        }
    }
}