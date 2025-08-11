using Ferreteria_Web.Models;
using Ferreteria_Web.Services;
using Microsoft.AspNetCore.Components;

namespace Ferreteria_Web.Components.Pages.Proveedores;

public partial class Proveedores(ProveedorService proveedorService) : ComponentBase
{
    private List<ProveedorModel> _proveedores = new List<ProveedorModel>();

    protected override async Task OnInitializedAsync()
    {
        _proveedores = await proveedorService.ObtenerTodosAsync();
    }
}