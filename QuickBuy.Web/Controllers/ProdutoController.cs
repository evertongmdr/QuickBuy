using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuickBuy.Dominio.Contratos;
using QuickBuy.Dominio.Entidades;
using System;
using System.IO;
using System.Linq;

namespace QuickBuy.Web.Controllers
{
    [Route("api/[controller]")]
    public class ProdutoController: Controller
    {
        private readonly IProdutoRepositorio _produtoRepositorio;
        private IHttpContextAccessor _httpContextAccessor;

        /* A gente precisa do  IHostringEnvirment para saber onde o site está
         sendo executado ou seja informações sobre a pata raiz do projeto, isso porque
         precisamos desta informação(caminho) para colocar o arquivo que vai ser enviado
         pelo usuário*/
        private IHostingEnvironment _hostingEnvironment;

        public ProdutoController(
            IProdutoRepositorio produtoRepositorio,
            IHttpContextAccessor httpContextAccessor,
            IHostingEnvironment hostingEnvironment
            )
        {
            _produtoRepositorio = produtoRepositorio;
            _httpContextAccessor = httpContextAccessor;
            _hostingEnvironment = hostingEnvironment;

        }

        [HttpGet] // atributo
        public IActionResult Get()
        {
            try
            {
                return Json(_produtoRepositorio.ObterTodos());

            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
                
            }
        }

        [HttpPost]

        /*[FromBody]-> transforma objeto JSON enviado pela requisão em um objeto produto,
         com isso não precisa fazer o mapeamento manualmente.*/
        public IActionResult Post([FromBody] Produto produto)
        {
            try
            {

                produto.Validate();

                if(!produto.EhValidado)
                {
                    return BadRequest(produto.obterMensagemValidacao());
                }

                // se o produto já existir, ele vai atualizar
                if(produto.id > 0)
                {
                    _produtoRepositorio.Atualizar(produto);
                }
                else
                {
                _produtoRepositorio.Adicionar(produto);

                }

                return Created("api/produto", produto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
               
            }
          
        }

        [HttpPost("Deletar")]
        public IActionResult Deletar([FromBody] Produto produto)
        {
            try
            {
                // produto recebido do FromBody, deve ter a propridade id > 0
                _produtoRepositorio.Remover(produto);

                return Json(_produtoRepositorio.ObterTodos());
            }catch(Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
      

        [HttpPost("EnviarArquivo")]
        public IActionResult EnviarArquivo()
        {
            try
            {
                var formFile = _httpContextAccessor.HttpContext.Request.Form.Files["arquivoEnviado"];

                var nomeArquivo = formFile.FileName;

                var extensao = nomeArquivo.Split(".").Last();

                var arrayNomeCompacto = Path.GetFileNameWithoutExtension(nomeArquivo).Take(10).ToArray();
                var novoNomeArquivo = new string(arrayNomeCompacto).Replace(" ", "-"); 
                
                novoNomeArquivo = $"{nomeArquivo}_{DateTime.Now.Year}{DateTime.Now.Month}{DateTime.Now.Day}{DateTime.Now.Hour}{DateTime.Now.Minute}{DateTime.Now.Second}." + extensao;
                var pastaArquivos =_hostingEnvironment.WebRootPath + "\\arquivos\\";

               var nomeCompleto = pastaArquivos + novoNomeArquivo;

                //
                using (var streamArquivo = new FileStream(nomeCompleto, FileMode.Create))
                {
                    /* o formFile está pegando o arquivo que estra dentro dele
                     * e copiando apra o stremArquivo*/
                    formFile.CopyTo(streamArquivo);
                }

                return Json(novoNomeArquivo);
 
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
               
            }
        }
    }
}
