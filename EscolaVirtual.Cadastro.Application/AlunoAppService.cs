using System;
using System.Collections.Generic;
using EscolaVirtual.Cadastro.Application.Adapters;
using EscolaVirtual.Cadastro.Application.Interfaces;
using EscolaVirtual.Cadastro.Data.Interfaces;
using EscolaVirtual.Cadastro.Domain.Alunos;
using EscolaVirtual.Cadastro.Domain.Alunos.Events;
using EscolaVirtual.Cadastro.Domain.Alunos.Interfaces;
using EscolaVirtual.Cadastro.Infra.Identity.Configuration;
using EscolaVirtual.Cadastro.Infra.Identity.Context;
using EscolaVirtual.Cadastro.Infra.Identity.Model;
using EscolaVirtual.Core.Domain.Events;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace EscolaVirtual.Cadastro.Application
{
    public class AlunoAppService : ApplicationService, IAlunoAppService
    {
        private readonly IAlunoService _alunoService;
        private ApplicationUserManager _userManager;

        public AlunoAppService(IAlunoService alunoService, IUnitOfWork unitOfWork, ApplicationUserManager userManager)
            : base(unitOfWork)
        {
            _alunoService = alunoService;
            _userManager = userManager;
        }

        public Aluno Adicionar(Aluno aluno)
        {
            if (!Notifications.HasNotifications())
            {
                _alunoService.Adicionar(aluno);
            }

            return aluno;
        }

        public IdentityResult AdicionarIdentidade(RegisterViewModel register)
        {
            var store = new UserStore<ApplicationUser>(new ApplicationDbContext()) {AutoSaveChanges = false};
            var manager = _userManager;

            var user = new ApplicationUser {UserName = register.Email, Email = register.Email};
            var result = manager.Create(user, register.Password);

            if (result.Succeeded)
            {
                var aluno = AlunoAdapter.ToDomainModel(Guid.Parse(user.Id), register);
                Adicionar(aluno);

                if (Commit())
                {
                    DomainEvent.Raise(new AlunoCadastradoEvent(aluno));
                }
                else
                {
                    manager.Delete(user);
                    return new IdentityResult(Notifications.ToString());
                }
                
            }
            else
            {
                var errosBr = new List<string>();
                var notificationList = new List<DomainNotification>();

                foreach (var erro in result.Errors)
                {
                    string erroBr;
                    if (erro.Contains("Passwords must have at least one digit ('0'-'9')."))
                    {
                        erroBr = "A senha precisa ter ao menos um dígito";
                        notificationList.Add(new DomainNotification("IdentityValidation", erroBr));
                        errosBr.Add(erroBr);
                    }
                    if (erro.Contains("Passwords must have at least one non letter or digit character."))
                    {
                        erroBr = "A senha precisa ter ao menos um caractere especial (@, #, etc...)";
                        notificationList.Add(new DomainNotification("IdentityValidation", erroBr));
                        errosBr.Add(erroBr);
                    }
                    if (erro.Contains("Passwords must have at least one lowercase ('a'-'z')."))
                    {
                        erroBr = "A senha precisa ter ao menos uma letra em minúsculo";
                        notificationList.Add(new DomainNotification("IdentityValidation", erroBr));
                        errosBr.Add(erroBr);
                    }
                    if (erro.Contains("Passwords must have at least one uppercase ('A'-'Z')."))
                    {
                        erroBr = "A senha precisa ter ao menos uma letra em maiúsculo";
                        notificationList.Add(new DomainNotification("IdentityValidation", erroBr));
                        errosBr.Add(erroBr);
                    }
                    if (erro.Contains("Name " + register.Email + " is already taken"))
                    {
                        erroBr = "E-mail já registrado, esqueceu sua senha?";
                        notificationList.Add(new DomainNotification("IdentityValidation", erroBr));
                        errosBr.Add(erroBr);
                    }
                }
                notificationList.ForEach(DomainEvent.Raise);
                result = new IdentityResult(errosBr);
            }

            return result;
        }

        public Aluno ObterPorId(Guid id)
        {
            throw new NotImplementedException(); // return _alunoReadRepository.ObterPorId(id);
        }

        public IEnumerable<Aluno> ObterTodos()
        {
            throw new NotImplementedException(); //return _alunoReadRepository.ObterTodos();
        }
    }
}