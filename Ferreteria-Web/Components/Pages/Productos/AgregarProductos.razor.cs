using Ferreteria_Web.Models;
using Microsoft.AspNetCore.Components;

namespace Ferreteria_Web.Components.Pages.Productos;

public partial class AgregarProductos(ProductoService productoService, NavigationManager navManager) : ComponentBase
{
    private ProductoModel _nuevoProducto = new();

    private async Task AgregarProducto()
    {
        await productoService.AgregarAsync(_nuevoProducto);
        navManager.NavigateTo("/productos");
    }
}