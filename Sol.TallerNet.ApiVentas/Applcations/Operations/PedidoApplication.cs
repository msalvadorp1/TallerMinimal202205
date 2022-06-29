using AutoMapper;
using Sol.TallerNet.ApiVentas.Applcations.Dtos.Input;
using Sol.TallerNet.ApiVentas.Applcations.Dtos.Output;
using Sol.TallerNet.ApiVentas.Repositories.Entities;
using Sol.TallerNet.ApiVentas.Repositories.Operations;

namespace Sol.TallerNet.ApiVentas.Applcations.Operations
{
    public class PedidoApplication : IPedidoApplication
    {
        private readonly IPedidoRepositorio pedidoRepositorio;
        private readonly IMapper mapper;

        public PedidoApplication(IPedidoRepositorio pedidoRepositorio,
            IMapper mapper)
        {
            this.pedidoRepositorio = pedidoRepositorio;
            this.mapper = mapper;
        }
        public async Task<PedidoByIdOutput> PedidoById(int id)
        {
            Pedido ped = await pedidoRepositorio.PedidoGet(id);

            PedidoByIdOutput pedidoRes = mapper.Map<PedidoByIdOutput>(ped);

            return pedidoRes;
        }

        public async Task<PedidoListOutput> PedidoListar(string filtro, int regxpag, int nropag)
        {
            PedidoListInput pli = new PedidoListInput { Filtro = filtro, NroPag = nropag, RegXPag = regxpag };

            List<Pedido> lista = await pedidoRepositorio.Pedidos(pli);

            PedidoListOutput res = new PedidoListOutput
            {
                Data = mapper.Map<List<PedidoByIdOutput>>(lista),
                RegXPag = regxpag,
                PagActual = nropag,
                TotalReg = pli.TotalReg
            };

            return res;
        }
    }
}
