import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot, UrlTree } from '@angular/router';
import { Observable } from 'rxjs';
import { LoginService } from './servicios/login-service.service';

@Injectable({
  providedIn: 'root'
})
export class AppAuthGuardService implements CanActivate{

  constructor(private _router:Router, private loginService: LoginService) { 

  }

  canActivate(route: ActivatedRouteSnapshot, 
    state: RouterStateSnapshot): boolean | UrlTree | Observable<boolean | UrlTree> | Promise<boolean | UrlTree> {

    if(!this.loginService.isUserLoggedIn()) {
      this._router.navigate(['login'], { queryParams: { retUrl: route.url} });
      return false;
    }

    return true;
  }
}
