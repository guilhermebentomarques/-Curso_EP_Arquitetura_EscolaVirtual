using System.Collections.Generic;

namespace EscolaVirtual.Cadastro.Infra.Identity.Model
{
    public class ConfigureTwoFactorViewModel
    {
        public string SelectedProvider { get; set; }
        public ICollection<string> Providers { get; set; }
    }
}