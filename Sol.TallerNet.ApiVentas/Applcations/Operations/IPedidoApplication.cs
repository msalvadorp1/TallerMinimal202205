using Sol.TallerNet.ApiVentas.Applcations.Dtos.Input;
using Sol.TallerNet.ApiVentas.Applcations.Dtos.Output;

namespace Sol.TallerNet.ApiVentas.Applcations.Operations
{
    public interface IPedidoApplication
    {
        Task<PedidoListOutput> PedidoListar(PedidoListInput pedidoListInput);
        Task<PedidoByIdOutput> PedidoById(int id);

    }
}
