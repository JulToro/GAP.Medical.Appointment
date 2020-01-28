import { Injectable } from '@angular/core';
import { HttpHeaders, HttpClient } from '@angular/common/http';
import { environment } from '../../environments/environment';
import { Observable } from "rxjs";
import { AppointmentModel } from '../components/Models/appointmentModel';
import { UUID } from 'angular2-uuid';


@Injectable({
  providedIn: 'root'
})
export class AppointmentService {

  constructor(private http: HttpClient) { }

  getAppointments(token: string, patientId: UUID): Observable<any>{
    const headers = new HttpHeaders().set("Content-Type", "application/json")
      .set("Authorization", `Bearer ${token}`);

    return this.http.get<any>(environment.urlAppointment +'/'+ patientId, { headers });
  }

  registerAppointment(token: string, schedule: AppointmentModel): Observable<any> {
    const body = schedule;
    const headers = new HttpHeaders().set("Content-Type", "application/json")
      .set("Authorization", `Bearer ${token}`);;

    return this.http.post<any>(environment.urlAppointment, body, { headers });
  }

  deleteAppointment(token: string, idAppointment: string): Observable<any> {
    const body = idAppointment;
    const headers = new HttpHeaders().set("Content-Type", "application/json")
      .set("Authorization", `Bearer ${token}`);;

    return this.http.delete<any>(environment.urlAppointment + '?idAppointment=' + idAppointment, { headers });
  }

}
