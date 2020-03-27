namespace QuickBuy.Dominio.Entidades
{
    public class Produto : Entidade
    {
        public int id { get; set; }

        public string nome { get; set; }

        public string descricao { get; set; }

        public decimal preco { get; set; }

        public override void Validate()
        {
            
        }
    }
}
