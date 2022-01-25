using System;
using System.Collections.Generic;

namespace EscolaVirtual.Conteudo.Domain.Cursos.Interfaces
{
    public interface ICursoRepository
    {
        void AdicionarAluno(Matricula matricula);
        Curso ObterCurso(Guid cursoId);
        IEnumerable<Curso> ObterTodos();
        CursoMatriculas ObterMatriculas(Guid cursoId);
    }
}