using Ferreteria_Web.Models;
using Ferreteria_Web.Services;
using Microsoft.AspNetCore.Components;

namespace Ferreteria_Web.Components.Pages.Proveedores;

public partial class AgregarProveedores(ProveedorService proveedorService, NavigationManager navManager) : ComponentBase
{
    private ProveedorModel _nuevoProveedor = new();

    private async Task AgregarProveedor()
    {
        await proveedorService.AgregarAsync(_nuevoProveedor);
        navManager.NavigateTo("/proveedores");
    }
}