using Ferreteria_Web.Models;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace Ferreteria_Web.Components.Pages.Productos;

public partial class AgregarProductos : ComponentBase
{
    [Inject] private ProductoService productoService { get; set; } = default!;
    [Inject] private NavigationManager navManager { get; set; } = default!;

    private ProductoModel _nuevoProducto = new ProductoModel();

    private async Task OnValidSubmit()
    {
        await productoService.AgregarAsync(_nuevoProducto);
        navManager.NavigateTo("/productos");
    }
}