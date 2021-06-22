import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { LoginService } from '../servicios/login-service.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  public userName: string = '';
  public password: string = '';

  constructor(private _loginService:LoginService,
              private _router: Router) { 

  }

  ngOnInit(): void {
  }

  logIn(){
    this._loginService.login(this.userName, this.password);

    if(this._loginService.isUserLoggedIn()){
      this._router.navigate(['login']);
    }
  }

}
