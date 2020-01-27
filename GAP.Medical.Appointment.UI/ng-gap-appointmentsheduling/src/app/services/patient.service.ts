import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { PatientModel } from '../components/Models/patientModel';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class PatientService {

  constructor(private http: HttpClient) { }

  getInfoPatient()
  {
    
  }

  registerPatient(patient: PatientModel): Observable<PatientModel>
  {
    const body = patient;

    const headers = new HttpHeaders().set("Access-Control-Allow-Headers", "*")
                                    .set("Content-Type", "application/json");

    return this.http.post<PatientModel>("https://localhost:44317/api/Patient", body, {headers});
  }

}
