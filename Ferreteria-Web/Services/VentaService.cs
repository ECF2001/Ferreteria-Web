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
}