using System;

namespace EscolaVirtual.Conteudo.Domain.Cursos.Interfaces
{
    public interface ICursoService
    {
        void AdicionarAluno(Guid alunoId, Guid cursoId);
    }
}