using QuickBuy.Dominio.Enumerados;

namespace QuickBuy.Dominio.ObjetoDeValor
{
    public class FormaPagamento
    {

        public int id { get; set; }
        public string nome { get; set; }
        public string descricao { get; set; }

        public  bool EhBoleto
        {
            get { return id == (int)TipoFormaPagamentoEnum.Boleto; }
        }

        public bool EhCartaoCredito
        {
            get { return id == (int)TipoFormaPagamentoEnum.CartaoCredito; }
        }

        public bool EhDeposito
        {
            get { return id == (int)TipoFormaPagamentoEnum.Deposito; }
        }

        public bool NaoDefinido
        {
            get { return id == (int)TipoFormaPagamentoEnum.NaoDefinido; }
        }
    }
}

