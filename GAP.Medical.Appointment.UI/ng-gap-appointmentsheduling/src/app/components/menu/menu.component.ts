import { Component, OnInit, Input } from '@angular/core';
import { Observable } from 'rxjs';

import { PatientModel } from '../Models/patientModel';

@Component({
  selector: 'app-menu',
  templateUrl: './menu.component.html',
  styleUrls: ['./menu.component.scss']
})
export class MenuComponent implements OnInit {
  @Input() patient$: Observable<PatientModel>;
  patient: PatientModel;

  constructor() { }

  ngOnInit() {
    this.patient$.subscribe(res => {
      this.patient = res;
    });
  }

  logout(){
    sessionStorage.clear();
  }

}
