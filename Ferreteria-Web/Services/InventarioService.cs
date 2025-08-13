using Ferreteria_Web.Models;

namespace Ferreteria_Web.Services;

public class InventarioService(IHttpClientFactory httpClientFactory)
{
    private readonly HttpClient _http = httpClientFactory.CreateClient("api");
    // Base address ya está en Program.cs: https://localhost:44392/api/

    public async Task<List<ProductoModel>> GetProductosAsync()
    {
        var res = await _http.GetAsync("Inventario/Productos");
        if (!res.IsSuccessStatusCode) return [];
        return await res.Content.ReadFromJsonAsync<List<ProductoModel>>() ?? [];
    }

    public async Task<List<ProductoModel>> GetStockBajoMinimoAsync()
    {
        var res = await _http.GetAsync("Inventario/StockBajoMinimo");
        if (!res.IsSuccessStatusCode) return [];
        return await res.Content.ReadFromJsonAsync<List<ProductoModel>>() ?? [];
    }
}