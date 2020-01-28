import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { MedicalSpecialityModel } from '../components/Models/medicalSpecialityModel';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class MedicalSpecialityService {

  constructor(private http: HttpClient) { }


  getMedicalSpecialities(token: string): Observable<MedicalSpecialityModel[]> {
    const headers = new HttpHeaders().set("Authorization", `Bearer ${token}`);
    return this.http.get<MedicalSpecialityModel[]>("https://localhost:44317/api/MedicalSpeciality", { headers });
  }
}
