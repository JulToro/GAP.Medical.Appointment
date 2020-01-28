import { Component, OnInit } from '@angular/core';
import { PatientService } from 'src/app/services/patient.service';
import { PatientModel } from '../Models/patientModel';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
@Component({
  selector: 'app-main',
  templateUrl: './main.component.html',
  styleUrls: ['./main.component.scss']
})
export class MainComponent implements OnInit {

  patient$: Observable<PatientModel>;
  errorMessage: string;
  constructor(private patientService: PatientService, private router: Router) { }

  ngOnInit() {

    let token = sessionStorage.getItem('token');
    let patientId = sessionStorage.getItem('id');

    this.patient$ = this.patientService.getInfoPatient(patientId, token).pipe(map(res => {
      if (res.value) {
        let patient: PatientModel = {
          id: res.value.id,
          documentId: res.value.documentId,
          name: res.value.name,
          lastName: res.value.lastName,
          phoneNumber: res.value.phoneNumber,
          email: res.value.email
        };
        sessionStorage.setItem('patient', JSON.stringify(patient));
        return patient;
      }      
    }, error => {
      this.errorMessage = <any>error;
      console.log(this.errorMessage);
      this.router.navigate(['login']);
    }));
  }

}
