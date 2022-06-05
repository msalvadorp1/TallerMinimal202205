namespace Sol.TallerNet.ApiVentas.Repositories.Entities
{
    public class Pedido
    {
        public int IdPedido { get; set; }
        public DateTime Fecha { get; set; }
        public int CodUsuario { get; set; }


        public virtual Usuario Usuario { get; set; }
        //public string NombreUsuario { get; set; }
        //public string PerfilUsuario { get; set; }
    }
}
