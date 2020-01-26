import { TestBed } from '@angular/core/testing';

import { PatientApointmentService } from './patient-apointment.service';

describe('PatientApointmentService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: PatientApointmentService = TestBed.get(PatientApointmentService);
    expect(service).toBeTruthy();
  });
});
