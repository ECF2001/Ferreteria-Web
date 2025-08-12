using Ferreteria_Web.Models;
using Ferreteria_Web.Services;
using Microsoft.AspNetCore.Components;

namespace Ferreteria_Web.Components.Pages.Proveedores;

public partial class ProveedoresEditar(ProveedorService proveedorService, NavigationManager NavManager) : ComponentBase
{
    [Parameter] public int Id { get; set; }
    private ProveedorModel proveedor;

    protected override async Task OnInitializedAsync()
    {
        proveedor = await proveedorService.ObtenerPorIdAsync(Id);
    }

   
}