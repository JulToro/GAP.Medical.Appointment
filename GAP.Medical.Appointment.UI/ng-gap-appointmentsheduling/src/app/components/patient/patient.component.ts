import { Component, OnInit } from '@angular/core';
import { PatientService } from 'src/app/services/patient.service';
import { PatientModel } from '../Models/patientModel';
import { UUID } from 'angular2-uuid';

@Component({
  selector: 'app-patient',
  templateUrl: './patient.component.html',
  styleUrls: ['./patient.component.scss']
})
export class PatientComponent implements OnInit {

  patient: PatientModel;
  constructor(private patientService: PatientService) { }

  ngOnInit() {
    let patientId: UUID = sessionStorage.getItem('id');
    let token: string = sessionStorage.getItem('token');

    
    this.patientService.getInfoPatient(patientId,token).subscribe(res=>{
      if(res.value)
        this.patient = res.value;
    });
  }
  
}
