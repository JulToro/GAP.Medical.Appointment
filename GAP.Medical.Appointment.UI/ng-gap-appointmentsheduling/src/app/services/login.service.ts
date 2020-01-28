import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { LoginModel } from '../components/Models/LoginModel';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment';
@Injectable({
  providedIn: 'root'
})
export class LoginService {

  constructor(private http: HttpClient) { }

  login(patient: LoginModel): Observable<any> {
    const headers = new HttpHeaders()
      .set("Access-Control-Allow-Headers", "*")
      .set("Content-Type", "application/json");

    return this.http.get<any>(`${environment.urlLogin}?user=${patient.userName}&password=${patient.password}`, { headers });
  }
}
