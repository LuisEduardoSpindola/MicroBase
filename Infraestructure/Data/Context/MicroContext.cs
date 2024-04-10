using Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Presentation.Areas.Identity.Data;

public class MicroContext : IdentityDbContext<MicroUser>
{
    public MicroContext(DbContextOptions<MicroContext> options)
        : base(options)
    {
    }

    public DbSet<MicroUser> Users { get; set; }
    public DbSet<Produto> Produtos { get; set; }
    public DbSet<Fornecedores> Fornecedores { get; set; }
    public DbSet<Servicos> Servicos { get; set; }
    public DbSet<PedidoInterno> PedidosInternos { get; set; }
    public DbSet<EntradaEstoque> EntradasEstoque { get; set; }
    public DbSet<SaidaEstoque> SaidasEstoque { get; set; }
    public DbSet<OrdemCompra> OrdensCompra { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
    }
}
