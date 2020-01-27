import { Component, OnInit } from '@angular/core';
import { Validators, FormGroup, FormBuilder } from '@angular/forms';
import { PatientModel } from '../Models/patientModel';
import { LoginModel } from '../Models/LoginModel';
import { PatientService } from 'src/app/services/patient.service';
import { LoginService } from 'src/app/services/login.service';
@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styleUrls: ['./signup.component.scss']
})
export class SignupComponent implements OnInit {
  singupForm: FormGroup;


  public patientModel: PatientModel= {
    id : "",
    documentId :"",
    name :"", 
    lastName :"",
    phoneNumber :"",
    email :"",
    userName :"",
    password :"",
  };
  public loginModel: LoginModel;

  public patientRegiser:PatientModel;

  public documentId: string;
  public name : string;
  public lastName  : string;
  public phoneNumber  : string;
  public email  : string;
  public userName  : string;
  public password  : string;

  constructor(private formBuilder: FormBuilder, private patientService: PatientService, private loginService: LoginService) { }
  
  public errorMessage: string;  
  
  ngOnInit() {
    this.singupForm = this.formBuilder.group({
      documentId: ['', [Validators.required]],
      name: ['', [Validators.required]],
      lastName: ['', [Validators.required]],
      phoneNumber: ['', [Validators.required]],
      email: ['', [Validators.required]],
      userName: ['', [Validators.required]],
      password: ['', [Validators.required]]
    });
  }
  onSubmit() {
    this.registerUser();
  }

  registerUser()
  {
    this.patientService.registerPatient(this.getPatient()).subscribe((res: any)=>
    {          
      this.patientRegiser = res.value;
    }, error => this.errorMessage = <any>error);  ;
  }



  getPatient(){
    debugger;  
    this.patientModel.documentId =  this.singupForm.controls.documentId.value;
    this.patientModel.name = this.singupForm.controls.name.value;
    this.patientModel.lastName = this.singupForm.controls.lastName.value;
    this.patientModel.phoneNumber = this.singupForm.controls.phoneNumber.value;
    this.patientModel.email = this.singupForm.controls.email.value;
    this.patientModel.userName = this.singupForm.controls.userName.value;
    this.patientModel.password = this.singupForm.controls.password.value;

      return this.patientModel;
  }





}
