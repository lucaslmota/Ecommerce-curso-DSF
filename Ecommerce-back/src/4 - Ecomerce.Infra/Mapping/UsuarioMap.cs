using Ecomerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ecomerce.Infra.Mapping
{
    public class UsuarioMap : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("Usuarios");
            
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).UseIdentityColumn();

            builder.Property(x => x.Nome).HasColumnName("usuario").HasMaxLength(80).IsRequired();

            builder.Property(x => x.Email).HasColumnName("email").HasMaxLength(180).IsRequired();

            builder.Property(x => x.Senha).HasColumnName("senha").HasMaxLength(30).IsRequired();

            builder.Property(x => x.Cpf).HasColumnName("cpf").HasMaxLength(11).IsRequired();

        }
    }
}