import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { MedicalSpecialityModel } from '../components/Models/medicalSpecialityModel';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class MedicalSpecialityService {

  constructor(private http: HttpClient) { }


  getMedicalSpecialities(): Observable<MedicalSpecialityModel>
  {
    const headers = new HttpHeaders().set("X-CustomHeader", "custom header value")
                                      .set("X-CustomHeader", "custom header value");;

    
     return this.http.get<any>("https://localhost:44317/api/MedicalSpeciality", {headers});
  }
}
