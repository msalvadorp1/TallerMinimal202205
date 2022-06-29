using Microsoft.EntityFrameworkCore;
using Sol.TallerNet.ApiVentas.Repositories.Context;
using Sol.TallerNet.ApiVentas.Repositories.Entities;

namespace Sol.TallerNet.ApiVentas.Repositories.Operations
{
    public class ArticuloRepository : IArticuloRepository
    {
        private readonly TallerContext tallerContext;

        public ArticuloRepository(TallerContext tallerContext)
        {
            this.tallerContext = tallerContext;
        }
        public Articulo Get(int id)
        {
            return tallerContext.Articulo.FirstOrDefault(t => t.IdArticulo == id);
        }

        public Articulo Insert(Articulo articulo)
        {
            tallerContext.Add(articulo);
            tallerContext.SaveChanges();
            return articulo;
        }

        public List<Articulo> List()
        {
            return tallerContext.Articulo.ToList();
        }

        public Articulo Update(Articulo articulo)
        {
            tallerContext.Update(articulo);
            tallerContext.SaveChanges();
            return articulo;
        }
    }
}
