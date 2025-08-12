using Ferreteria_Web.Models;
using Microsoft.AspNetCore.Components;

namespace Ferreteria_Web.Components.Pages.Productos;

public partial class Productos(ProductoService productoService, NavigationManager navigationManager) : ComponentBase
{
    private List<ProductoModel> _productos = new List<ProductoModel>();

    protected override async Task OnInitializedAsync()
    {
        _productos = await productoService.ObtenerTodosAsync();
    }
    
    private void EditarProducto(ProductoModel producto)
    {
        navigationManager.NavigateTo($"/editarproducto/{producto.Id}");
    }

    private async void EliminarProducto(int id)
    {
        await productoService.EliminarAsync(id);
        StateHasChanged();
    }
}