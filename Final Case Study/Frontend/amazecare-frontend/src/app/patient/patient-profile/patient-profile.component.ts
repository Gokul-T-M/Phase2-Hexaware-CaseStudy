import { Component, OnInit } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http'; // <-- updated
import { FormBuilder, FormGroup } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule } from '@angular/forms';
import { Validators } from '@angular/forms'; 

@Component({
  selector: 'app-patient-profile',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule],
  templateUrl: './patient-profile.component.html',
  styleUrl: './patient-profile.component.css'
})
export class PatientProfileComponent implements OnInit {
  profileForm!: FormGroup;
  loading = true;
  error = '';
  message = '';
  editing = false;
  success = false;

  constructor(private http: HttpClient, private fb: FormBuilder) {}

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

     this.http.get<any>(`http://localhost:5176/api/v1/patients/${patientId}`, { headers }).subscribe({
    next: (data) => {
      console.log('Fetched profile:', data);
      this.profileForm = this.fb.group({
      name: [data.name],
      email: [data.email],
      contactNumber: [data.contactNumber],
      dateOfBirth: [data.dateOfBirth.substring(0, 10)],
      gender: [data.gender],
      previousMedicalRecords: [data.previousMedicalRecords],
      password: ['',Validators.required]  // 👈 Add this line
    });
      this.loading = false;
    },
      error: () => {
        this.error = 'Failed to load profile.';
        this.loading = false;
      }
    });
  }

 updateProfile() {
  const patientId = localStorage.getItem('patientId');
  const token = localStorage.getItem('token');
  const headers = new HttpHeaders().set('Authorization', `Bearer ${token}`);

  const updatedPatient = {
    patientId: Number(patientId),
    name: this.profileForm.value.name,
    email: this.profileForm.value.email,
    contactNumber: this.profileForm.value.contactNumber,
    dateOfBirth: this.profileForm.value.dateOfBirth,
    gender: this.profileForm.value.gender,
    previousMedicalRecords: this.profileForm.value.previousMedicalRecords,
    password: this.profileForm.value.password
  };

  this.http.put(
  `http://localhost:5176/api/v1/patients/${patientId}`,
  updatedPatient,
  {
    headers,
    observe: 'response',
    responseType: 'text' as 'json'  // 👈 THIS FIXES THE ERROR
  }
  ).subscribe({
    next: () => {
      this.message = 'Profile updated successfully!';
      this.success = true;
      this.editing = false;
      setTimeout(() => this.message = '', 3000);
    },
    error: (err) => {
      console.error('Update error:', err);
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
