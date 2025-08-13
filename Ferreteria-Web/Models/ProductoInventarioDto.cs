namespace Ferreteria_Web.Models
{
    public class ProductoInventarioDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Categoria { get; set; }
        public int StockActual { get; set; }
        public int StockMinimo { get; set; }
        public decimal PrecioVenta { get; set; }
    }
}