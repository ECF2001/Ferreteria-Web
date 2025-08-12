
using Ferreteria_Web.Models;

public class ProductoService(IHttpClientFactory httpClientFactory)
{
    private readonly HttpClient _httpClient = httpClientFactory.CreateClient("api");

    public async Task<List<ProductoModel>> ObtenerTodosAsync()
    {
        var result = await this._httpClient.GetAsync("producto/GetAll");
        if (!result.IsSuccessStatusCode)
        {
            return [];
        }
        
        return (await result.Content.ReadFromJsonAsync<IEnumerable<ProductoModel>>() ?? Array.Empty<ProductoModel>()).ToList();
    }

    public async Task AgregarAsync(ProductoModel producto)
    {
        var response = await this._httpClient.PostAsJsonAsync("producto/create", producto);
    }
    
    public async Task EliminarAsync(int id)
    {
        var response = await this._httpClient.DeleteAsync($"producto/Delete/{id}");
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception("Error al eliminar el producto");
        }
    }
    
    public async Task<ProductoModel?> ObtenerPorIdAsync(int id)
    {
        var result = await this._httpClient.GetAsync($"producto/GetById/{id}");
        if (!result.IsSuccessStatusCode)
        {
            return null;
        }
        
        return await result.Content.ReadFromJsonAsync<ProductoModel>();
    }
    public async Task ActualizarAsync(ProductoModel productoModel)
    {
        var response = await this._httpClient.PutAsJsonAsync("producto/Update", productoModel);
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception("Error al actualizar el producto");
        }
    }
}