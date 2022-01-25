using System.ComponentModel.DataAnnotations;

namespace EscolaVirtual.Cadastro.Infra.Identity.Model
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}