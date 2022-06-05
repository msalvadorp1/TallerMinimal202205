using Microsoft.EntityFrameworkCore;
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
            
            //    await tallerContext.Pedido.Include(t => t.Usuario).FirstOrDefaultAsync(t => t.IdPedido == id);

            //if (pedido != null)
            //{
            //    Usuario? usuario = await tallerContext.Usuario.FirstOrDefaultAsync(t => t.IdUsuario == pedido.CodUsuario);

            //    //pedido.NombreUsuario = usuario.Nombres;

            //}

            return pedido;
        }
    }
}
