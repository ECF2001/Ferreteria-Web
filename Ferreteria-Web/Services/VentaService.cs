using Ferreteria_Web.Models;

namespace Ferreteria_Web.Services;

public class VentaService(IHttpClientFactory httpClientFactory)
{
    private readonly HttpClient _httpClient = httpClientFactory.CreateClient("api");
    
    public async Task<List<VentaModel>> ObtenerTodosAsync()
    {
        var result = await this._httpClient.GetAsync("venta/GetAll");
        if (!result.IsSuccessStatusCode)
        {
            return [];
        }
        
        return (await result.Content.ReadFromJsonAsync<IEnumerable<VentaModel>>() ?? Array.Empty<VentaModel>()).ToList();
    }

    public async Task AgregarAsync(VentaModel venta)
    {
        var response = await this._httpClient.PostAsJsonAsync("venta/create", venta);
    }
    
    public async Task EliminarAsync(int id)
    {
        var response = await this._httpClient.DeleteAsync($"venta/Delete/{id}");
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception("Error al eliminar la venta");
        }
    }
    
    public async Task<VentaModel?> ObtenerPorIdAsync(int id)
    {
        var result = await this._httpClient.GetAsync($"venta/GetById/{id}");
        if (!result.IsSuccessStatusCode)
        {
            return null;
        }
        
        return await result.Content.ReadFromJsonAsync<VentaModel>();
    }
    
    public async Task ActualizarAsync(VentaModel ventaModel)
    {
        var response = await this._httpClient.PutAsJsonAsync("venta/Update", ventaModel);
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception("Error al actualizar la venta");
        }
    }
}