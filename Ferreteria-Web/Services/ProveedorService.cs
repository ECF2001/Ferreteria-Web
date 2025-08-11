using Ferreteria_Web.Models;

namespace Ferreteria_Web.Services;

public class ProveedorService(IHttpClientFactory httpClientFactory)
{
    private readonly HttpClient _httpClient = httpClientFactory.CreateClient("api");
    
    public async Task<List<ProveedorModel>> ObtenerTodosAsync()
    {
        var result = await this._httpClient.GetAsync("producto");
        if (!result.IsSuccessStatusCode)
        {
            return [];
        }
        
        return (await result.Content.ReadFromJsonAsync<IEnumerable<ProveedorModel>>() ?? Array.Empty<ProveedorModel>()).ToList();
    }

    public async Task AgregarAsync(ProveedorModel proveedor)
    {
        var response = await this._httpClient.PostAsJsonAsync("proveedor", proveedor);
    }
}