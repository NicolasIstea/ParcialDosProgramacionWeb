import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { Usuario } from '../modelos/usuario';
import { map } from 'rxjs/operators';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class LoginService {

  private apiUrl:string = "https://localhost:44329" + "/api/Login/loginUser"

  constructor(private http: HttpClient) { 
  }

  login(user: Usuario) {

    //TODO: Llamado al servicio de login en el backend
    return this.http.post<any>(this.apiUrl, user)
    .pipe(
      map(respuesta => {
          localStorage.setItem('UsuarioGuardado', JSON.stringify(respuesta));  
          return respuesta;
      })
      
    ); 
  }

  isUserLoggedIn(): boolean {
    let isLoggedIn = localStorage.getItem('UsuarioGuardado');

    if(isLoggedIn !== null) {
      return true;
    }

    return false;
  }

  logoutUser(): void{
    localStorage.removeItem('UsuarioGuardado');
  }
}
