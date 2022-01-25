using EscolaVirtual.Cadastro.Domain.Alunos.Events;
using EscolaVirtual.Core.Domain.Interfaces;

namespace EscolaVirtual.Cadastro.Domain.Alunos.Interfaces
{
    public interface IAlunoCadastradoHandler : IHandler<AlunoCadastradoEvent>
    {
         
    }
}