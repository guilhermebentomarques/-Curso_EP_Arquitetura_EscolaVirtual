using System.ComponentModel.DataAnnotations;

namespace EscolaVirtual.Cadastro.Infra.Identity.Model
{
    public class AddPhoneNumberViewModel
    {
        [Required]
        [Phone]
        [Display(Name = "Phone Number")]
        public string Number { get; set; }
    }
}