using Ferreteria_Web.Models;
using Ferreteria_Web.Services;
using Microsoft.AspNetCore.Components;

namespace Ferreteria_Web.Components.Pages.Categorias;

public partial class Categorias(CategoriaService categoriaService, NavigationManager navigationManager) : ComponentBase
{
    private List<CategoriaModel> _categorias = new List<CategoriaModel>();

    protected override async Task OnInitializedAsync()
    {
        _categorias = await categoriaService.ObtenerTodosAsync();
    }

    private void EditarCategoria(CategoriaModel categoria)
    {
        navigationManager.NavigateTo($"/editarcategoria/{categoria.Id}");
    }

    private async void EliminarCategoria(int id)
    {
        await categoriaService.EliminarAsync(id);
        StateHasChanged();
    }
}