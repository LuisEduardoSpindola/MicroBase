using Application.Controllers;
using Application.Interfaces;
using Infraestructure.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Presentation.Areas.Identity.Data;
var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("MicroContextConnection") ?? throw new InvalidOperationException("Connection string 'MicroContextConnection' not found.");

builder.Services.AddDbContext<MicroContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<MicroUser>(options => options.SignIn.RequireConfirmedAccount = false).AddEntityFrameworkStores<MicroContext>();

builder.Services.AddScoped<IProduto, ProdutoRespositories>();
builder.Services.AddScoped<IFornecedor, FornecedorRespositories>();
builder.Services.AddScoped<IServico, ServicoRepositories>();
builder.Services.AddScoped<IEntradaEstoque, EntradaEstoqueRepositories>();
builder.Services.AddScoped<ISaidaEstoque, SaidaRepositories>();
builder.Services.AddScoped<IPedidoInterno, PedidoInternoRepositories>();
builder.Services.AddScoped<IOrdemCompra, OrdemCompraRepositores>();

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.MapRazorPages();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
