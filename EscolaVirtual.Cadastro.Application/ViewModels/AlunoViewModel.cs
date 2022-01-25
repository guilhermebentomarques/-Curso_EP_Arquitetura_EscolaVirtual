using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EscolaVirtual.Cadastro.Application.ViewModels
{
    public class AlunoViewModel
    {
        public AlunoViewModel()
        {
            AlunoId = Guid.NewGuid();
        }

        [Key]
        public Guid AlunoId { get; set; }

        [Required(ErrorMessage = "Preencha o campo Nome")]
        [MaxLength(150, ErrorMessage = "Máximo 150 caracteres")]
        [MinLength(2, ErrorMessage = "Mínimo 2 caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Preencha o campo CPF")]
        [MaxLength(11, ErrorMessage = "Máximo 11 caracteres")]
        [DisplayName("CPF")]
        public string CPF { get; set; }

        [ScaffoldColumn(false)]
        public bool Ativo { get; set; }

        [Required(ErrorMessage = "Preencha o campo E-mail")]
        [MaxLength(100, ErrorMessage = "Máximo 100 caracteres")]
        [EmailAddress(ErrorMessage = "Preencha um E-mail válido")]
        [DisplayName("E-mail")]
        public string Email { get; set; }

        //[ScaffoldColumn(false)]
        //public DomainValidation.Validation.ValidationResult ValidationResult { get; set; }
    }
}