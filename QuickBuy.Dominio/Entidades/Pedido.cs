using QuickBuy.Dominio.ObjetoDeValor;
using System;
using System.Collections.Generic;

namespace QuickBuy.Dominio.Entidades
{
   public class Pedido
    {
        public int id { get; set; }

        public DateTime DataPedido { get; set; }

        public int usuarioId { get; set; }

        public DateTime dataPrevisaoEntrega { get; set; }

        public string cep { get; set; }

        public string estado { get; set; }

        public string cidade { get; set; }
        public string enderecoCompleto { get; set; }

        public int numeroEndereco { get; set; }

        public int FormaPagamentoId { get; set; }
        public FormaPagamento formaPagamento { get; set; }

        public ICollection<ItemPedido> itensPedido { get; set; }
    }
}
