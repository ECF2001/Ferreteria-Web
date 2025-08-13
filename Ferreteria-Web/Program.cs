using Ferreteria_Web.Components;
using Ferreteria_Web.Services;
using MudBlazor.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
builder.Services.AddMudServices();
builder.Services.AddHttpClient("api", http =>
{
    http.BaseAddress = new Uri("https://localhost:44392/api/");
});
builder.Services.AddSingleton<ProductoService>();
builder.Services.AddSingleton<CategoriaService>();
builder.Services.AddSingleton<ProveedorService>();
builder.Services.AddSingleton<VentaService>();

builder.Services.AddScoped<InventarioService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();


app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();