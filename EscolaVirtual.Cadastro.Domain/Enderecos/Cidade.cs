using System;

namespace EscolaVirtual.Cadastro.Domain.Enderecos
{
    public class Cidade
    {
        public Guid CidadeId { get; private set; }
        public Guid EstadoId { get; private set; }
        public string Nome { get; private set; }

        public Cidade(Guid cidadeId)
        {
            CidadeId = cidadeId;
        }

        public Cidade(string nome, Guid cidadeId, Guid estadoId)
        {
            Nome = nome;
            CidadeId = cidadeId;
            EstadoId = estadoId;
        }
    }
}