using Ferreteria_Web.Models;
using Ferreteria_Web.Services;
using Microsoft.AspNetCore.Components;

namespace Ferreteria_Web.Components.Pages.Inventario;

public partial class ProductosInventario(InventarioService inventarioService) : ComponentBase
{
    private List<ProductoModel> _productos = new();

    protected override async Task OnInitializedAsync()
    {
        _productos = await inventarioService.GetProductosAsync();
    }
}