using Sol.TallerNet.ApiVentas.Repositories.Entities;

namespace Sol.TallerNet.ApiVentas.Repositories.Operations
{
    public class ArticuloRepositoryMemory : IArticuloRepository
    {
        List<Articulo> _articuloList;

        ILogger<ArticuloRepositoryMemory> _logger;
        public ArticuloRepositoryMemory(ILogger<ArticuloRepositoryMemory> logger)
        {
            _articuloList = new List<Articulo>
            {
                new Articulo {IdArticulo = 1, Nombre= "Test1", FechaRegistro = DateTime.Now },
                new Articulo {IdArticulo = 2, Nombre= "Test2", FechaRegistro = DateTime.Now },
                new Articulo {IdArticulo =3, Nombre= "Test3", FechaRegistro = DateTime.Now }
            };
            logger.LogInformation(Guid.NewGuid().ToString());
            _logger = logger;
        }
        public Articulo Get(int id)
        {
            var articulo = _articuloList.FirstOrDefault(t => t.IdArticulo == id);
            return articulo;
        }

        public Articulo Insert(Articulo articulo)
        {
            throw new NotImplementedException();
        }

        public List<Articulo> List()
        {
            _logger.LogInformation("Llego aca");
            return _articuloList;
        }

        public Articulo Update(Articulo articulo)
        {
            throw new NotImplementedException();
        }
    }
}
