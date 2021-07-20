import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { LoginService } from '../servicios/login-service.service';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent implements OnInit {

  titulo:string="Bienvenido a Cargue su Pago";
  inicio:string="Inicio";
  desloguearse:string="Desloguearse";
  logueado:Boolean;

  constructor(public authService: LoginService, public router: Router) { 
    this.logueado = authService.isUserLoggedIn();
  }

  isExpanded = false;

  collapse() {
    this.isExpanded = false;
  }

  toggle() {
    this.isExpanded = !this.isExpanded;
  }
  
  ngOnInit(): void {
    this.logueado = this.authService.isUserLoggedIn();
  }

  desloguear(): void {
    this.authService.logoutUser();
    this.logueado = false;
    this.router.navigate(['login']);
  }

}
