import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TemplateDrivenRegistration } from './template-driven-registration';

describe('TemplateDrivenRegistration', () => {
  let component: TemplateDrivenRegistration;
  let fixture: ComponentFixture<TemplateDrivenRegistration>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [TemplateDrivenRegistration]
    })
    .compileComponents();

    fixture = TestBed.createComponent(TemplateDrivenRegistration);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
