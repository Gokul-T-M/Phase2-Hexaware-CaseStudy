import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators, ReactiveFormsModule, FormsModule } from '@angular/forms';
import { Router, RouterModule } from '@angular/router';
import { HttpClient } from '@angular/common/http';
import { CommonModule } from '@angular/common';
import { jwtDecode } from 'jwt-decode';


@Component({
  selector: 'app-patient-login',
  standalone: true,
  templateUrl: './patient-login.component.html',
  styleUrl: './patient-login.component.css',
  imports: [CommonModule, ReactiveFormsModule, FormsModule, RouterModule]
})
export class PatientLoginComponent implements OnInit {
  loginForm!: FormGroup;

  constructor(
    private fb: FormBuilder,
    private http: HttpClient,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.loginForm = this.fb.group({
      email: ['', [Validators.required, Validators.email]],
      password: ['', Validators.required]
    });
  }

  login() {
  const payload = {
    email: this.loginForm.value.email,
    password: this.loginForm.value.password
  };

  this.http.post<any>('http://localhost:5176/api/v1/auth/login', payload).subscribe({
    next: (response) => {
      localStorage.setItem('token', response.token);
      localStorage.setItem('role', 'Patient');

      const decoded: any = jwtDecode(response.token);


      // 👇 Extract patientId using the full claim URI
      const patientId = decoded["http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier"];
      localStorage.setItem('patientId', patientId);

      if (!patientId) {
        alert("Patient ID not found in token.");
        return;
      }

      localStorage.setItem('patientId', patientId);

      const redirectDoctorId = localStorage.getItem('redirectDoctorId');
      if (redirectDoctorId) {
        localStorage.removeItem('redirectDoctorId');
        this.router.navigate(['/book-appointment', redirectDoctorId]);
      } else {
        this.router.navigate(['/patient-dashboard']);
      }
    },
    error: () => {
      alert('Invalid credentials. Please try again.If not registered, Please Register First');
    }
  });
}
}
