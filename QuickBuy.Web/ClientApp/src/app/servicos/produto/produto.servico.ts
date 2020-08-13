import{ Injectable, Inject, OnInit } from '@angular/core'

import { HttpClient, HttpHeaders } from '@angular/common/http';

import { Observable } from 'rxjs'; // programação reativa.
import { Produto } from '../../modelo/produto';



@Injectable({
  providedIn: "root" // ela sera publicada na raiz de injeção de dependencia do angular.
})


export class ProdutoServico implements OnInit{
  private _baseUrl: string;
  public produtos: Produto[];

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl :string) {

  this._baseUrl = baseUrl;

  }
    ngOnInit(): void {
      this.produtos = [];
    }

  get headers(): HttpHeaders {

    return new HttpHeaders().set('content-type', 'application/json');
  }

  public cadastar(produto: Produto): Observable<Produto> {

    /*
     Antes da fatoração era assim

    const headers = new HttpHeaders().set('content-type', 'application/json');

    var body = {
      nome: produto.nome,
      descricao: produto.descricao,
      preco: produto.preco
    };

  //  return this.http.post<Produto>(this._baseUrl + "api/produto/cadastrar", body, //não precisa fazer o mapeamento{ headers });

*/

    // Não precisa mapear as chaves dos objetos JSON quando a variavel  que contem a informação tem o mesmo nome da chave. 
    return this.http.post<Produto>(this._baseUrl + "api/produto", JSON.stringify(produto), /* mapeamento */{headers: this.headers });

  }


  public salvar(produto: Produto): Observable<Produto> {

   
    return this.http.post<Produto>(this._baseUrl + "api/produto/salvar", JSON.stringify(produto), { headers: this.headers });

  }

  public deletar(produto: Produto): Observable<Produto[]> {
    
    return this.http.post<Produto[]>(this._baseUrl + "api/produto/deletar", JSON.stringify(produto), { headers: this.headers });
  }

  public obterTodosProdutos(): Observable<Produto[]> {
    return this.http.get<Produto[]>(this._baseUrl + "api/produto",);
  }

  public obterProduto(produtoId: number): Observable<Produto> {
    return this.http.get<Produto>(this._baseUrl + "api/produto/obter");
  }

  public enviarArquivo(arquivoSelecionado: File):Observable<string> {

    const formData: FormData = new FormData();
    formData.append("arquivoEnviado", arquivoSelecionado, arquivoSelecionado.name);

    return this.http.post<string>(this._baseUrl + "api/produto/enviarArquivo", formData);
  }

}
