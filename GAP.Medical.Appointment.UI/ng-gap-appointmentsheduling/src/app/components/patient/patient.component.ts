import { Component, OnInit } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { PatientService } from 'src/app/services/patient.service';

@Component({
  selector: 'app-patient',
  templateUrl: './patient.component.html',
  styleUrls: ['./patient.component.scss']
})
export class PatientComponent implements OnInit {

  patientForm: FormGroup;

  patient = [
    { name: "General", id: 0 },
    { name: "Odontology", id: 1 },
    { name: "Brain", id: 2 }
  ];

  constructor(private patientService: PatientService) { }

  ngOnInit() {

    this.getPatient("");
  }
  
  getPatient(id:string)
  {
    var specialites  = this.patientService.getInfoPatient();
  }
}
