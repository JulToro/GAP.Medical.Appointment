import { TestBed } from '@angular/core/testing';

import { MedicalSpecialityService } from './medical-speciality.service';

describe('MedicalSpecialityService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: MedicalSpecialityService = TestBed.get(MedicalSpecialityService);
    expect(service).toBeTruthy();
  });
});
