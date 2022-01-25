using System;
using System.Data.Entity;
using EscolaVirtual.Cadastro.Infra.Identity.Model;
using Microsoft.AspNet.Identity.EntityFramework;

namespace EscolaVirtual.Cadastro.Infra.Identity.Context
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>, IDisposable
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}