using Ferreteria_Web.Models;

namespace Ferreteria_Web.Services;

public class CategoriaService(IHttpClientFactory httpClientFactory)
{
    private readonly HttpClient _httpClient = httpClientFactory.CreateClient("api");

    public async Task<List<CategoriaModel>> ObtenerTodosAsync()
    {
        var result = await this._httpClient.GetAsync("categoria");
        if (!result.IsSuccessStatusCode)
        {
            return [];
        }
        
        return (await result.Content.ReadFromJsonAsync<IEnumerable<CategoriaModel>>() ?? Array.Empty<CategoriaModel>()).ToList();
    }

    public async Task AgregarAsync(CategoriaModel producto)
    {
        var response = await this._httpClient.PostAsJsonAsync("categoria", producto);
    }
}