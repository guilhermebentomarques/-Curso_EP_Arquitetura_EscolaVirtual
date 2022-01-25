namespace EscolaVirtual.Vendas.Domain.Pedidos
{
    public enum StatusPedido
    {
        Iniciado = 0,
        AguardandoPagamento,
        Pago,
        Cancelado,
        Estornado
    }
}