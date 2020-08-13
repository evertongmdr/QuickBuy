namespace QuickBuy.Dominio.Entidades
{
    public class Produto : Entidade
    {
        public int id { get; set; }

        public string nome { get; set; }

        public string descricao { get; set; }

        public decimal preco { get; set; }

        public string nomeArquivo { get; set;}

        public override void Validate()
        {
            if (string.IsNullOrEmpty(nome))
                AdicionarCritica("Nome do produto não informado");

            if (string.IsNullOrEmpty(descricao))
                AdicionarCritica("Descrição do produto não informado");
        }
    }
}
