using System.Collections.Generic;

namespace QuickBuy.Dominio.Entidades
{
    public class Usuario: Entidade
    {
        public int id { get; set; }
        public string email { get; set; }
        public string senha { get; set; }
        public string nome { get; set; }
        public string sobreNome { get; set;}


        /* o motivo de colocar virtual na frente de ICollection  é que
         * Permite que o EF core faça a sobreposição  da ICollection para alimenta-lo em tempo de execução,
           para determinado pedios salvo na base*/
        public  virtual ICollection<Pedido> pedidos { get; set; }

        public override void Validate()
        {
            if (string.IsNullOrEmpty(email))
                AdicionarCritica("Email não foi informado");

            if (string.IsNullOrEmpty(senha))
                AdicionarCritica("Senha não foi informado");
        }
    }
}
