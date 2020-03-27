using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuickBuy.Dominio.Entidades;
using System;

namespace QuickBuy.Repositorio.Config
{
    public class PedidoConfiguration : IEntityTypeConfiguration<Pedido>
    {
        public void Configure(EntityTypeBuilder<Pedido> builder)
        {
            builder.HasKey(u => u.id);

            builder.Property(u => u.dataPedido).IsRequired();

            builder.Property(u => u.usuarioId).IsRequired();

            builder.Property(u => u.dataPrevisaoEntrega).IsRequired();

            builder.Property(u => u.cep).IsRequired().HasMaxLength(10);

            builder.Property(u => u.estado).IsRequired().HasMaxLength(5);

            builder.Property(u => u.cidade).IsRequired().HasMaxLength(50);

            builder.Property(u => u.enderecoCompleto).IsRequired().HasMaxLength(50);

            builder.Property(u => u.numeroEndereco).IsRequired();



            //builder.HasOne(p => p.Usuario); outra forma de fazer  1 para muitos 

        }
    }
}
