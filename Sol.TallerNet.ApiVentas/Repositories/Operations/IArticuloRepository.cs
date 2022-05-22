using Sol.TallerNet.ApiVentas.Repositories.Entities;

namespace Sol.TallerNet.ApiVentas.Repositories.Operations
{
    public interface IArticuloRepository
    {
        List<Articulo> List();
        Articulo Insert(Articulo articulo);
        Articulo Update(Articulo articulo);
        Articulo Get(int id);
    }
}
