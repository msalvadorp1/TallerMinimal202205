using Sol.TallerNet.ApiVentas.Repositories.Operations;

namespace Sol.TallerNet.ApiVentas.Applcations
{
    public class ArticuloApplication : IArticuloApplication
    {
        private readonly IArticuloRepository articuloRepository;

        public ArticuloApplication(IArticuloRepository articuloRepository)
        {
            this.articuloRepository = articuloRepository;
        }

        public string Get()
        {
            return "hola mundo";
        }
    }
}
