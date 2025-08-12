using Ferreteria_Web.Models;
using Microsoft.AspNetCore.Components;

namespace Ferreteria_Web.Components.Pages.Productos;

public partial class ProductosEditar(ProductoService productoService, NavigationManager NavManager) : ComponentBase
{
    [Parameter] public int Id { get; set; }
    private ProductoModel? producto;

    protected override async Task OnInitializedAsync()
    {
        producto = await productoService.ObtenerPorIdAsync(Id);
    }

    private async Task GuardarCambios()
    {
        await productoService.ActualizarAsync(producto);
        NavManager.NavigateTo("/productos");
    }
}
