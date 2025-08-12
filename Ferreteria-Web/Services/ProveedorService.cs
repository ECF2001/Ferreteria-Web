using Ferreteria_Web.Models;

namespace Ferreteria_Web.Services;

public class ProveedorService(IHttpClientFactory httpClientFactory)
{
    private readonly HttpClient _httpClient = httpClientFactory.CreateClient("api");
    
    public async Task<List<ProveedorModel>> ObtenerTodosAsync()
    {
        var result = await this._httpClient.GetAsync("proveedores/GetAll");
        if (!result.IsSuccessStatusCode)
        {
            return [];
        }
        
        return (await result.Content.ReadFromJsonAsync<IEnumerable<ProveedorModel>>() ?? Array.Empty<ProveedorModel>()).ToList();
    }

    public async Task AgregarAsync(ProveedorModel proveedor)
    {
        var response = await this._httpClient.PostAsJsonAsync("proveedores/create", proveedor);
    }
    
    public async Task EliminarAsync(int id)
    {
        var response = await this._httpClient.DeleteAsync($"proveedores/Delete/{id}");
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception("Error al eliminar el proveedor");
        }
    }
    
    public async Task<ProveedorModel?> ObtenerPorIdAsync(int id)
    {
        var result = await this._httpClient.GetAsync($"proveedores/GetById/{id}");
        if (!result.IsSuccessStatusCode)
        {
            return null;
        }
        
        return await result.Content.ReadFromJsonAsync<ProveedorModel>();
    }
    
    public async Task ActualizarAsync(ProveedorModel proveedorModel)
    {
        var response = await this._httpClient.PutAsJsonAsync("proveedores/Update", proveedorModel);
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception("Error al actualizar el proveedor");
        }
    }
}