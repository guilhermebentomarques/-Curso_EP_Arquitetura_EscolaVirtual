using System;

namespace EscolaVirtual.Conteudo.Application.ViewModels
{
    public class MatriculaViewModel
    {
        public MatriculaViewModel()
        {
            MatriculaId = Guid.NewGuid();
        }

        public Guid MatriculaId { get; set; }
        public Guid AlunoId { get; set; }
        public Guid CursoId { get; set; }
        public DateTime DataMatricula { get; set; } 
    }
}