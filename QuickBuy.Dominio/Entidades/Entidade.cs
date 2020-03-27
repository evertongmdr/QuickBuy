using System.Collections.Generic;
using System.Linq;

namespace QuickBuy.Dominio.Entidades
{
    public abstract class Entidade
    {
        private List<string> _mensagensValidacao { get; set; }

        private List<string> mensagemValidacao
        {
            // se mensagem for vazia retorna um uuma lista instânciada.
            get { return _mensagensValidacao ?? (_mensagensValidacao = new List<string>());}
        }

        protected void AdicionarCritica(string mensagem)
        {
            mensagemValidacao.Add(mensagem);
        }

        public abstract void Validate();

        protected bool EhValidado
        {
            get { return !mensagemValidacao.Any(); }
        }

        protected void LimparMensagensValidacao()
        {
            mensagemValidacao.Clear();
        }

       
    }
}
