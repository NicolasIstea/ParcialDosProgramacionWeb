import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class LoginService {

  private isLoggedIn: boolean;
  private userName: string;

  constructor() { 
    this.isLoggedIn = false;
  }

  login(userName: string, password: string): Observable<boolean>{

    //TODO: Llamado al servicio de login en el backend

    this.isLoggedIn = true;
    this.userName = userName;

    localStorage.setItem('isLoggedIn', this.isLoggedIn.toString());

    return of(this.isLoggedIn);
  }

  isUserLoggedIn(): boolean {
    let isLoggedIn = (/true/i).test(localStorage.getItem('isLoggedIn'));

    return isLoggedIn;
  }

  logoutUser(): void{
    localStorage.setItem('isLoggedIn', 'false');
  }
}
