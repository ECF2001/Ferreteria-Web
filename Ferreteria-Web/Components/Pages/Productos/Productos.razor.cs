using Ferreteria_Web.Models;
using Microsoft.AspNetCore.Components;

namespace Ferreteria_Web.Components.Pages.Productos;

public partial class Productos(ProductoService productoService) : ComponentBase
{
    private List<ProductoModel> productos;

    protected override async Task OnInitializedAsync()
    {
        productos = await productoService.ObtenerTodosAsync();
    }
}