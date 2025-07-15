import { Component, OnInit } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http'; // <-- updated
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-patient-appointments',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './patient-appointments.component.html',
  styleUrl: './patient-appointments.component.css'
})
export class PatientAppointmentsComponent implements OnInit {
  appointments: any[] = [];
  loading = true;
  error = '';

  constructor(private http: HttpClient) {}

  ngOnInit(): void {
    const patientId = localStorage.getItem('patientId');
    console.log('Stored patientId:', patientId);
    if (!patientId) {
      this.error = 'Not logged in. Please login again.';
      this.loading = false;
      return;
    }

    const token = localStorage.getItem('token');
    const headers = new HttpHeaders().set('Authorization', `Bearer ${token}`);

    this.http.get<any[]>(`http://localhost:5176/api/v1/appointments/patient/${patientId}`, { headers }).subscribe({
      next: (data) => {
        console.log('Appointments fetched:', data);
        this.appointments = (data || []).sort((a, b) => {
          return new Date(b.appointmentDate).getTime() - new Date(a.appointmentDate).getTime();
        });

        this.loading = false;
      },
      error: () => {
        this.error = 'Failed to load appointments.';
        this.loading = false;
      }
    });
  }

  deleteAppointment(id: number) {
    if (!confirm('Are you sure you want to Cancel this appointment?')) return;

    const token = localStorage.getItem('token');
    const headers = new HttpHeaders().set('Authorization', `Bearer ${token}`);

    this.http.delete(`http://localhost:5176/api/v1/appointments/${id}`, { 
    headers,
    responseType: 'text' // backend returns a plain text response (return Ok("Appointment cancelled")), Angular expects JSON by default. 
    }).subscribe({
    next: () => {
      this.appointments = this.appointments.filter(a => a.appointmentId !== id);
      alert('Appointment Cancelled successfully!');
    },
    error: () => alert('Failed to Cancel appointment.')
    });
  }
}
