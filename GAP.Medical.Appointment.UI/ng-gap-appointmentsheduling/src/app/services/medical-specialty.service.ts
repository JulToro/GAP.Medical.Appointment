import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';

import { MedicalSpecialtyModel } from '../components/Models/medicalSpecialtyModel';
import { environment } from '../../environments/environment';


@Injectable({
  providedIn: 'root'
})
export class MedicalSpecialtyService {

  constructor(private http: HttpClient) { }


  getMedicalSpecialities(token: string): Observable<MedicalSpecialtyModel[]> {
    const headers = new HttpHeaders().set("Authorization", `Bearer ${token}`);
    return this.http.get<MedicalSpecialtyModel[]>(environment.urlMedicalSpecialty, { headers });
  }
}
