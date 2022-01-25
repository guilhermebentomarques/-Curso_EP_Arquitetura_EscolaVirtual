using System;

namespace EscolaVirtual.Conteudo.Domain.Cursos
{
    public class Matricula
    {
        public Matricula()
        {
            MatriculaId = Guid.NewGuid();
        }

        public Guid MatriculaId { get; set; }
        public Guid AlunoId { get; set; }
        public Guid CursoId { get; set; }
        public DateTime DataMatricula { get; set; }
    }
}