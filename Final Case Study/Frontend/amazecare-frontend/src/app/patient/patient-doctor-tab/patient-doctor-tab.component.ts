import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DoctorListComponent } from '../../doctor/doctor-list.component'; 

@Component({
  selector: 'app-patient-doctor-tab',
  standalone: true,
  imports: [CommonModule, DoctorListComponent],
  template: `<app-doctor-list></app-doctor-list>`
})
export class PatientDoctorTabComponent {}
