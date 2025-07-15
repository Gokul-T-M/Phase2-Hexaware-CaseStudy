import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { FormBuilder, Validators, ReactiveFormsModule, FormGroup, FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-appointment-book',
  standalone: true,
  templateUrl: './appointment-book.component.html',
  styleUrl: './appointment-book.component.css',
  imports: [CommonModule, ReactiveFormsModule, FormsModule]
})
export class AppointmentBookComponent implements OnInit {
  doctorId!: number;
  form: FormGroup;

  constructor(
    private route: ActivatedRoute,
    private fb: FormBuilder,
    private http: HttpClient,
    private router: Router
  ) {
    this.form = this.fb.group({
      date: ['', Validators.required],
      time: ['', Validators.required],
      symptoms: ['', [Validators.required, Validators.maxLength(200)]]
    });
  }

  ngOnInit() {
    this.doctorId = Number(this.route.snapshot.paramMap.get('doctorId'));
  }

  bookAppointment() {
    if (this.form.invalid) return;

    const date = this.form.value.date; // e.g., "2025-07-13"
    const time = this.form.value.time; // e.g., "16:33"
    const appointmentDate = new Date(`${date}T${time}`).toISOString();

    const payload = {
      doctorId: this.doctorId,
      appointmentDate: appointmentDate,
      symptoms: this.form.value.symptoms
    };

    const token = localStorage.getItem('token');
    if (!token) {
      alert('Please login first to book an appointment.');
      return;
    }

    this.http.post('http://localhost:5176/api/v1/appointments', payload, {
      headers: {
        Authorization: `Bearer ${token}`
      },
      responseType: 'text'
    }).subscribe({
      next: () => {
        alert('Appointment booked successfully');
        this.router.navigate(['/patient-dashboard']);
      },
      error: (err) => {
        console.error('Booking error:', err);
        alert('Something went wrong while booking.');
      }
    });
  }

  goBack() {
    this.router.navigate(['/doctors']);
  }
}
