namespace Sol.TallerNet.ApiVentas.Applcations.Dtos.Output
{
    public class PedidoListOutput
    {
        public List<PedidoByIdOutput> Data { get; set; }
        public int TotalReg { get; set; }
        public int PagActual { get; set; }
        public int RegXPag { get; set; }
    }
}
