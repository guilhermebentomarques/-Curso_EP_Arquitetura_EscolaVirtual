using System;
using EscolaVirtual.Core.Domain.ValueObjects;

namespace EscolaVirtual.Cadastro.Domain.Enderecos
{
    public static class EnderecoScopes
    {
        public static bool DefinirCEPScopeEhValido(this Endereco endereco, string cep)
        {
            return AssertionConcern.IsSatisfiedBy
            (
                AssertionConcern.AssertNotNullOrEmpty(cep, "O cep é obrigatório"),
                AssertionConcern.AssertFixedLength(cep, CEP.CepMaxLength, "O CEP está em tamanho incorreto")
            );
        }

        public static bool DefinirLogradouroScopeEhValido(this Endereco endereco, string logradouro)
        {
            return AssertionConcern.IsSatisfiedBy
            (
                AssertionConcern.AssertNotNullOrEmpty(logradouro, "O logradouro é obrigatório")
            );
        }
        public static bool DefinirNumeroScopeEhValido(this Endereco endereco, string numero)
        {
            return AssertionConcern.IsSatisfiedBy
            (
                AssertionConcern.AssertNotNullOrEmpty(numero, "O número é obrigatório")
            );
        }
        public static bool DefinirBairroScopeEhValido(this Endereco endereco, string bairro)
        {
            return AssertionConcern.IsSatisfiedBy
            (
                AssertionConcern.AssertNotNullOrEmpty(bairro, "O bairro é obrigatório")
            );
        }
        public static bool DefinirCidadeScopeEhValido(this Endereco endereco, Guid cidadeId)
        {
            return AssertionConcern.IsSatisfiedBy
            (
                AssertionConcern.AssertTrue(cidadeId == Guid.Empty, "A cidade não existe")
            );
        }

        public static bool DefinirEstadoScopeEhValido(this Endereco endereco, Guid estadoId)
        {
            return AssertionConcern.IsSatisfiedBy
            (
                AssertionConcern.AssertTrue(estadoId == Guid.Empty, "A estado não existe")
            );
        }
    }
}