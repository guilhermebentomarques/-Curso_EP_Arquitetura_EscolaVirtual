using System;
using DomainValidation.Validation;
using EscolaVirtual.Cadastro.Domain.Enderecos;
using EscolaVirtual.Core.Domain.ValueObjects;

namespace EscolaVirtual.Cadastro.Domain.Alunos
{
    public class Aluno
    {
        public Guid AlunoId { get; private set; }
        public string Nome { get; private set; }
        public CPF CPF { get; private set; }
        public bool Ativo { get; private set; }
        public Email Email { get; private set; }
        public bool Premium { get; private set; }
        public Endereco Endereco { get; private set; }
        public ValidationResult ValidationResult { get; set; }

        // Construtor necessário para o EF retornar resultado.
        protected Aluno()
        {
            
        }

        public Aluno(Guid alunoId, string nome, string cpf, string email)
        {
            AlunoId = alunoId;
            Nome = nome;
            DefinirCPF(cpf);
            Ativo = false;
            DefinirEmail(email);
        }

        public void DefinirEndereco(Endereco endereco)
        {
            Endereco = endereco;
        }

        public void DefinirEmail(string email)
        {
            var myEmail = new Email(email);

            if (this.DefinirEmailAlunoScopeEhValido(myEmail))
                Email = myEmail;
        }

        public void DefinirCPF(string cpf)
        {
            var myCPF = new CPF(cpf);

            if (this.DefinirCPFAlunoScopeEhValido(myCPF))
                CPF = myCPF;
        }

        public void ValidarSenha(string senha)
        {
            if (this.ValidarSenhaAlunoScopeEhValido(senha))
                return;
        }

        public void Ativar()
        {
            Ativo = true;
        }

        public void AtivarPremium()
        {
            Premium = true;
        }

        public void Inativar()
        {
            Ativo = false;
        }

        #region Constantes

        public const int SenhaMinLength = 6;
        public const int SenhaMaxLength = 30;

        #endregion
    }
}