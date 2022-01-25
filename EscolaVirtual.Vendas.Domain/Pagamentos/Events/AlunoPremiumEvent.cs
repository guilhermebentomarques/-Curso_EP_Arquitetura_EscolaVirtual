using System;
using EscolaVirtual.Core.Domain.Interfaces;

namespace EscolaVirtual.Vendas.Domain.Pagamentos.Events
{
    public class AlunoPremiumEvent : IDomainEvent
    {

        public int Versao { get; set; }
        public DateTime DataOcorrencia { get; private set; }
        public Guid AlunoId { get; private set; }

        public AlunoPremiumEvent(Guid alunoId)
        {
            this.AlunoId = alunoId;
            this.DataOcorrencia = DateTime.Now;
        }
    }
}