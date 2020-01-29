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

  emailPattern: any = /^[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?$/;
  phone:any=/^[0-9]+$/;

  ngOnInit() {
    this.signupForm = this.formBuilder.group({
      documentId: ['', [Validators.required,Validators.maxLength(25), Validators.maxLength(10)]],
      name: ['', [Validators.required,Validators.maxLength(20), Validators.pattern(/^[a-zA-Z]+(\s*[a-zA-Z]*)*[a-zA-Z]+$/)]],
      lastName: ['', [Validators.required,Validators.maxLength(20), Validators.pattern(/^[a-zA-Z]+(\s*[a-zA-Z]*)*[a-zA-Z]+$/)]],
      phoneNumber: ['', [Validators.required, Validators.maxLength(15), Validators.pattern(this.phone)]],
      email: ['', [Validators.required,Validators.maxLength(30), Validators.pattern(this.emailPattern)]],
      userName: ['', [Validators.required,Validators.maxLength(20)]],
      password: ['', [Validators.required, Validators.maxLength(20)]]
    });
  }

  get form() {
    return this.signupForm.controls;
  }

  registerUser() {
    if (this.signupForm.valid) {
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
        if(res.statusCode==400){
          console.log(JSON.stringify(res.value));
        } else if(res.value)
          this.router.navigate(['login']);
      }, error => this.errorMessage = <any>error);;
    } else {
      console.log('Not valid')
    }
  }
}
