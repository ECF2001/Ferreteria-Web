using Ferreteria_Web.Models;
using Ferreteria_Web.Services;
using Microsoft.AspNetCore.Components;

namespace Ferreteria_Web.Components.Pages.Categorias;

public partial class CategoriasEditar(CategoriaService categoriaService) : ComponentBase
{
    [Parameter] public int Id { get; set; }
    private CategoriaModel? categoria;

    protected override async Task OnInitializedAsync()
    {
        categoria = categoriaService.ObtenerPorIdAsync(Id).Result;
    }

    private async Task GuardarCambios()
    {
        categoriaService.ActualizarAsync(categoria);
        NavManager.NavigateTo("/categorias");
    }
}