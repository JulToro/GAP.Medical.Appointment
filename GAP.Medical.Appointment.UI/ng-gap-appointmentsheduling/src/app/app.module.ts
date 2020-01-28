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

import { PatientService } from './services/patient.service';
import { PatientApointmentService } from './services/patient-apointment.service';
import { MedicalSpecialtyService } from './services/medical-specialty.service';
import { LoginService } from './services/login.service';
import { AppointmentService } from './services/appointment.service';


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
  providers: [AppointmentService, PatientService, PatientApointmentService, MedicalSpecialtyService, LoginService],
  bootstrap: [AppComponent]
})
export class AppModule { }
