using System.Text.Json.Serialization;

namespace Sol.TallerNet.ApiVentas.Repositories.Entities
{
    //public record Usuario(int IdUsuario, string Credenciales, string Password, DateTime FechaRegistro, bool Activo, string Nombres, string Perfil);

    public class Usuario
    {
        public int IdUsuario { get; set; }
        public string Credenciales { get; set; }
        public string Password { get; set; }
        public DateTime FechaRegistro { get; set; }
        public bool Activo { get; set; }
        public string Nombres { get; set; }
        public string Perfil { get; set; }

        [JsonIgnore]
        public virtual IEnumerable<Pedido> Pedido { get; set; }
    }

}
