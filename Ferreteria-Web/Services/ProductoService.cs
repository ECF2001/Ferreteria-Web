using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ferreteria_Web.Components.Pages;
using Ferreteria_Web.Models;

public class ProductoService(IHttpClientFactory httpClientFactory)
{
    private readonly HttpClient _httpClient = httpClientFactory.CreateClient("api");
    private List<ProductoModel> productos = new();

    public async Task<List<ProductoModel>> ObtenerTodosAsync()
    {
        var result = await this._httpClient.GetAsync("producto");
        if (!result.IsSuccessStatusCode)
        {
            return [];
        }
        
        return (await result.Content.ReadFromJsonAsync<IEnumerable<ProductoModel>>() ?? Array.Empty<ProductoModel>()).ToList();
    }

    public async Task AgregarAsync(ProductoModel producto)
    {
        var response = await this._httpClient.PostAsJsonAsync("producto", producto);
    }
}