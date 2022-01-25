using EscolaVirtual.Conteudo.Application.ViewModels;
using EscolaVirtual.Conteudo.Domain.Cursos;

namespace EscolaVirtual.Conteudo.Application.Adapters
{
    public class CursoAdapter
    {
        public static CursoViewModel ToCursoViewModel(Curso curso)
        {
            var cursoViewModel = new CursoViewModel()
            {
                CursoId = curso.CursoId,
                Nome = curso.Nome,
                DataInicio = curso.DataInicio,
                Vagas = curso.Vagas,
                Valor = curso.Valor
            };

            return cursoViewModel;
        }

        public static Matricula ToMatriculaDomain(MatriculaViewModel matriculaViewModel)
        {
            var matricula = new Matricula()
            {
                CursoId = matriculaViewModel.CursoId,
                AlunoId = matriculaViewModel.AlunoId,
                MatriculaId = matriculaViewModel.MatriculaId,
                DataMatricula = matriculaViewModel.DataMatricula
            };

            return matricula;
        }
    }
}