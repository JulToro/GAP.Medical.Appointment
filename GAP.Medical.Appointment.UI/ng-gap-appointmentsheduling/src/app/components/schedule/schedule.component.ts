import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Component, OnInit } from '@angular/core';

import { MedicalSpecialtyService } from 'src/app/services/medical-specialty.service';
import { MedicalSpecialtyModel } from '../Models/medicalSpecialtyModel';
@Component({
  selector: 'app-schedule',
  templateUrl: './schedule.component.html',
  styleUrls: ['./schedule.component.scss']
})
export class ScheduleComponent implements OnInit {
  scheduleForm: FormGroup;

  dateNow = Date.now.toString();

  public errorMessage: string;  

  constructor(private formBuilder: FormBuilder, private medicalSpecialtyService: MedicalSpecialtyService) { }

  ngOnInit() {
    this.scheduleForm = this.formBuilder.group({
      medicalSpecialtys: ['', [Validators.required]],
      date: ['', [Validators.required]],
      time: ['', [Validators.required]]
    });
    this.getMedicineSpecialites();
  }
  onSubmit() {}
  
  public medicalSpecialtys: MedicalSpecialtyModel[];
  getMedicineSpecialites()
  {   
    let token = sessionStorage.getItem('token');
    this.medicalSpecialtyService.getMedicalSpecialities(token).subscribe((res: any)=>
    {      
      this.medicalSpecialtys = res.value;
    }, error => this.errorMessage = <any>error);  
  }

  loadData(e){
    console.log(e)
  }
}
