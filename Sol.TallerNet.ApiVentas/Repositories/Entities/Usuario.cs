namespace Sol.TallerNet.ApiVentas.Repositories.Entities
{
    public record Usuario(int IdUsuario, string Credenciales, string Password, DateTime FechaRegistro, bool Activo, string Nombres, string Perfil);
 
}
