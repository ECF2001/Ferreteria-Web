namespace Ferreteria_Web.Models;

public class VentaModel
{
    public int Id { get; set; }
    public DateTime FechaVenta { get; set; }
    public int IdUsuario { get; set; }
    public decimal TotalVenta { get; set; }

    public decimal IVA { get; set; }
    public decimal TotalFinal { get; set; }
}