import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Usuario } from '../modelos/usuario';

@Injectable({
  providedIn: 'root'
})
export class UsuarioService {
  

  private apiUrl:string = "https://localhost:44329" + "/api/Usuario";

  constructor(private http: HttpClient) {}

  crearUsuario(usuario: Usuario): Observable<Usuario> {

    return this.http.post<Usuario>(this.apiUrl, usuario, {
      headers: new HttpHeaders({
        'Content-Type': 'application/json'
      })
    });
  }

}
