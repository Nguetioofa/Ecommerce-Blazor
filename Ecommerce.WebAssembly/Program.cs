using Ecommerce.WebAssembly;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

using Blazored.LocalStorage;
using Blazored.Toast;

using Ecommerce.WebAssembly.Services.Contrats;
using Ecommerce.WebAssembly.Services.Implementations;

using Microsoft.AspNetCore.Components.Authorization;
using Ecommerce.WebAssembly.Extensions;

using CurrieTechnologies.Razor.SweetAlert2;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("http://localhost:5030/api/") });

builder.Services.AddBlazoredLocalStorage();
builder.Services.AddBlazoredToast();
builder.Services.AddSweetAlert2();


builder.Services.AddScoped<IUtilisateurService, UtilisateurService>();
builder.Services.AddScoped<ICategorieService, CategorieService>();
builder.Services.AddScoped<IDashboardService,DashboardService>();
builder.Services.AddScoped<IPanierService, PanierService>();
builder.Services.AddScoped<IProduitService, ProduitService>();
builder.Services.AddScoped<IVenteService, VenteService>();

builder.Services.AddAuthorizationCore();
builder.Services.AddScoped<AuthenticationStateProvider, AuthentificationExtension>();

await builder.Build().RunAsync();
