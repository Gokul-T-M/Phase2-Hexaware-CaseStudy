import { Component, OnInit } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-doctor-appointments',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './doctor-appointments.component.html',
  styleUrl: './doctor-appointments.component.css'
})
export class DoctorAppointmentsComponent implements OnInit {
  appointments: any[] = [];
  loading = true;
  error = '';
  editingId: number | null = null;
  consultingDetails = '';
  prescriptions = '';
  recommendedTests = '';

  patientProfile: any = null;
  patientAppointments: any[] = [];

  viewingProfile = false;
  viewingAllAppointments = false;

  constructor(private http: HttpClient) {}

  ngOnInit(): void {
    const doctorId = localStorage.getItem('doctorId');
    const token = localStorage.getItem('token');

    if (!doctorId || !token) {
      this.error = 'Not logged in. Please login again.';
      this.loading = false;
      return;
    }

    const headers = new HttpHeaders().set('Authorization', `Bearer ${token}`);

    this.http.get<any[]>(`http://localhost:5176/api/v1/appointments/doctor/${doctorId}`, { headers }).subscribe({
      next: (data) => {
        this.appointments = (data || []).sort((a, b) => {
          const dateA = new Date(a.appointmentDate).getTime();
          const dateB = new Date(b.appointmentDate).getTime();

          const statusOrder = (status: string) => {
            if (status === 'Scheduled') return 0;
            if (status === 'Completed') return 1;
            return 2;
          };

          const statusDiff = statusOrder(a.status) - statusOrder(b.status);
          if (statusDiff !== 0) return statusDiff;

          if (a.status === 'Scheduled') return dateA - dateB;
          if (a.status === 'Completed') return dateB - dateA;

          return 0;
        });

        this.loading = false;
      },
      error: () => {
        this.error = 'Failed to load appointments.';
        this.loading = false;
      }
    });
  }

  cancelAppointment(id: number) {
    if (!confirm('Are you sure you want to cancel this appointment?')) return;

    const token = localStorage.getItem('token');
    const headers = new HttpHeaders().set('Authorization', `Bearer ${token}`);

    this.http.delete(`http://localhost:5176/api/v1/appointments/${id}`, {
      headers,
      responseType: 'text'
    }).subscribe({
      next: () => {
        this.appointments = this.appointments.filter(a => a.appointmentId !== id);
        alert('Appointment cancelled.');
      },
      error: () => {
        alert('Failed to cancel appointment.');
      }
    });
  }

  startEditing(appointment: any) {
    this.editingId = appointment.appointmentId;
    this.consultingDetails = appointment.consultingDetails || '';
    this.prescriptions = appointment.prescriptions || '';
    this.recommendedTests = appointment.recommendedTests || '';
  }

  cancelEdit() {
    this.editingId = null;
    this.consultingDetails = '';
    this.prescriptions = '';
    this.recommendedTests = '';
  }

  submitConsultation(id: number) {
    const token = localStorage.getItem('token');
    const headers = new HttpHeaders().set('Authorization', `Bearer ${token}`);

    const body = {
      appointmentId: id,
      consultingDetails: this.consultingDetails,
      prescriptions: this.prescriptions,
      recommendedTests: this.recommendedTests,
      status: 'Completed'
    };

    this.http.put(`http://localhost:5176/api/v1/appointments/${id}`, body, {
      headers,
      responseType: 'text' as 'json'
    }).subscribe({
      next: () => {
        const updated = this.appointments.find(a => a.appointmentId === id);
        if (updated) {
          updated.consultingDetails = this.consultingDetails;
          updated.prescriptions = this.prescriptions;
          updated.recommendedTests = this.recommendedTests;
          updated.status = 'Completed';
        }
        alert('Consultation updated!');
        this.cancelEdit();
      },
      error: () => alert('Failed to update consultation.')
    });
  }

  viewPatientProfile(patientId: number) {
    this.viewingProfile = true;
    this.viewingAllAppointments = false;
    this.patientAppointments = [];

    const token = localStorage.getItem('token');
    const headers = new HttpHeaders().set('Authorization', `Bearer ${token}`);

    this.http.get(`http://localhost:5176/api/v1/patients/${patientId}`, { headers }).subscribe({
      next: (data) => this.patientProfile = data,
      error: () => alert('Failed to fetch patient profile.')
    });
  }

  viewPatientAppointments(patientId: number) {
    this.viewingAllAppointments = true;
    this.viewingProfile = false;
    this.patientProfile = null;

    const token = localStorage.getItem('token');
    const headers = new HttpHeaders().set('Authorization', `Bearer ${token}`);

    this.http.get<any[]>(`http://localhost:5176/api/v1/appointments/patient/${patientId}`, { headers }).subscribe({
      next: (data) => {
        this.patientAppointments = (data || []).sort((a, b) =>
          new Date(b.appointmentDate).getTime() - new Date(a.appointmentDate).getTime()
        );
      },
      error: () => alert('Failed to fetch patient appointments.')
    });
  }

  closePanel() {
    this.viewingProfile = false;
    this.viewingAllAppointments = false;
    this.patientProfile = null;
    this.patientAppointments = [];
  }
}
