using Ecomerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ecomerce.Infra.Mapping
{
    public class CompraMap : IEntityTypeConfiguration<Compra>
    {
        public void Configure(EntityTypeBuilder<Compra> builder)
        {
            builder.ToTable("Compras");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.Valor).HasColumnName("valor").IsRequired();
            builder.Property(x => x.Data).HasColumnName("data").IsRequired();
            builder.Property(x => x.FormaDePagamento).HasColumnName("forma-de-pagamento").IsRequired();
            builder.Property(x => x.StatusCompra).HasColumnName("status-compra").IsRequired();
            builder.Property(x => x.Observacao).HasColumnName("observacao").HasMaxLength(255);
            builder.Property(x => x.Cep).HasColumnName("cep").HasMaxLength(8).IsRequired();
            builder.Property(x => x.Endereco).HasColumnName("endereco").HasMaxLength(255).IsRequired();

            builder.Property(x => x.IdUsuario).HasColumnName("id_usuario").IsRequired();
            builder.HasOne(x => x.Usuario).WithMany(x => x.Compras).HasForeignKey(x => x.IdUsuario);
        }
    }
}