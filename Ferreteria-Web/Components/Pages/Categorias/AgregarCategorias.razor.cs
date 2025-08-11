using Ferreteria_Web.Models;
using Ferreteria_Web.Services;
using Microsoft.AspNetCore.Components;

namespace Ferreteria_Web.Components.Pages.Categorias;

public partial class AgregarCategorias(CategoriaService categoriaService, NavigationManager navManager) : ComponentBase
{
    private CategoriaModel _nuevaCategoria = new();

    private async Task AgregarCategoria()
    {
        await categoriaService.AgregarAsync(_nuevaCategoria);
        navManager.NavigateTo("/categorias");
    }
}