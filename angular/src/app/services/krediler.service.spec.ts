import { TestBed } from '@angular/core/testing';

import { KredilerService } from './krediler.service';

describe('KredilerService', () => {
  let service: KredilerService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(KredilerService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
