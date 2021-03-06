﻿
using QuickBuy.Dominio.Contratos;
using QuickBuy.Dominio.Entidades;
using QuickBuy.Repositorio.Contexto;
using System.Linq;

namespace QuickBuy.Repositorio.Repositorios
{
    public class UsuarioRepositorio : BaseRepositorio<Usuario>, IUsuarioRepositorio
    {
        public UsuarioRepositorio(QuickBuyContexto quickBuyContexto) : base(quickBuyContexto)
        {
        }

        public Usuario Obter(string email, string senha)
        {
            // trnasforma essa função lambda em sql 
            return QuickBuyContexto.Usuarios.FirstOrDefault(u => u.email == email && u.senha == senha);
        }

        public Usuario Obter(string email)
        {
            return QuickBuyContexto.Usuarios.FirstOrDefault(u => u.email == email);
        }
    }
}
