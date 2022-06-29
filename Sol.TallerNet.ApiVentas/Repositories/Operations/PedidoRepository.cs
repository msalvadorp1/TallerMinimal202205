using Microsoft.EntityFrameworkCore;
using Sol.TallerNet.ApiVentas.Applcations.Dtos.Input;
using Sol.TallerNet.ApiVentas.Repositories.Context;
using Sol.TallerNet.ApiVentas.Repositories.Entities;

namespace Sol.TallerNet.ApiVentas.Repositories.Operations
{
    public class PedidoRepository : IPedidoRepositorio
    {
        private readonly TallerContext tallerContext;

        public PedidoRepository(TallerContext tallerContext)
        {
            this.tallerContext = tallerContext;
        }



        public async Task<Pedido> PedidoGet(int id)
        {
            Pedido? pedido = await (from x in tallerContext.Pedido.Include(t => t.Usuario)
                                    where x.IdPedido == id
                                    select x).FirstOrDefaultAsync();

            var res = await (from x in tallerContext.Pedido
                             join
                              y in tallerContext.Usuario
                             on x.CodUsuario equals y.IdUsuario
                             where x.IdPedido == id
                             select new
                             {
                                 Codigo = x.IdPedido,
                                 NombreUsuario = y.Nombres,
                                 Fecha = y.FechaRegistro

                             }).FirstOrDefaultAsync();

            var res2 = (tallerContext.Pedido.FromSqlRaw("exec spPedidoPorId " + id.ToString()).ToList());

            return pedido;
        }

        public async Task<List<Pedido>> Pedidos(PedidoListInput pedidoListInput)
        {
            var list = (from x in tallerContext.Pedido.Include(t => t.Usuario)
                        select x);

            if (!string.IsNullOrEmpty(pedidoListInput.Filtro))
            {
                list = list.Where(t => t.Usuario.Nombres.Contains(pedidoListInput.Filtro));
            }

            pedidoListInput.TotalReg = list.Count();

            var resultado = await list
                .Skip(pedidoListInput.NroPag * pedidoListInput.RegXPag)
                .Take(pedidoListInput.RegXPag)
                .ToListAsync();

            return resultado;
        }
    }
}
