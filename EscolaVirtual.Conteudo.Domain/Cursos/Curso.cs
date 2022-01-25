using System;

namespace EscolaVirtual.Conteudo.Domain.Cursos
{
    public class Curso
    {
        public Curso()
        {
            CursoId = Guid.NewGuid();
        }

        public Guid CursoId { get; set; }
        public string Nome { get; set; }
        public decimal Valor { get; set; }
        public DateTime DataInicio { get; set; }
        public int Vagas { get; set; }
    }
}