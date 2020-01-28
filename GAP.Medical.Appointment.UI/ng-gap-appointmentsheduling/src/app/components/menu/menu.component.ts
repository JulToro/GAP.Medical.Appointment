import { Component, OnInit, Input } from '@angular/core';
import { Observable } from 'rxjs';

import { PatientModel } from '../Models/patientModel';
import { Router } from '@angular/router';

@Component({
  selector: 'app-menu',
  templateUrl: './menu.component.html',
  styleUrls: ['./menu.component.scss']
})
export class MenuComponent implements OnInit {
  @Input() patient$: Observable<PatientModel>;
  patient: PatientModel;

  constructor(private router: Router) { }

  ngOnInit() {
    this.patient$.subscribe(res => {
      this.patient = res;
    });
  }

  logout(){
    sessionStorage.clear();
  }

  goProfile(){
    this.router.navigate(['main/profile']);
  }

}
