using DomainValidation.Validation;
using EscolaVirtual.Cadastro.Domain.Alunos.Interfaces;
using EscolaVirtual.Cadastro.Domain.Alunos.Specifications;

namespace EscolaVirtual.Cadastro.Domain.Alunos.Validations
{
    public class AlunoAptoParaCadastroValidation : Validator<Aluno>
    {
        public AlunoAptoParaCadastroValidation(IAlunoRepository alunoRepository)
        {
            var cpfDuplicado = new AlunoDevePossuirCPFUnicoSpecification(alunoRepository);
            var emailDuplicado = new AlunoDevePossuirEmailUnicoSpecification(alunoRepository);

            base.Add("cpfDuplicado", new Rule<Aluno>(cpfDuplicado, "CPF já cadastrado!"));
            base.Add("emailDuplicado", new Rule<Aluno>(emailDuplicado, "E-mail já cadastrado!"));
        }
    }
}