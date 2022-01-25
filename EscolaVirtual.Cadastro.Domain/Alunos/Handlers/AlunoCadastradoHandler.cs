using System.Collections.Generic;
using EscolaVirtual.Cadastro.Domain.Alunos.Events;
using EscolaVirtual.Core.Domain.Interfaces;
using EscolaVirtual.Core.Infra.Email;

namespace EscolaVirtual.Cadastro.Domain.Alunos.Handlers
{
    public class AlunoCadastradoHandler : IHandler<AlunoCadastradoEvent>
    {
        private List<AlunoCadastradoEvent> _notifications;
        private readonly IEnvioEmail _envioEmail;

        public AlunoCadastradoHandler(IEnvioEmail envioEmail)
        {
            _envioEmail = envioEmail;
        }

        public void Handle(AlunoCadastradoEvent args)
        {
            // Envia Email!
            _envioEmail.EnviarAsync(args.Aluno.Nome,
                args.Aluno.Email.Endereco,
                args.EmailTitle,
                args.EmailBody);
        }

        public IEnumerable<AlunoCadastradoEvent> Notify()
        {
            return GetValues();
        }

        public bool HasNotifications()
        {
            return GetValues().Count > 0;
        }

        public List<AlunoCadastradoEvent> GetValues()
        {
            return _notifications;
        }

        public void Dispose()
        {
            _notifications = new List<AlunoCadastradoEvent>();
        }
    }
}