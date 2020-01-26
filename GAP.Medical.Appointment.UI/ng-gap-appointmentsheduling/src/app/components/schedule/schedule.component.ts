import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Component, OnInit } from '@angular/core';
import { AppointmentService } from 'src/app/services/appointment.service';
import { debug } from 'util';
import { MedicalSpecialityService } from 'src/app/services/medical-speciality.service';
@Component({
  selector: 'app-schedule',
  templateUrl: './schedule.component.html',
  styleUrls: ['./schedule.component.scss']
})
export class ScheduleComponent implements OnInit {
  scheduleForm: FormGroup;

  specialities = [
    { name: "General", id: 0 },
    { name: "Odontology", id: 1 },
    { name: "Brain", id: 2 }
  ];
  dateNow = Date.now.toString();


  constructor(private formBuilder: FormBuilder, private medicalSpecialityService: MedicalSpecialityService) { }

  ngOnInit() {
    this.scheduleForm = this.formBuilder.group({
      specialities: ['', [Validators.required]],
      date: ['', [Validators.required]],
      time: ['', [Validators.required]]
    });
    this.getMedicineSpecialites();
  }
  onSubmit() {}

  getMedicineSpecialites()
  {    
    var specialites  = this.medicalSpecialityService.getMedicalSpecialities().subscribe((res:any)=>
    { 
      console.log(res)
    });   
  }

  loadData(e){
    console.log(e)
  }
}
