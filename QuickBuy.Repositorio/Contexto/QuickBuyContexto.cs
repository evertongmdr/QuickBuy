using Microsoft.EntityFrameworkCore;
using QuickBuy.Dominio.Entidades;
using QuickBuy.Dominio.ObjetoDeValor;
using QuickBuy.Repositorio.Config;

namespace QuickBuy.Repositorio.Contexto
{
    public class QuickBuyContexto: DbContext
    {
        

        // faz o mapeamento e a transformação das propridades e tabela no banco de dados.
        public DbSet<Usuario> Usuarios { get; set; }

        public DbSet<Produto> Produtos { get; set; }

        public DbSet<Pedido> Pedidos { get; set; }

        public DbSet<ItemPedido> ItensPedidos { get; set; }

        public DbSet<FormaPagamento> FormaPagamento { get; set; }

        public QuickBuyContexto(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Classes de mapeamento aqui...

            modelBuilder.ApplyConfiguration(new UsuarioConfiguration());
            modelBuilder.ApplyConfiguration(new ProdutoConfiguration());
            modelBuilder.ApplyConfiguration(new PedidoConfiguration());
            modelBuilder.ApplyConfiguration(new ItemPedidoConfiguration());
            modelBuilder.ApplyConfiguration(new FormaPagamentoConfiguration());

            modelBuilder.Entity<FormaPagamento>().HasData(
                new FormaPagamento() {
                id = 1, nome = "Boleto",
                descricao = "Forma de Pagamento Boleto"
                },
                new FormaPagamento()
                {
                    id = 2,
                    nome = "Cartão de Crédito",
                    descricao = "Forma de Pagamento Cartão de Crédito"
                },
                new FormaPagamento()
                {
                    id = 3,
                    nome = "Depósito",
                    descricao = "Forma de Pagamento Depósito"
                }
              );

            base.OnModelCreating(modelBuilder);
        }



    }
}
