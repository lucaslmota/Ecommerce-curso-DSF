using Ecomerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ecomerce.Infra.Mapping
{
    public class CompanhiaMap : IEntityTypeConfiguration<Companhia>
    {
        public void Configure(EntityTypeBuilder<Companhia> builder)
        {
            builder.ToTable("Companhia");
            
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).UseSerialColumn();
            builder.Property(x => x.NomeFantasia).HasColumnName("nome_fantasia").HasMaxLength(255).IsRequired();
            builder.Property(x => x.RazaoSocial).HasColumnName("razao_social").HasMaxLength(255).IsRequired();
            builder.Property(x => x.CNPJ).HasColumnName("cnpj").HasMaxLength(14).IsRequired();

            builder.HasMany(x => x.Produtos).WithOne(x => x.Companhia).HasForeignKey(x => x.IdCompanhia);
        }
    }
}