import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Component, OnInit } from '@angular/core';
import { AppointmentService } from 'src/app/services/appointment.service';
import { debug } from 'util';
import { MedicalSpecialityService } from 'src/app/services/medical-speciality.service';
import { MedicalSpecialityModel } from '../Models/medicalSpecialityModel';
@Component({
  selector: 'app-schedule',
  templateUrl: './schedule.component.html',
  styleUrls: ['./schedule.component.scss']
})
export class ScheduleComponent implements OnInit {
  scheduleForm: FormGroup;

  dateNow = Date.now.toString();

  public errorMessage: string;  

  constructor(private formBuilder: FormBuilder, private medicalSpecialityService: MedicalSpecialityService) { }

  ngOnInit() {
    this.scheduleForm = this.formBuilder.group({
      medicalSpecialitys: ['', [Validators.required]],
      date: ['', [Validators.required]],
      time: ['', [Validators.required]]
    });
    this.getMedicineSpecialites();
  }
  onSubmit() {}


  public medicalSpecialitys: MedicalSpecialityModel[];
  getMedicineSpecialites()
  {    
    this.medicalSpecialityService.getMedicalSpecialities().subscribe((res: any)=>
    {      
      this.medicalSpecialitys = res.value;
    }, error => this.errorMessage = <any>error);  
  }

  loadData(e){
    console.log(e)
  }
}
