import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PatientProfileComponent } from './patient-profile/patient-profile.component';
import { PatientAppointmentsComponent } from './patient-appointments/patient-appointments.component';
import { PatientDoctorTabComponent } from './patient-doctor-tab/patient-doctor-tab.component';


@Component({
  selector: 'app-patient-dashboard',
  standalone: true,
  imports: [CommonModule, PatientProfileComponent, PatientAppointmentsComponent, PatientDoctorTabComponent],
  templateUrl: './patient-dashboard.component.html',
  styleUrl: './patient-dashboard.component.css'
})
export class PatientDashboardComponent {
  activeTab = 'profile';

  switchTab(tab: string) {
    this.activeTab = tab;
  }
}
