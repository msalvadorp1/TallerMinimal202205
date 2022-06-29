using Sol.TallerNet.ApiVentas.Applcations.Dtos.Input;
using Sol.TallerNet.ApiVentas.Repositories.Entities;

namespace Sol.TallerNet.ApiVentas.Repositories.Operations
{
    public interface IPedidoRepositorio
    {
        Task<Pedido> PedidoGet(int id);
        Task<List<Pedido>> Pedidos(PedidoListInput pedidoListInput);
    }
}
