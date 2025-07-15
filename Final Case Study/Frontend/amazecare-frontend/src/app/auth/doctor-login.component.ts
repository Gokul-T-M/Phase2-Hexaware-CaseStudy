import { Component } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { HttpClient } from '@angular/common/http';
import { jwtDecode } from 'jwt-decode';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-doctor-login',
  standalone: true,
  templateUrl: './doctor-login.component.html',
  styleUrl: './doctor-login.component.css',
  imports: [CommonModule, ReactiveFormsModule],
})
export class DoctorLoginComponent {
  loginForm: FormGroup;
  message = '';
  loading = false;

  constructor(private fb: FormBuilder, private http: HttpClient, private router: Router) {
    this.loginForm = this.fb.group({
      email: ['', [Validators.required, Validators.email]],
      password: ['', Validators.required],
    });
  }

  login() {
  if (this.loginForm.invalid) return;

  this.loading = true;

  this.http.post<any>('http://localhost:5176/api/v1/auth/login', this.loginForm.value).subscribe({
    next: (res) => {
      const decoded: any = jwtDecode(res.token);

      const role = decoded['http://schemas.microsoft.com/ws/2008/06/identity/claims/role'];
      const id = decoded['http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier'];

      if (role === 'Doctor') {
        localStorage.setItem('token', res.token);
        localStorage.setItem('role', role);
        localStorage.setItem('doctorId', id.toString()); // ✅ make sure it's string

        this.router.navigate(['/doctor-dashboard']);
      } else {
        this.message = 'Not authorized as a doctor.';
      }
      this.loading = false;
    },
    error: () => {
      this.message = 'Login failed. Invalid credentials.';
      this.loading = false;
    },
  });
}

}
