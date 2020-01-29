import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Validators, FormGroup, FormBuilder } from '@angular/forms';
import { LoginModel } from '../Models/LoginModel';
import { LoginResponseModel } from '../Models/loginResponseModel';
import { LoginService } from 'src/app/services/login.service';


@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {
  loginForm: FormGroup;
  errorMessage: string;

  constructor(private formBuilder: FormBuilder, private loginService: LoginService, private router: Router) { }

  ngOnInit() {
    this.loginForm = this.formBuilder.group({
      userName: ['', [Validators.required,Validators.maxLength(20)]],
      password: ['', [Validators.required,Validators.maxLength(20)]]
    });
  }

  get form() {
    return this.loginForm.controls;
  }
  
  login() {
    let patient: LoginModel = {
      userName: this.loginForm.controls.userName.value,
      password: this.loginForm.controls.password.value
    }
    this.loginService.login(patient).subscribe((res: any) => {
      debugger;
      if(res.statusCode==400){
        console.log(JSON.stringify(res.value));
      } else if (res.value) {
        let loginResponse: LoginResponseModel = res.value;
        sessionStorage.setItem('token', loginResponse.token);
        sessionStorage.setItem('id', loginResponse.id.toString());
        this.router.navigate(['main/schedule']);
      }
    },
      error => this.errorMessage = <any>error
    );;
  }

}
