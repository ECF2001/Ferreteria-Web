namespace Ferreteria_Web.Models;

public class CompraModel
{
    public int Id { get; set; }
    public DateTime Fecha_Compra { get; set; }
    public int Id_Proveedor { get; set; }
    public decimal Total { get; set; }
}