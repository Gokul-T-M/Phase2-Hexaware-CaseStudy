import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DoctorProfileComponent } from '../doctor-profile/doctor-profile.component';
import { DoctorAppointmentsComponent } from '../doctor-appointments/doctor-appointments.component';

@Component({
  selector: 'app-doctor-dashboard',
  standalone: true,
  imports: [CommonModule, DoctorProfileComponent, DoctorAppointmentsComponent],
  templateUrl: './doctor-dashboard.component.html',
  styleUrl: './doctor-dashboard.component.css'
})
export class DoctorDashboardComponent {
  activeTab = 'profile'; // default tab

  setTab(tab: string) {
    this.activeTab = tab;
  }
}
