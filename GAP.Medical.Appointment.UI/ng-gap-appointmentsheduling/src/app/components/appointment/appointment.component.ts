import { Component, OnInit } from '@angular/core';
import { AppointmentService } from 'src/app/services/appointment.service';
import { UUID } from 'angular2-uuid';
import { PatientApointmentModel } from '../Models/patientApointmentModel';
import { FormGroup } from '@angular/forms';

@Component({
  selector: 'app-appointment',
  templateUrl: './appointment.component.html',
  styleUrls: ['./appointment.component.scss']
})
export class AppointmentComponent implements OnInit {
  appointmentForm: FormGroup;
  appointments : PatientApointmentModel;
  constructor(private appointmentService: AppointmentService) { }

  ngOnInit() {
    this.getAppointment();
  }

  cancel(apointmentId: UUID)
  {
    debugger;
    let token: string = sessionStorage.getItem('token');    
    this.appointmentService.deleteAppointment(token,apointmentId).subscribe(res=>{
      if(res.value){
        console.log(res);
        this.getAppointment();
       
      }
    });
  }

  getAppointment()
  {
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
