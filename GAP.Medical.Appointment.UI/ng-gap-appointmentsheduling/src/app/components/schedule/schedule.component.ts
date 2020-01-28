import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Component, OnInit } from '@angular/core';

import { MedicalSpecialtyService } from 'src/app/services/medical-specialty.service';
import { MedicalSpecialtyModel } from '../Models/medicalSpecialtyModel';
import { AppointmentModel } from '../Models/appointmentModel';
import { AppointmentService } from 'src/app/services/appointment.service';
import { UUID } from 'angular2-uuid';
@Component({
  selector: 'app-schedule',
  templateUrl: './schedule.component.html',
  styleUrls: ['./schedule.component.scss']
})
export class ScheduleComponent implements OnInit {
  scheduleForm: FormGroup;

  dateNow = Date.now.toString();
  medicalSpecialtyId : UUID;
  public errorMessage: string;

  constructor(private formBuilder: FormBuilder, private medicalSpecialtyService: MedicalSpecialtyService, private appointmentService: AppointmentService) { }

  ngOnInit() {
    this.scheduleForm = this.formBuilder.group({
      medicalSpecialtys: ['', [Validators.required]],
      date: ['', [Validators.required]],
      time: ['', [Validators.required]]
    });
    this.getMedicineSpecialites();
  }
  registerAppointment() {
    let token = sessionStorage.getItem('token');
    let patientId = sessionStorage.getItem('id');


    let date = this.scheduleForm.controls.date.value + 'T' + this.scheduleForm.controls.time.value + 'Z';
    let shedule: AppointmentModel = {
      patientId: patientId,
      medicalSpecialtyId: this.medicalSpecialtyId,
      assignedDate: date
    }
    this.appointmentService.registerAppointment(token, shedule).subscribe((res: any) => {
      console.log(JSON.stringify(res));
    }, error => this.errorMessage = <any>error);
  }

  public medicalSpecialtys: MedicalSpecialtyModel[];
  getMedicineSpecialites() {
    let token = sessionStorage.getItem('token');
    this.medicalSpecialtyService.getMedicalSpecialities(token).subscribe((res: any) => {
      this.medicalSpecialtys = res.value;
    }, error => this.errorMessage = <any>error);
  }

  loadData(e) {
    this.medicalSpecialtyId = e;
  }
}
