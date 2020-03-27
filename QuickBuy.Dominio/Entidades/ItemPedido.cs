using System;
using System.Collections.Generic;
using System.Text;

namespace QuickBuy.Dominio.Entidades
{
    public class ItemPedido : Entidade
    {
        public int id { get; set; }

        public int produtoId { get; set; }

        public int quantidade { get; set; }

        public override void Validate()
        {
            if (produtoId == 0)
                AdicionarCritica("Não foi identificado qual a referência do produto");

            if (quantidade == 0)
                AdicionarCritica("Quantidade não foi informada");
        }
    }
}
