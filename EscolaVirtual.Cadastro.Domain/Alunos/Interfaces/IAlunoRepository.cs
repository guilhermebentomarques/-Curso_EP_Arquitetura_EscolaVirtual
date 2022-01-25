using System;

namespace EscolaVirtual.Cadastro.Domain.Alunos.Interfaces
{
    public interface IAlunoRepository
    {
        void Adicionar(Aluno aluno);
        void Atualizar(Aluno aluno);
        void DefinirStatusPremium(Guid alunoId);
        Aluno ObterPorId(Guid id);
        Aluno ObterPorCpf(string cpf);
        Aluno ObterPorEmail(string email);
    }
}