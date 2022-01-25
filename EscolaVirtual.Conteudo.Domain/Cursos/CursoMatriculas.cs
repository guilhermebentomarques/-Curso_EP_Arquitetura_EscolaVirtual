using System;

namespace EscolaVirtual.Conteudo.Domain.Cursos
{
    public class CursoMatriculas
    {
        public Guid CursoId { get; set; }
        public int QuantidadeVagas { get; set; }
        public int Matriculas { get; set; }
        public DateTime DataInicio { get; set; }
    }
}