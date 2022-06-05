using Sol.TallerNet.ApiVentas.Repositories.Entities;

namespace Sol.TallerNet.ApiVentas.Repositories.Operations
{
    public interface IPedidoRepositorio
    {
        Task<Pedido> PedidoGet(int id);
    }
}
