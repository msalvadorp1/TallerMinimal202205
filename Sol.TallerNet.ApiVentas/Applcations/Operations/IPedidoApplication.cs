using Sol.TallerNet.ApiVentas.Applcations.Dtos.Input;
using Sol.TallerNet.ApiVentas.Applcations.Dtos.Output;
using Sol.TallerNet.ApiVentas.Repositories.Entities;

namespace Sol.TallerNet.ApiVentas.Applcations.Operations
{
    public interface IPedidoApplication
    {
        Task<PedidoListOutput> PedidoListar(PedidoListInput pedidoListInput);
        Task<Pedido> PedidoById(int id);

    }
}
