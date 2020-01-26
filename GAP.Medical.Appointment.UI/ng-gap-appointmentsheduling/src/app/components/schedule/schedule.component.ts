import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Component, OnInit } from '@angular/core';

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
  constructor(private formBuilder: FormBuilder) { }

  ngOnInit() {
    this.scheduleForm = this.formBuilder.group({
      specialities: ['', [Validators.required]],
      date: ['', [Validators.required]],
      time: ['', [Validators.required]]
    })
  }
  onSubmit() {}
}
