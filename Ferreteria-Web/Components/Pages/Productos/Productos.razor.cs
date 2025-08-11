using Ferreteria_Web.Models;
using Microsoft.AspNetCore.Components;

namespace Ferreteria_Web.Components.Pages.Productos;

public partial class Productos(ProductoService productoService) : ComponentBase
{
    private List<ProductoModel> _productos = new List<ProductoModel>();

    protected override async Task OnInitializedAsync()
    {
        _productos = await productoService.ObtenerTodosAsync();
    }
}