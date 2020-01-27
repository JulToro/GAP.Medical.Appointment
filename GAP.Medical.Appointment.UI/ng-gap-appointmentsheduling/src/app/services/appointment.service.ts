import { Injectable } from '@angular/core';
import { HttpHeaders, HttpClient } from '@angular/common/http';
import { Observable } from "rxjs";
import { MedicalSpecialityModel } from '../components/Models/medicalSpecialityModel';


@Injectable({
  providedIn: 'root'
})
export class AppointmentService {

  constructor(private http: HttpClient) { }

  getAppointments(idUser){
    const headers = new HttpHeaders().set("X-CustomHeader", "custom header value")
                                      .set("X-CustomHeader", "custom header value");;

    
     return this.http.get<any>("https://localhost:44317/api/Appointment" + idUser, {headers})
                   .subscribe((result:any)=>{


                   });
  }

}
