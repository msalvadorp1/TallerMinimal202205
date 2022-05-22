using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Sol.TallerNet.ApiVentas.Repositories.Entities;

namespace Sol.TallerNet.ApiVentas.Repositories.Context.Configurations
{
    public class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            var boolCharConverter = 
                new ValueConverter<bool, string>(v => v ? "1" : "0", v => v == "1");

            builder.ToTable("Tbl_Usuario");
            builder.HasKey(t => t.IdUsuario);
            builder.Property(t => t.Credenciales).HasColumnName("CodUsuario");
            builder.Property(t => t.Password).HasColumnName("Clave");
            builder.Property(t => t.FechaRegistro).HasColumnName("Fec_Registro");

            builder.Property(t => t.Activo).HasConversion(boolCharConverter);

        }
    }
}
