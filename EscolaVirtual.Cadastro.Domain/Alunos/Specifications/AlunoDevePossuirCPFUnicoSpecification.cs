using DomainValidation.Interfaces.Specification;
using EscolaVirtual.Cadastro.Domain.Alunos.Interfaces;

namespace EscolaVirtual.Cadastro.Domain.Alunos.Specifications
{
    public class AlunoDevePossuirCPFUnicoSpecification : ISpecification<Aluno>
    {
        private readonly IAlunoRepository _alunoRepository;

        public AlunoDevePossuirCPFUnicoSpecification(IAlunoRepository alunoRepository)
        {
            _alunoRepository = alunoRepository;
        }

        public bool IsSatisfiedBy(Aluno aluno)
        {
            return _alunoRepository.ObterPorCpf(aluno.CPF.Codigo) == null;
        }
    }
}