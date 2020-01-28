import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Validators, FormGroup, FormBuilder } from '@angular/forms';
import { PatientModel } from '../Models/patientModel';
import { PatientService } from 'src/app/services/patient.service';


@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styleUrls: ['./signup.component.scss']
})
export class SignupComponent implements OnInit {
  
  signupForm: FormGroup;

  constructor(private formBuilder: FormBuilder, private patientService: PatientService, private router: Router) { }

  errorMessage: string;

  ngOnInit() {
    this.signupForm = this.formBuilder.group({
      documentId: ['', [Validators.required]],
      name: ['', [Validators.required, Validators.maxLength(40)]],
      lastName: ['', [Validators.required, Validators.maxLength(40)]],
      phoneNumber: ['', [Validators.required, Validators.maxLength(20)]],
      email: ['', [Validators.required, Validators.email]],
      userName: ['', [Validators.required]],
      password: ['', [Validators.required]]
    });
  }

  registerUser() {
    let patient: PatientModel = {
      documentId: this.signupForm.controls.documentId.value,
      name: this.signupForm.controls.name.value,
      lastName: this.signupForm.controls.lastName.value,
      phoneNumber: this.signupForm.controls.phoneNumber.value,
      email: this.signupForm.controls.email.value,
      userName: this.signupForm.controls.userName.value,
      password: this.signupForm.controls.password.value
    }

    this.patientService.registerPatient(patient).subscribe((res: any) => {
      if (res.value)
        this.router.navigate(['login']);
    }, error => this.errorMessage = <any>error);;
  }
}
