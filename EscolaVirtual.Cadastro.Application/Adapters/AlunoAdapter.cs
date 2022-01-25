using System;
using EscolaVirtual.Cadastro.Application.ViewModels;
using EscolaVirtual.Cadastro.Domain.Alunos;
using EscolaVirtual.Cadastro.Infra.Identity.Model;

namespace EscolaVirtual.Cadastro.Application.Adapters
{
    public class AlunoAdapter
    {
        public static Aluno ToDomainModel(Guid id, RegisterViewModel registerViewModel)
        {
            var aluno = new Aluno(
                id,
                registerViewModel.Nome,
                registerViewModel.CPF,
                registerViewModel.Email);

            return aluno;
        }
    }
}