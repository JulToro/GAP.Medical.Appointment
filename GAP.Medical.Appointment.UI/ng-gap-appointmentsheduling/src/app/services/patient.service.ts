import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';


import { PatientModel } from '../components/Models/patientModel';
import { environment } from '../../environments/environment';
import { UUID } from 'angular2-uuid';

@Injectable({
  providedIn: 'root'
})
export class PatientService {

  constructor(private http: HttpClient) { }

  getInfoPatient(patientId: UUID, token: string): Observable<any> {
    const headers = new HttpHeaders()
      .set("Access-Control-Allow-Headers", "*")
      .set("Content-Type", "application/json")
      .set("Authorization", `Bearer ${token}`);

    return this.http.get<any>(`${environment.urlPatient}/${patientId}`, { headers });
  }

  registerPatient(patient: PatientModel): Observable<any> {
    const body = patient;
    const headers = new HttpHeaders().set("Access-Control-Allow-Headers", "*")
      .set("Content-Type", "application/json");

    return this.http.post<any>(environment.urlPatient, body, { headers });
  }

}
