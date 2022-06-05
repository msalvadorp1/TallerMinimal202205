using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sol.TallerNet.ApiVentas.Repositories.Entities;

namespace Sol.TallerNet.ApiVentas.Repositories.Context.Configurations
{
    public class PedidoConfiguration : IEntityTypeConfiguration<Pedido>
    {
        public void Configure(EntityTypeBuilder<Pedido> builder)
        {
            builder.HasKey(t => t.IdPedido);

            //relaciones entre entidades
            builder
                .HasOne<Usuario>(t => t.Usuario)
                .WithMany(x => x.Pedido)
                .HasForeignKey(x => x.CodUsuario);
        }
    }
}
