﻿using System.Collections.Generic;
using System.Web.Mvc;

namespace EscolaVirtual.Cadastro.Infra.Identity.Model
{
    public class SendCodeViewModel
    {
        public string SelectedProvider { get; set; }
        public ICollection<SelectListItem> Providers { get; set; }
        public string ReturnUrl { get; set; }
        public bool RememberMe { get; set; }
    }
}