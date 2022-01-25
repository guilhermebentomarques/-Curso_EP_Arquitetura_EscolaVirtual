using System;
using EscolaVirtual.Vendas.Application.ViewModels;

namespace EscolaVirtual.Vendas.Application.Interfaces
{
    public interface IPagamentoAppService
    {
        PagamentoViewModel Adicionar(PagamentoViewModel pagamentoViewModel);
        PagamentoViewModel ObterPorId(Guid id); 
    }
}