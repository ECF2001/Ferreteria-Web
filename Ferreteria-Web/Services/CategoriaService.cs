using Ferreteria_Web.Models;

namespace Ferreteria_Web.Services;

public class CategoriaService(IHttpClientFactory httpClientFactory)
{
    private readonly HttpClient _httpClient = httpClientFactory.CreateClient("api");

    public async Task<List<CategoriaModel>> ObtenerTodosAsync()
    {
        var result = await this._httpClient.GetAsync("categoria/GetAll");
        if (!result.IsSuccessStatusCode)
        {
            return [];
        }
        
        return (await result.Content.ReadFromJsonAsync<IEnumerable<CategoriaModel>>() ?? Array.Empty<CategoriaModel>()).ToList();
    }

    public async Task AgregarAsync(CategoriaModel producto)
    {
        var response = await this._httpClient.PostAsJsonAsync("categoria/create", producto);
    }
    public async Task EliminarAsync(int id)
    {
        var response = await this._httpClient.DeleteAsync($"categoria/Delete/{id}");
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception("Error al eliminar la categoría");
        }
    }
    
    public async Task<CategoriaModel?> ObtenerPorIdAsync(int id)
    {
        var result = await this._httpClient.GetAsync($"categoria/GetById/{id}");
        if (!result.IsSuccessStatusCode)
        {
            return null;
        }
        
        return await result.Content.ReadFromJsonAsync<CategoriaModel>();
    }
    
    public async Task ActualizarAsync(CategoriaModel categoriaModel)
    {
        var response = await this._httpClient.PutAsJsonAsync("categoria/Update", categoriaModel);
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception("Error al actualizar la categoría");
        }
    }
}