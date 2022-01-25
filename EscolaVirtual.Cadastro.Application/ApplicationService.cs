using EscolaVirtual.Cadastro.Data.Interfaces;
using EscolaVirtual.Cadastro.Domain.Alunos;
using EscolaVirtual.Cadastro.Domain.Alunos.Handlers;
using EscolaVirtual.Core.Domain.Events;
using EscolaVirtual.Core.Domain.Interfaces;

namespace EscolaVirtual.Cadastro.Application
{
    public class ApplicationService
    {
        private readonly IUnitOfWork _unitOfWork;
        protected readonly IHandler<DomainNotification> Notifications;
        protected AlunoCadastradoHandler AlunoCadastradoHandler;

        public ApplicationService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
            this.Notifications = DomainEvent.Container.GetInstance<IHandler<DomainNotification>>();
            this.AlunoCadastradoHandler = DomainEvent.Container.GetInstance<AlunoCadastradoHandler>();
        }

        public bool Commit()
        {
            if(Notifications.HasNotifications())
                return false;

            _unitOfWork.Commit();
            return true;
        }
    }
}