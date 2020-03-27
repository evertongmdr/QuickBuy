import { Component } from '@angular/core';

@Component({
  selector: 'produto',
  template: '<html><body>{{obterNome()}}</body></html>'
})

export class ProdutoComponent {
  public nome: number;
  public liberadoParaVenda: boolean;

  public obterNome(): string {
    return "Samsung";
  }
}

