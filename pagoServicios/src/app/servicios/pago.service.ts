import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Pago } from '../modelos/pago';

@Injectable({
  providedIn: 'root'
})
export class PagoService {

  private apiUrl:string = "https://localhost:44329" + "/api/Pago";

  constructor(private http: HttpClient) { }

  editarPago(pago: Pago):Observable<Pago> {
    return this.http.put<Pago>(this.apiUrl, pago, {
      headers: new HttpHeaders({
        'Content-Type': 'application/json'
      })
    });
  }

  borrarPago(id: Number):Observable<void> {
    return this.http.delete<void>(this.apiUrl + "/" +id);
  }

  traerPagos():Observable<Pago[]>{   
    return this.http.get<Pago[]>(this.apiUrl);
  }

  traerPago(id:Number):Observable<Pago> {
    return this.http.get<Pago>(this.apiUrl + "/" +id);
  }

  adicionarPago(pago:Pago):Observable<Pago> {
      return this.http.post<Pago>(this.apiUrl, pago, {
        headers: new HttpHeaders({
          'Content-Type': 'application/json'
        })
      });
  }
}
