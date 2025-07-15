import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ReactiveRegistration } from './reactive-registration';

describe('ReactiveRegistration', () => {
  let component: ReactiveRegistration;
  let fixture: ComponentFixture<ReactiveRegistration>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ReactiveRegistration]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ReactiveRegistration);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
