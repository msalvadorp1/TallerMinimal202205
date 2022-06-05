namespace Sol.TallerNet.ApiVentas.Repositories.Entities
{
    public class PedidoDetalle
    {
        public int IdPedidoDetalle { get; set; }
        public int IdPedido { get; set; }
        public int IdArticulo { get; set; }
        public int Cantidad { get; set; }

    }
}
