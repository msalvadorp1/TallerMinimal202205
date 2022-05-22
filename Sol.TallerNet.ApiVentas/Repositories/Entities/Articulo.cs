namespace Sol.TallerNet.ApiVentas.Repositories.Entities
{
    public class Articulo
    {

        public int IdArticulo { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        public decimal Costo { get; set; }
        public DateTime? FechaRegistro { get; set; }
       

    }
}
