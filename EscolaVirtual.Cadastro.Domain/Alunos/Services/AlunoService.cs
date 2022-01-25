using System.Linq;
using DomainValidation.Validation;
using EscolaVirtual.Cadastro.Domain.Alunos.Interfaces;
using EscolaVirtual.Cadastro.Domain.Alunos.Validations;
using EscolaVirtual.Core.Domain.Events;

namespace EscolaVirtual.Cadastro.Domain.Alunos.Services
{
    public class AlunoService : IAlunoService
    {
        private readonly IAlunoRepository _alunoRepository;

        public AlunoService(IAlunoRepository alunoRepository)
        {
            _alunoRepository = alunoRepository;
        }

        public Aluno Adicionar(Aluno aluno)
        {
            if(PossuiConformidade(new AlunoAptoParaCadastroValidation(_alunoRepository).Validate(aluno)))
                _alunoRepository.Adicionar(aluno);

            return aluno;
        }

        private static bool PossuiConformidade(ValidationResult validationResult)
        {
            if (validationResult == null) return true;
            var notifications = validationResult.Erros.Select(validationError => new DomainNotification(validationError.ToString(), validationError.Message)).ToList();
            if (!notifications.Any()) return true;
            notifications.ToList().ForEach(DomainEvent.Raise);
            return false;
        }
    }
}