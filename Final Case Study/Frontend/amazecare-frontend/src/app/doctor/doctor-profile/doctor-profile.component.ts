import { Component, OnInit } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { FormBuilder, FormGroup, Validators, ReactiveFormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-doctor-profile',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule],
  templateUrl: './doctor-profile.component.html',
  styleUrl: './doctor-profile.component.css'
})
export class DoctorProfileComponent implements OnInit {
  profileForm!: FormGroup;
  loading = true;
  error = '';
  message = '';
  editing = false;
  success = false;

  constructor(private http: HttpClient, private fb: FormBuilder) {}

  ngOnInit(): void {
    const doctorId = localStorage.getItem('doctorId');
    const token = localStorage.getItem('token');

    if (!doctorId || !token) {
      this.error = 'Not logged in. Please login again.';
      this.loading = false;
      return;
    }

    const headers = new HttpHeaders().set('Authorization', `Bearer ${token}`);

    this.http.get<any>(`http://localhost:5176/api/v1/doctors/${doctorId}`, { headers }).subscribe({
      next: (data) => {
        console.log('Fetched doctor profile:', data);
        this.profileForm = this.fb.group({
          name: [data.name],
          email: [data.email],
          specialty: [data.specialty],
          experience: [data.experience],
          qualification: [data.qualification],
          designation: [data.designation],
          password: ['', Validators.required] // required for update
        });
        this.loading = false;
      },
      error: () => {
        this.error = 'Failed to load doctor profile.';
        this.loading = false;
      }
    });
  }

  updateProfile() {
    const doctorId = localStorage.getItem('doctorId');
    const token = localStorage.getItem('token');

    const headers = new HttpHeaders().set('Authorization', `Bearer ${token}`);

    const updatedDoctor = {
      doctorId: Number(doctorId),
      name: this.profileForm.value.name,
      email: this.profileForm.value.email,
      specialty: this.profileForm.value.specialty,
      experience: this.profileForm.value.experience,
      qualification: this.profileForm.value.qualification,
      designation: this.profileForm.value.designation,
      password: this.profileForm.value.password
    };

    this.http.put(
      `http://localhost:5176/api/v1/doctors/${doctorId}`,
      updatedDoctor,
      {
        headers,
        observe: 'response',
        responseType: 'text' as 'json'
      }
    ).subscribe({
      next: () => {
        this.message = 'Profile updated successfully!';
        this.success = true;
        this.editing = false;
        setTimeout(() => this.message = '', 3000);
      },
      error: (err) => {
        console.error('Update failed:', err);
        this.message = 'Failed to update profile.';
        this.success = false;
      }
    });
  }

  enableEdit() {
    this.editing = true;
  }

  cancelEdit() {
    this.editing = false;
    this.message = '';
    this.success = false;
  }
}
