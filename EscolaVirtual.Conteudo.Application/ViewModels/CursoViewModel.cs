using System;
using System.ComponentModel;

namespace EscolaVirtual.Conteudo.Application.ViewModels
{
    public class CursoViewModel
    {
        public CursoViewModel()
        {
            CursoId = Guid.NewGuid();
        }

        public Guid CursoId { get; set; }
        public string Nome { get; set; }
        public decimal Valor { get; set; }

        [DisplayName("Data de Início")]
        public DateTime DataInicio { get; set; }

        [DisplayName("Vagas Disponíveis")]
        public int Vagas { get; set; } 
    }
}