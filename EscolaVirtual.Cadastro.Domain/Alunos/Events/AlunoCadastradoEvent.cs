using System;
using EscolaVirtual.Core.Domain.Interfaces;

namespace EscolaVirtual.Cadastro.Domain.Alunos.Events
{
    public class AlunoCadastradoEvent : IDomainEvent
    {
        public DateTime DataOcorrencia { get; private set; }
        public Aluno Aluno { get; private set; }
        public string EmailTitle { get; private set; }
        public string EmailBody { get; private set; }
        public int Versao { get; private set; }

        public AlunoCadastradoEvent(Aluno aluno, DateTime dateOccured)
        {
            this.Versao = 1;
            this.Aluno = aluno;
            this.DataOcorrencia = DateTime.Now;
            this.EmailTitle = "Seja bem vindo " + aluno.Nome;
            this.EmailBody = "Obrigado por se cadastrar.";
        }

        public AlunoCadastradoEvent(Aluno aluno) : this(aluno, DateTime.Now) { }
    }
}
