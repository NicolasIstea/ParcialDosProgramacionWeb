import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { first } from 'rxjs/operators';
import { Usuario } from '../modelos/usuario';
import { LoginService } from '../servicios/login-service.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  loginForm: FormGroup;
  loading = false;
  submitted = false;
  error = '';

  constructor(private _loginService:LoginService,
              private _router: Router,
              private _formBuilder: FormBuilder,
              private _route: ActivatedRoute) { 

  }

  ngOnInit(): void {
    if(this._loginService.isUserLoggedIn()){
      this._loginService.logoutUser();
  }
  this.loginForm = this._formBuilder.group({
      userName: ['', Validators.required],
      password: ['', Validators.required]
  });
  }

  get f() { return this.loginForm.controls; }

  login() {
    this.submitted = true;

    // stop here if form is invalid
    if (this.loginForm.invalid) {
        return;
    }

    this.loading = true;

    let usuario: Usuario = { nombre: '', apellido: '', contraseña: '', usuarioNombre: '', dni: 0 };
    usuario.usuarioNombre = this.f.userName.value;
    usuario.contraseña = btoa(this.f.password.value);

    this._loginService.login(usuario)
        .pipe(first())
        .subscribe(
            data => {
                this._router.navigate(['/inicio']);
            },
            error => {
                if(error.status == 401) {
                  this.error = "Usuario no autorizado o username/contraseña incorrecta";
                  this.loading = false;
                }

                if(error.status == 500) {
                  this.error = "Por favor, intentelo nuevamente o contacte con el administrador del sistema";
                  this.loading = false;
                }
            });
  }

  registrarse() {
    this._router.navigate(['registracion']);
  }

}
