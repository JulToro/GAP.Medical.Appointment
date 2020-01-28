import { Injectable } from '@angular/core';
import { HttpHeaders, HttpClient } from '@angular/common/http';
import { environment } from '../../environments/environment';
import { Observable } from "rxjs";
import { MedicalSpecialtyModel } from '../components/Models/medicalSpecialtyModel';


@Injectable({
  providedIn: 'root'
})
export class AppointmentService {

  constructor(private http: HttpClient) { }

  getAppointments(idUser){
    const headers = new HttpHeaders().set("X-CustomHeader", "custom header value")
                                      .set("X-CustomHeader", "custom header value");;

    
     return this.http.get<any>(environment.urlAppointment + idUser, {headers})
                   .subscribe((result:any)=>{

                   });
  }

}
