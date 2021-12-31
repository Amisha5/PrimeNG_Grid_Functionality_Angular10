import { TestBed } from '@angular/core/testing';

import { EmployeeRecordService } from './employee-record.service';

describe('EmployeeRecordService', () => {
  let service: EmployeeRecordService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(EmployeeRecordService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
