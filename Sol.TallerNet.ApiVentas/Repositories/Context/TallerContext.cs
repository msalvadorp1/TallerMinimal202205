using Microsoft.EntityFrameworkCore;
using Sol.TallerNet.ApiVentas.Repositories.Entities;

namespace Sol.TallerNet.ApiVentas.Repositories.Context
{
    public class TallerContext : DbContext
    {
        public TallerContext(DbContextOptions<TallerContext> options) : base(options)
        {

        }
        public DbSet<Articulo> Articulo { get; set; }
    }
}
