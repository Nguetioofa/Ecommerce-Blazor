using Ecommerce.Repositorie.DBContext;
using Microsoft.EntityFrameworkCore;

using Ecommerce.Repositorie.Contrat;
using Ecommerce.Repositorie.Implementation;

using Ecommerce.Utilitaires;

using Ecommerce.Service.Contrats;
using Ecommerce.Service.Implementations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DbecommerceContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("SQLServerConnection"));
});

builder.Services.AddTransient(typeof(IGenericRepositorie<>), typeof(GenericRepositorie<>));
builder.Services.AddScoped<IVenteRepositorie, VenteRepositorie>();

builder.Services.AddAutoMapper(typeof(AutoMapperProfil));

builder.Services.AddScoped<IVenteService, VenteService>();
builder.Services.AddScoped<IUtilisateurService, UtilisateurService>();
builder.Services.AddScoped<IProduitService, ProduitService>();
builder.Services.AddScoped<ICategorieService, CategorieService>();
builder.Services.AddScoped<IDashboardService, DashboardService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
