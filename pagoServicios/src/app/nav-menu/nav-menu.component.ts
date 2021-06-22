import { Component, OnInit } from '@angular/core';
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

  constructor(public authService: LoginService) { 
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
  }

  desloguear(): void {
    this.authService.logoutUser();
  }

}
