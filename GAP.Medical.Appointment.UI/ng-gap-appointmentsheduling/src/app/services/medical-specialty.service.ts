import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { MedicalSpecialtyModel } from '../components/Models/medicalSpecialtyModel';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class MedicalSpecialtyService {

  constructor(private http: HttpClient) { }


  getMedicalSpecialities(token: string): Observable<MedicalSpecialtyModel[]> {
    const headers = new HttpHeaders().set("Authorization", `Bearer ${token}`);
    return this.http.get<MedicalSpecialtyModel[]>("https://localhost:44317/api/MedicalSpecialty", { headers });
  }
}
