using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sol.TallerNet.ApiVentas.Repositories.Entities
{
    public class Articulo
    {
        //[Key]
        public int IdArticulo { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        public decimal Costo { get; set; }
        public DateTime? FechaRegistro { get; set; }
       

    }
}
