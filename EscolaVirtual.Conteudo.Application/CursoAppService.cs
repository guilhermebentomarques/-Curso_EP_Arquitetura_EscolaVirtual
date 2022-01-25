using System;
using System.Collections.Generic;
using System.Linq;
using EscolaVirtual.Conteudo.Application.Adapters;
using EscolaVirtual.Conteudo.Application.Interfaces;
using EscolaVirtual.Conteudo.Application.ViewModels;
using EscolaVirtual.Conteudo.Domain.Cursos.Interfaces;

namespace EscolaVirtual.Conteudo.Application
{
    public class CursoAppService : ICursoAppService
    {
        private readonly ICursoService _cursoService;
        private readonly ICursoRepository _cursoRepository;

        public CursoAppService(ICursoService cursoService, ICursoRepository cursoRepository)
        {
            _cursoService = cursoService;
            _cursoRepository = cursoRepository;
        }

        public void AdicionarAluno(Guid alunoId, Guid cursoId)
        {
            _cursoService.AdicionarAluno(alunoId, cursoId);
        }

        public CursoViewModel ObterCurso(Guid cursoId)
        {
            return CursoAdapter.ToCursoViewModel(_cursoRepository.ObterCurso(cursoId));
        }

        public IEnumerable<CursoViewModel> ObterTodos()
        {
            var cursos = _cursoRepository.ObterTodos();
            return cursos.Select(CursoAdapter.ToCursoViewModel).ToList();
        }
    }
}