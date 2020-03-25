using System;
using System.Collections.Generic;
using System.Text;

namespace QuickBuy.Dominio.Entidades
{
    public class ItemPedido
    {
        public int id { get; set; }

        public int produtoId { get; set; }

        public int quantidade { get; set; }
    }
}
