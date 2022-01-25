using System;
using System.Data.Entity;
using System.Linq;
using EscolaVirtual.Cadastro.Data.Context;
using EscolaVirtual.Cadastro.Domain.Alunos;
using EscolaVirtual.Cadastro.Domain.Alunos.Interfaces;

namespace EscolaVirtual.Cadastro.Data.Repository
{
    public class AlunoRepository : IAlunoRepository
    {
        private readonly AlunosContext _db;

        public AlunoRepository(AlunosContext db)
        {
            _db = db;

        }

        public void Adicionar(Aluno aluno)
        {
            _db.Alunos.Add(aluno);
        }

        public void Atualizar(Aluno aluno)
        {
            var entry = _db.Entry(aluno);
            _db.Set<Aluno>().Attach(aluno);
            entry.State = EntityState.Modified;
        }

        public void DefinirStatusPremium(Guid alunoId)
        {
            var aluno = ObterPorId(alunoId);
            aluno.AtivarPremium();

            _db.Set<Aluno>().Attach(aluno);
            _db.Entry(aluno).Property(a => a.Premium).IsModified = true;
            _db.SaveChanges();
        }

        public Aluno ObterPorId(Guid id)
        {
            return _db.Alunos.Find(id);
        }

        public Aluno ObterPorCpf(string cpf)
        {
            return _db.Alunos.FirstOrDefault(a => a.CPF.Codigo == cpf);
        }

        public Aluno ObterPorEmail(string email)
        {
            return _db.Alunos.FirstOrDefault(a => a.Email.Endereco == email);
        }
    }
}