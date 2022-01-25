using System;
using System.Collections.Generic;
using EscolaVirtual.Conteudo.Application.ViewModels;

namespace EscolaVirtual.Conteudo.Application.Interfaces
{
    public interface ICursoAppService
    {
        void AdicionarAluno(Guid alunoId, Guid cursoId);
        CursoViewModel ObterCurso(Guid cursoId);
        IEnumerable<CursoViewModel> ObterTodos(); 
    }
}