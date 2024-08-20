import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SandalsComponent } from './sandals.component';

describe('SandalsComponent', () => {
  let component: SandalsComponent;
  let fixture: ComponentFixture<SandalsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [SandalsComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(SandalsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
