using Sol.TallerNet.ApiVentas.Applcations.Dtos.Input;
using Sol.TallerNet.ApiVentas.Applcations.Dtos.Output;
using Sol.TallerNet.ApiVentas.Repositories.Entities;
using Sol.TallerNet.ApiVentas.Repositories.Operations;

namespace Sol.TallerNet.ApiVentas.Applcations.Operations
{
    public class PedidoApplication : IPedidoApplication
    {
        private readonly IPedidoRepositorio pedidoRepositorio;

        public PedidoApplication(IPedidoRepositorio pedidoRepositorio)
        {
            this.pedidoRepositorio = pedidoRepositorio;
        }
        public async Task<Pedido> PedidoById(int id)
        {
            Pedido ped = await pedidoRepositorio.PedidoGet(id);

            return ped;
        }

        public Task<PedidoListOutput> PedidoListar(PedidoListInput pedidoListInput)
        {
            throw new NotImplementedException();
        }
    }
}
