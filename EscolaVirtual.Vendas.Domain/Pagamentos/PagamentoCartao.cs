namespace EscolaVirtual.Vendas.Domain.Pagamentos
{
    public class PagamentoCartao
    {
        public string NumeroCartao { get; private set; }
        public string NomeCartao { get; private set; }
        public int MesVencimento { get; private set; }
        public int AnoVencimento { get; private set; }
        public int CodigoSeguranca { get; private set; }

        public PagamentoCartao(string numeroCartao, string nomeCartao, int mesVencimento, int anoVencimento, int codigoSeguranca)
        {
            NumeroCartao = numeroCartao;
            NomeCartao = nomeCartao;
            MesVencimento = mesVencimento;
            AnoVencimento = anoVencimento;
            CodigoSeguranca = codigoSeguranca;
        }
    }
}