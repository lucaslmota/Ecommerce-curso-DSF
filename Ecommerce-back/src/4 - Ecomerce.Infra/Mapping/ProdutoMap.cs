using Ecomerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ecomerce.Infra.Mapping
{
    public class ProdutoMap : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.ToTable("Produto");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).UseSerialColumn();
            builder.Property(x => x.Nome).HasColumnName("nome_produto").HasMaxLength(180).IsRequired();
            builder.Property(x => x.Descricao).HasColumnName("descricao").HasMaxLength(255).IsRequired();
            builder.Property(x => x.Valor).HasColumnName("valor").IsRequired();
            builder.Property(x => x.Observacao).HasColumnName("observacao").HasMaxLength(255).IsRequired();

            builder.Property(x => x.IdCompanhia).HasColumnName("id_companhia").IsRequired();
            builder.HasOne(x => x.Companhia).WithMany(x => x.Produtos).HasForeignKey(x => x.IdCompanhia);
        }
    }
}