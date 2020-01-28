import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { PatientModel } from '../components/Models/patientModel';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class PatientService {

  constructor(private http: HttpClient) { }

  getInfoPatient(patientId:string, token:string): Observable<any>
  {
    const headers = new HttpHeaders()
    .set("Access-Control-Allow-Headers", "*")
    .set("Content-Type", "application/json")
    .set("Authorization",`Bearer ${token}`);

  return this.http.get<any>(`https://localhost:44317/api/Patient/${patientId}`, { headers });  
  }

  registerPatient(patient: PatientModel): Observable<any>
  {
    const body = patient;
    const headers = new HttpHeaders().set("Access-Control-Allow-Headers", "*")
                                    .set("Content-Type", "application/json");

    return this.http.post<any>("https://localhost:44317/api/Patient", body, {headers});
  }

}
