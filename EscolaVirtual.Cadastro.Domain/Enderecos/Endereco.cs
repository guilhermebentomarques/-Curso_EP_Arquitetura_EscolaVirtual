using System;
using EscolaVirtual.Core.Domain.Helpers;

namespace EscolaVirtual.Cadastro.Domain.Enderecos
{
    public class Endereco
    {
        public Guid EnderecoId { get; private set; }
        public Guid AlunoId { get; private set; }
        public virtual string Logradouro { get; private set; }
        public virtual string Complemento { get; private set; }
        public virtual string Numero { get; private set; }
        public virtual string Bairro { get; private set; }
        public virtual Cidade Cidade { get; private set; }
        public Estado Estado { get; private set; }
        public virtual CEP Cep { get; private set; }

        protected Endereco()
        {
        }

        public Endereco(string logradouro, string complemento, string numero, string bairro,
            Guid cidadeId, Guid estadoId, string cep)
        {
            EnderecoId = Guid.NewGuid();
            DefinirCep(cep);
            DefinirBairro(bairro);
            DefinirCidade(cidadeId);
            DefinirEstado(estadoId);
            DefinirComplemento(complemento);
            DefinirLogradouro(logradouro);
            DefinirNumero(numero);
        }

        public void DefinirCep(string cep)
        {
            if (this.DefinirCEPScopeEhValido(cep))
            Cep = new CEP(cep);
        }

        public void DefinirComplemento(string complemento)
        {
            if (string.IsNullOrEmpty(complemento))
                complemento = "";
            Complemento = TextoHelper.ToTitleCase(complemento);
        }

        public void DefinirLogradouro(string logradouro)
        {
            if (this.DefinirLogradouroScopeEhValido(logradouro))
            Logradouro = TextoHelper.ToTitleCase(logradouro);
        }

        public void DefinirNumero(string numero)
        {
            if (this.DefinirNumeroScopeEhValido(numero))
            Numero = numero;
        }

        public void DefinirBairro(string bairro)
        {
            if (this.DefinirBairroScopeEhValido(bairro))
            Bairro = TextoHelper.ToTitleCase(bairro);
        }

        public void DefinirCidade(Guid cidadeId)
        {
            if (this.DefinirCidadeScopeEhValido(cidadeId))
            Cidade = new Cidade(cidadeId);
        }

        public void DefinirEstado(Guid estadoId)
        {
            if (this.DefinirEstadoScopeEhValido(estadoId))
            Estado = new Estado(estadoId);
        }

        public override string ToString()
        {
            return Logradouro + ", " + Numero + " - " + Complemento + " <br /> " + Bairro + " - " + Cidade.Nome + "/" + Estado.Nome;
        }
    }
}