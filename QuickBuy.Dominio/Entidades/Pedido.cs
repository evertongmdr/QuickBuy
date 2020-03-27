using QuickBuy.Dominio.ObjetoDeValor;
using System;
using System.Collections.Generic;
using System.Linq;

namespace QuickBuy.Dominio.Entidades
{
   public class Pedido : Entidade
    {
        public int id { get; set; }

        public DateTime dataPedido { get; set; }

        public int usuarioId { get; set; }

        public virtual Usuario usuario { get; set; }

        public DateTime dataPrevisaoEntrega { get; set; }

        public string cep { get; set; }

        public string estado { get; set; }

        public string cidade { get; set; }
        public string enderecoCompleto { get; set; }

        public int numeroEndereco { get; set; }

        public int FormaPagamentoId { get; set; }
        public  virtual FormaPagamento formaPagamento { get; set; }

        public virtual ICollection<ItemPedido> itensPedido { get; set; }

        public override void Validate()
        {
            LimparMensagensValidacao();
            if (!itensPedido.Any())
            {
                AdicionarCritica("Crítica - Pedido não pode ficar sem item de pedido");
               
            }

            if (string.IsNullOrEmpty(cep)) {
                AdicionarCritica("Crítica - CEP deve estar preenchido");
            }

            if(FormaPagamentoId == 0) {
                AdicionarCritica("Crítica - Não foi informado a forma de pagamento");
            }

        }
    }
}
