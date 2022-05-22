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
            throw new NotImplementedException();
        }

        public Articulo Insert(Articulo articulo)
        {
            throw new NotImplementedException();
        }

        public List<Articulo> List()
        {
            return tallerContext.Articulo.ToList();
        }

        public Articulo Update(Articulo articulo)
        {
            throw new NotImplementedException();
        }
    }
}
