using DomainValidation.Interfaces.Specification;
using EscolaVirtual.Cadastro.Domain.Alunos.Interfaces;

namespace EscolaVirtual.Cadastro.Domain.Alunos.Specifications
{
    public class AlunoDevePossuirEmailUnicoSpecification : ISpecification<Aluno>
    {
        private readonly IAlunoRepository _alunoRepository;

        public AlunoDevePossuirEmailUnicoSpecification(IAlunoRepository alunoRepository)
        {
            _alunoRepository = alunoRepository;
        }

        public bool IsSatisfiedBy(Aluno aluno)
        {
            return _alunoRepository.ObterPorEmail(aluno.Email.Endereco) == null;
        }
    }
}