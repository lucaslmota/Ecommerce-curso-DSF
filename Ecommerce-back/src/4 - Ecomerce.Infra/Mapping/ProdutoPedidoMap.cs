using Ecomerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ecomerce.Infra.Mapping
{
    public class ProdutoPedidoMap : IEntityTypeConfiguration<ProdutoPedido>
    {
        public void Configure(EntityTypeBuilder<ProdutoPedido> builder)
        {
            builder.ToTable("Produtos-Pedidos");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).UseSerialColumn();
            builder.Property(x => x.Quantidade).HasColumnName("quantidade").HasPrecision(2).IsRequired();

            builder.Property(x => x.IdCompra).HasColumnName("id_Compra").IsRequired();
            builder.HasOne(x => x.Compra).WithMany(x => x.ProdutosPedidos).HasForeignKey(x => x.IdCompra);

            builder.Property(x => x.IdProduto).HasColumnName("id_produto").IsRequired();
            builder.HasOne(x => x.Produto).WithMany().HasForeignKey(x => x.IdProduto);
        }
    }
}