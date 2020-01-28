import { Component, OnInit } from '@angular/core';
import { AppointmentService } from 'src/app/services/appointment.service';
import { UUID } from 'angular2-uuid';
import { PatientApointmentModel } from '../Models/patientApointmentModel';

@Component({
  selector: 'app-appointment',
  templateUrl: './appointment.component.html',
  styleUrls: ['./appointment.component.scss']
})
export class AppointmentComponent implements OnInit {

  appointments : PatientApointmentModel;
  constructor(private appointmentService: AppointmentService) { }

  ngOnInit() {
    /* debugger; */
    let patientId: UUID = sessionStorage.getItem('id');
    let token: string = sessionStorage.getItem('token');

    
    this.appointmentService.getAppointments(token,patientId).subscribe(res=>{
      if(res.value)
        console.log(res.value);
        this.appointments = res.value;
    });

  }

}
