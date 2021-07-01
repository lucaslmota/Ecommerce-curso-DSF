using Ecomerce.Domain.Entities;
using Ecomerce.Infra.Mapping;
using Microsoft.EntityFrameworkCore;

namespace Ecomerce.Infra.Context
{
    public class EcomerceContext : DbContext
    {
        public EcomerceContext(){ }

        public EcomerceContext(DbContextOptions<EcomerceContext> options) : base(options){ }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Server=127.0.0.1; Port=5432; Database=ECOMERCE; User Id=postgres; Password=042393ll;");
        }
        
        public virtual DbSet<Usuario> Usuarios {get; set;}
        public virtual DbSet<Compra> Compras {get;set;}
        public virtual DbSet<Produto> Produtos {get;set;}
        public virtual DbSet<Companhia> Companhias{get;set;}

        protected override void OnModelCreating(ModelBuilder builder){
            builder.ApplyConfiguration(new UsuarioMap());
            builder.ApplyConfiguration(new CompraMap());
            builder.ApplyConfiguration(new ProdutoMap());
            builder.ApplyConfiguration(new CompanhiaMap());
        }
        
    }
}