using Microsoft.EntityFrameworkCore;
using WebApi_LojaOnline.Data;
using Microsoft.EntityFrameworkCore;
using WebApi_LojaOnline.Data;
using WebApi_LojaOnline.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ApiDbContext>(
        option => option.UseSqlServer(
           builder.Configuration.GetConnectionString("DBProductsConnection")));

// "ApiDbContext" - classe de defini��o da(s) tabelas
// NomeDoProjeto.Model.ApiDbContext
// "DBBooksConnection" - String de liga��o definida no ficheiro "appsettings.json".
builder.Services.AddControllers();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
