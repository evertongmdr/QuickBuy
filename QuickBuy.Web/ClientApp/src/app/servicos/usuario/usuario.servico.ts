import {Injectable, Inject} from '@angular/core'

import { HttpClient, HttpHeaders } from '@angular/common/http';

import { Observable } from 'rxjs'; // programação reativa.
import { Usuario } from '../../modelo/usuario';


@Injectable({
  providedIn: "root" //publicando essa classe de injeção de depedencia na raiz da aplicação
})

export class UsuarioServico {

  private baseUrl: string;
  private _usuario: Usuario;

  constructor(private http: HttpClient, @Inject('BASE_URL') baseURL: string) {
    this.baseUrl = baseURL;
  }

  get usuario(): Usuario {
    let usuario_json = sessionStorage.getItem("usuario-autenticado");
    this._usuario = JSON.parse(usuario_json);

    return this._usuario;
  }


  set usuario(usuario: Usuario) {
    sessionStorage.setItem("usuario-autenticado", JSON.stringify(usuario));
    this._usuario = usuario;

  }

  public usuario_autenticado(): boolean {

    return this._usuario != null && this._usuario.email != "" && this._usuario.senha != "";
  }

  public limpar_sessao() {
    sessionStorage.setItem("usuario-autenticado", "");
    this._usuario = null;
  }
  
  public verificarUsuario(usuario: Usuario): Observable<Usuario> {

    /* Informando o cabeçario qual é o tipo de dados que vai trafegar nesta requisição
       e no caso é json */
    const headers = new HttpHeaders().set('content-type', 'application/json');

    var body = {
      email: usuario.email,
      senha: usuario.senha
    };

    //this.baseUrl = raiz do site qeu pode ser exemplo.: www.quickbuy.com

    return this.http.post<Usuario>(this.baseUrl + "api/usuario/VerificarUsuario", body, {});

  }
}









