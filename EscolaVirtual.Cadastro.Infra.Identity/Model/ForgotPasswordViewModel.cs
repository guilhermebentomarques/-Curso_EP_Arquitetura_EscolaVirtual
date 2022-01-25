using System.ComponentModel.DataAnnotations;

namespace EscolaVirtual.Cadastro.Infra.Identity.Model
{
    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}
