using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EscolaVirtual.Cadastro.Application.ViewModels;
using EscolaVirtual.Cadastro.Domain.Alunos;
using EscolaVirtual.Cadastro.Infra.Identity.Configuration;
using EscolaVirtual.Cadastro.Infra.Identity.Model;
using Microsoft.AspNet.Identity;

namespace EscolaVirtual.Cadastro.Application.Interfaces
{
    public interface IAlunoAppService
    {
        Aluno Adicionar(Aluno aluno);
        Aluno ObterPorId(Guid id);
        IEnumerable<Aluno> ObterTodos();
        IdentityResult AdicionarIdentidade(RegisterViewModel register);
    }
}