using System;

namespace EscolaVirtual.Cadastro.Domain.Enderecos
{
    public class Estado
    {
        public Guid EstadoId { get; private set; }
        public string Nome { get; private set; }
        public string UF { get; private set; }

        public Estado(string uf, string nome, Guid estadoId)
        {
            UF = uf;
            Nome = nome;
            EstadoId = estadoId;
        }

        public Estado(Guid estadoId)
        {
            EstadoId = estadoId;
        }
    }
}