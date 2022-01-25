using System;
using System.Web.Mvc;
using EscolaVirtual.Core.Domain.Events;
using EscolaVirtual.Core.Domain.Interfaces;
using Microsoft.AspNet.Identity;

namespace EscolaVirtual.Site.Controllers
{
    public class BaseController : Controller
    {
        // GET: Base
        public IHandler<DomainNotification> Notifications;

        public Guid AlunoId
        {
            get
            {
                return Guid.Parse(ControllerContext.HttpContext.User.Identity.GetUserId());
            } 
        }

        public BaseController()
        {
            this.Notifications = DomainEvent.Container.GetInstance<IHandler<DomainNotification>>();
        }

        public bool ValidarErrosDominio()
        {
            if (!Notifications.HasNotifications()) return false;

            foreach (var error in Notifications.GetValues())
            {
                ModelState.AddModelError(string.Empty, error.Value);
            }
            return true;
        }
    }
}