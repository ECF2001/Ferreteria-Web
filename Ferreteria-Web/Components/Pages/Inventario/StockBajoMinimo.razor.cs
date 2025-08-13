using Ferreteria_Web.Models;
using Ferreteria_Web.Services;
using Microsoft.AspNetCore.Components;

namespace Ferreteria_Web.Components.Pages.Inventario;

public partial class StockBajoMinimo(InventarioService inventarioService) : ComponentBase
{
    private List<ProductoModel> _productosBajoMinimo = new();

    protected override async Task OnInitializedAsync()
    {
        _productosBajoMinimo = await inventarioService.GetStockBajoMinimoAsync();
    }
}