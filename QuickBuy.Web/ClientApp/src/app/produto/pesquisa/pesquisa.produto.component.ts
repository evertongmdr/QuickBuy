import { Component, OnInit } from '@angular/core';
import { ProdutoServico } from '../../servicos/produto/produto.servico';
import { Produto } from '../../modelo/produto';
import { Router } from '@angular/router';

@Component({

  selector: 'pesquisa-produto',
  templateUrl: './pesquisa.produto.component.html',
  styleUrls: ['./pesquisa.produto.component.css']

})

export class PesquisaProdutoComponent implements OnInit{

  public produtos: Produto[];

    ngOnInit(): void {
       
    }


  constructor(private router: Router, private produtoServico: ProdutoServico) {
    this.produtoServico.obterTodosProdutos()
      .subscribe(
        produtos => {
          this.produtos = produtos;
        },
        e => {
          console.log(e.error);
        }
      );
  }

  public adicionarProduto() {
    sessionStorage.setItem('produtoSession', '');
    this.router.navigate(['/produto']);
  }

  public deletarProduto(produto: Produto) {
    var retorno = confirm("Deseja realmente deletar o produto selecionado ?");

    if (retorno == true) {
      this.produtoServico.deletar(produto)
        .subscribe(
          produtos => {
            this.produtos = produtos;
          },
          e => {
            console.log(e.erros);
          }
        );
    }
  }

  public editarProduto(produto: Produto) {

    console.log('salve salve');
    sessionStorage.setItem('produtoSession', JSON.stringify(produto));
    this.router.navigate(['/produto']);
  }
}
