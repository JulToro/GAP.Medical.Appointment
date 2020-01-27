import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http'
import { ReactiveFormsModule } from '@angular/forms';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginComponent } from './components/login/login.component';
import { AppointmentComponent } from './components/appointment/appointment.component';
import { MainComponent } from './components/main/main.component';
import { MenuComponent } from './components/menu/menu.component';
import { PatientComponent } from './components/patient/patient.component';
import { SignupComponent } from './components/signup/signup.component';
import { ScheduleComponent } from './components/schedule/schedule.component';
import { AppointmentService } from './appointment.service';
import { PatientService } from './services/patient.service';
import { PatientApointmentService } from './services/patient-apointment.service';
import { MedicalSpecialityService } from './services/medical-speciality.service';
import { LoginService } from './services/login.service';


@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    AppointmentComponent,
    MainComponent,
    MenuComponent,
    PatientComponent,
    SignupComponent,
    ScheduleComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    ReactiveFormsModule,
    HttpClientModule
  ],
  providers: [AppointmentService,PatientService,PatientApointmentService,MedicalSpecialityService,LoginService],
  bootstrap: [AppComponent]
})
export class AppModule { }
