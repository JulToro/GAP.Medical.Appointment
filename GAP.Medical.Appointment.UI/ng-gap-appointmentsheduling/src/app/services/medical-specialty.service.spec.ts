import { TestBed } from '@angular/core/testing';

import { MedicalSpecialtyService } from './medical-specialty.service';

describe('MedicalSpecialtyService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: MedicalSpecialtyService = TestBed.get(MedicalSpecialtyService);
    expect(service).toBeTruthy();
  });
});
