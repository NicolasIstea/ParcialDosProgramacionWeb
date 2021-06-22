import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { MetodoDePago } from '../modelos/metodo-de-pago';

@Injectable({
  providedIn: 'root'
})
export class MetodoDePagoService {

  private apiUrl:string = "https://localhost:44329" + "/api/MetodoDePago";

  traerMetodoDePago(metodoDePagoId: number): Observable<MetodoDePago> {
    return this.http.get<MetodoDePago>(this.apiUrl + "/" + metodoDePagoId);
  }

  constructor(private http: HttpClient) { }

  traerMetodosDePago():Observable<MetodoDePago[]>{   
    return this.http.get<MetodoDePago[]>(this.apiUrl);
  }
}
