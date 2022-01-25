using EscolaVirtual.Core.Domain.ValueObjects;

namespace EscolaVirtual.Cadastro.Domain.Alunos
{
    public static class AlunoScopes
    {
        public static bool DefinirSenhaAlunoScopeEhValido(this Aluno aluno, string password, string confirmPassword)
        {
            return AssertionConcern.IsSatisfiedBy
            (
                AssertionConcern.AssertNotNullOrEmpty(password, "A senha é obrigatória"),
                AssertionConcern.AssertNotNullOrEmpty(confirmPassword, "A confirmação de senha é obrigatória"),
                AssertionConcern.AssertAreEquals(password, confirmPassword, "As senhas são iguais")
            );
        }

        public static bool ValidarSenhaAlunoScopeEhValido(this Aluno aluno, string password)
        {
            return AssertionConcern.IsSatisfiedBy
            (
                AssertionConcern.AssertNotNullOrEmpty(password, "A senha é obrigatória"),
                AssertionConcern.AssertLength(password, Aluno.SenhaMinLength, Aluno.SenhaMaxLength, "O tamanho da senha não corresponde")
            );
        }

        public static bool DefinirEmailAlunoScopeEhValido(this Aluno aluno, Email email)
        {
            return AssertionConcern.IsSatisfiedBy
            (
                AssertionConcern.AssertLength(email.Endereco, Email.EnderecoMinLength, Email.EnderecoMaxLength, "E-mail em tamanho incorreto"),
                AssertionConcern.AssertNotNullOrEmpty(email.Endereco, "O e-mail obrigatória"),
                AssertionConcern.AssertTrue(Email.IsValid(email.Endereco),"E-mail em formato inválido")
            );
        }

        public static bool DefinirCPFAlunoScopeEhValido(this Aluno aluno, CPF cpf)
        {
            return AssertionConcern.IsSatisfiedBy
            (
                AssertionConcern.AssertFixedLength(cpf.Codigo, CPF.ValorMaxCpf, "CPF em tamanho incorreto"),
                AssertionConcern.AssertNotNullOrEmpty(cpf.Codigo, "O e-mail obrigatória"),
                AssertionConcern.AssertTrue(CPF.Validar(cpf.Codigo), "CPF em formato inválido")
            );
        }
    }
}