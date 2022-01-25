using System;
using System.Collections.Generic;
using System.Linq;
using Dapper;
using EscolaVirtual.Conteudo.Data.Context;
using EscolaVirtual.Conteudo.Domain.Cursos;
using EscolaVirtual.Conteudo.Domain.Cursos.Interfaces;

namespace EscolaVirtual.Conteudo.Data.Repository
{
    public class CursoRepository : ICursoRepository
    {
        private readonly ConteudoContext _context;

        public CursoRepository(ConteudoContext context)
        {
            _context = context;
        }

        public void AdicionarAluno(Matricula matricula)
        {
            matricula.DataMatricula = DateTime.Now;
            _context.Matriculas.Add(matricula);
            _context.SaveChanges();
        }

        public Curso ObterCurso(Guid cursoId)
        {
            return _context.Cursos.Find(cursoId);
        }

        public IEnumerable<Curso> ObterTodos()
        {
            return _context.Cursos.Where(c => c.DataInicio >= DateTime.Now).ToList();
        }

        public CursoMatriculas ObterMatriculas(Guid cursoId)
        {
            var cn = _context.Database.Connection;

            var sql = @"select count(alunoid) from Matriculas where cursoid = @cid";
            var sql2 = @"select vagas from cursos where cursoid = @cid";
            var cursoMatriculas = new CursoMatriculas
            {
                Matriculas = cn.Query<int>(sql, new {cid = cursoId}).FirstOrDefault(),
                QuantidadeVagas = cn.Query<int>(sql2, new {cid = cursoId}).FirstOrDefault()
            };

            return cursoMatriculas;
        }
    }
}