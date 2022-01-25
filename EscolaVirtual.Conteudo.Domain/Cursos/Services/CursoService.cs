using System;
using EscolaVirtual.Conteudo.Domain.Cursos.Interfaces;

namespace EscolaVirtual.Conteudo.Domain.Cursos.Services
{
    public class CursoService : ICursoService
    {
        private readonly ICursoRepository _cursoRepository;

        public CursoService(ICursoRepository cursoRepository)
        {
            _cursoRepository = cursoRepository;
        }

        public void AdicionarAluno(Guid alunoId, Guid cursoId)
        {
            var cursoMatriculas = _cursoRepository.ObterMatriculas(cursoId);
            if (cursoMatriculas.Matriculas > cursoMatriculas.QuantidadeVagas) return;

            var matricula = new Matricula()
            {
                CursoId = cursoId,
                AlunoId = alunoId
            };

            _cursoRepository.AdicionarAluno(matricula);
        }
    }
}