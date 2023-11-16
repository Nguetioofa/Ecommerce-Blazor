using Ecommerce.Repositorie.DBContext;
using Microsoft.EntityFrameworkCore;

using Ecommerce.Repositorie.Contrat;
using Ecommerce.Repositorie.Implementation;

using Ecommerce.Utilitaires;

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
