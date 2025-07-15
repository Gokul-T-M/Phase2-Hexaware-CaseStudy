import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators, ReactiveFormsModule, FormsModule } from '@angular/forms';
import { Router, RouterModule } from '@angular/router';
import { CommonModule } from '@angular/common';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-patient-register',
  standalone: true,
  templateUrl: './patient-register.component.html',
  styleUrl: './patient-register.component.css',
  imports: [CommonModule, ReactiveFormsModule, FormsModule, RouterModule]
})
export class PatientRegisterComponent {
  form: FormGroup;
  message = '';

  constructor(private fb: FormBuilder, private http: HttpClient, private router: Router) {
    this.form = this.fb.group({
  name: ['', Validators.required],
  email: ['', [Validators.required, Validators.email]],
  password: ['', Validators.required],
  contactNumber: ['', Validators.required],
  dateOfBirth: ['', Validators.required],
  gender: ['', Validators.required]
});


  }

  register() {
  if (this.form.invalid) return;

  this.http.post('http://localhost:5176/api/v1/auth/register/patient', this.form.value)
    .subscribe({
      next: () => {
        alert('User registered. Please login!');
        this.router.navigate(['/patient-login']);
      },
      error: (err) => {
        console.error(err);
        alert('Registration failed. Please check your input.');
      }
    });
}

}
