import { Injectable, Inject, OnInit } from '@angular/core'

import { HttpClient, HttpHeaders } from '@angular/common/http';

import { Observable } from 'rxjs'; // programação reativa.
import { Pedido } from '../../modelo/pedido';

@Injectable({
  providedIn: "root"
})

export class PedidoServico implements OnInit {

  public _baseUrl: string;

  ngOnInit(): void {
  }

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {

    this._baseUrl = baseUrl;

  }

  get headers(): HttpHeaders {

    return new HttpHeaders().set('content-type', 'application/json');
  }

  public efetivarCompra(pedido: Pedido): Observable<number> {
    return this.http.post<number>(this._baseUrl + "api/pedido", JSON.stringify(pedido), {headers: this.headers});
  }

}
