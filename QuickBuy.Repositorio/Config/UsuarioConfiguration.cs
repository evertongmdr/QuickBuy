
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuickBuy.Dominio.Entidades;

namespace QuickBuy.Repositorio.Config
{
    public class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.HasKey(u => u.id);
            // builder utiliza o padrão Fluent. Isso permite fazer o mapeamento das chamada de forma encadiada.
            builder
               .Property(u => u.nome)
               .IsRequired()
               .HasMaxLength(50);

            builder
               .Property(u => u.sobreNome)
               .IsRequired()
               .HasMaxLength(50);
            
            builder
                .Property(u => u.email)
                .IsRequired()
                .HasMaxLength(50);

            builder
              .Property(u => u.senha)
              .IsRequired()
              .HasMaxLength(400);

            builder.HasMany(u => u.pedidos).
                 WithOne(p => p.usuario);

        }
    }
}
