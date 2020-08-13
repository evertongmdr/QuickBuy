﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using QuickBuy.Repositorio.Contexto;

namespace QuickBuy.Repositorio.Migrations
{
    [DbContext(typeof(QuickBuyContexto))]
    partial class QuickBuyContextoModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("QuickBuy.Dominio.Entidades.ItemPedido", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("Pedidoid");

                    b.Property<int>("produtoId");

                    b.Property<int>("quantidade");

                    b.HasKey("id");

                    b.HasIndex("Pedidoid");

                    b.ToTable("ItensPedidos");
                });

            modelBuilder.Entity("QuickBuy.Dominio.Entidades.Pedido", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("FormaPagamentoId");

                    b.Property<string>("cep")
                        .IsRequired()
                        .HasMaxLength(10);

                    b.Property<string>("cidade")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<DateTime>("dataPedido");

                    b.Property<DateTime>("dataPrevisaoEntrega");

                    b.Property<string>("enderecoCompleto")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("estado")
                        .IsRequired()
                        .HasMaxLength(5);

                    b.Property<int>("numeroEndereco");

                    b.Property<int>("usuarioId");

                    b.HasKey("id");

                    b.HasIndex("FormaPagamentoId");

                    b.HasIndex("usuarioId");

                    b.ToTable("Pedidos");
                });

            modelBuilder.Entity("QuickBuy.Dominio.Entidades.Produto", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("descricao")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<string>("nome")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("nomeArquivo");

                    b.Property<decimal>("preco")
                        .HasColumnType("decimal(19,4)");

                    b.HasKey("id");

                    b.ToTable("Produtos");
                });

            modelBuilder.Entity("QuickBuy.Dominio.Entidades.Usuario", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("EhAdministrador");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("nome")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("senha")
                        .IsRequired()
                        .HasMaxLength(400);

                    b.Property<string>("sobreNome")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("id");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("QuickBuy.Dominio.ObjetoDeValor.FormaPagamento", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("descricao")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("nome")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("id");

                    b.ToTable("FormaPagamento");

                    b.HasData(
                        new
                        {
                            id = 1,
                            descricao = "Forma de Pagamento Boleto",
                            nome = "Boleto"
                        },
                        new
                        {
                            id = 2,
                            descricao = "Forma de Pagamento Cartão de Crédito",
                            nome = "Cartão de Crédito"
                        },
                        new
                        {
                            id = 3,
                            descricao = "Forma de Pagamento Depósito",
                            nome = "Depósito"
                        });
                });

            modelBuilder.Entity("QuickBuy.Dominio.Entidades.ItemPedido", b =>
                {
                    b.HasOne("QuickBuy.Dominio.Entidades.Pedido")
                        .WithMany("itensPedido")
                        .HasForeignKey("Pedidoid");
                });

            modelBuilder.Entity("QuickBuy.Dominio.Entidades.Pedido", b =>
                {
                    b.HasOne("QuickBuy.Dominio.ObjetoDeValor.FormaPagamento", "formaPagamento")
                        .WithMany()
                        .HasForeignKey("FormaPagamentoId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("QuickBuy.Dominio.Entidades.Usuario", "usuario")
                        .WithMany("pedidos")
                        .HasForeignKey("usuarioId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
