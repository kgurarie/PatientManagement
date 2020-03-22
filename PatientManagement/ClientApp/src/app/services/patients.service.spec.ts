import { TestBed } from '@angular/core/testing';

import { PatientsService } from './patients.service';
import { HttpClientModule } from '@angular/common/http';
import { HttpClientTestingModule } from '@angular/common/http/testing';

describe('PatientsService', () => {
  beforeEach(() => TestBed.configureTestingModule({
    imports: [HttpClientModule, HttpClientTestingModule]
  }));

  it('should be created', () => {
    const service: PatientsService = TestBed.get(PatientsService);
    expect(service).toBeTruthy();
  });
});
