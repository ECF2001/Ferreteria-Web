using Ferreteria_Web.Models;

namespace Ferreteria_Web.Services;

public class CompraService(IHttpClientFactory httpClientFactory)
{
    private readonly HttpClient _httpClient = httpClientFactory.CreateClient("api");
    
    public async Task<List<CompraModel>> ObtenerTodosAsync()
    {
        var result = await this._httpClient.GetAsync("compra/GetAll");
        if (!result.IsSuccessStatusCode)
        {
            return [];
        }
        
        return (await result.Content.ReadFromJsonAsync<IEnumerable<CompraModel>>() ?? Array.Empty<CompraModel>()).ToList();
    }
}