using Microsoft.EntityFrameworkCore;
using Sol.TallerNet.ApiVentas.Repositories.Context.Configurations;
using Sol.TallerNet.ApiVentas.Repositories.Entities;

namespace Sol.TallerNet.ApiVentas.Repositories.Context
{
    public class TallerContext : DbContext
    {
        public TallerContext(DbContextOptions<TallerContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ArticuloConfiguration());
            modelBuilder.ApplyConfiguration(new UsuarioConfiguration());
            modelBuilder.ApplyConfiguration(new PedidoConfiguration());
            modelBuilder.ApplyConfiguration(new PedidoDetalleConfiguration());
            //modelBuilder.Entity<Articulo>().HasKey(t => t.IdArticulo);
            base.OnModelCreating(modelBuilder);
        }


        public override int SaveChanges()
        {
            //aca mi auditoria
            return base.SaveChanges();
        }

        public DbSet<Articulo> Articulo { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Pedido> Pedido { get; set; }
        public DbSet<PedidoDetalle> PedidoDetalle { get; set; }
    }
}
