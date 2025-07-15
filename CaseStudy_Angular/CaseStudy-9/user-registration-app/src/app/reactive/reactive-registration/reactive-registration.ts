import { Component } from '@angular/core';
import { ReactiveFormsModule, FormBuilder, Validators, FormGroup } from '@angular/forms';
import { NgIf, NgForOf, JsonPipe } from '@angular/common'; // <-- Import NgForOf
import { UserRegistration } from '../../models/user-registration.model';

@Component({
  selector: 'app-reactive-registration',
  standalone: true,
  imports: [ReactiveFormsModule, NgIf, NgForOf, JsonPipe], // <-- Add NgForOf here
  templateUrl: './reactive-registration.html',
  styleUrls: ['./reactive-registration.css']
})
export class ReactiveRegistration {
  countries = ['India', 'USA', 'UK', 'Australia'];
  submitted = false;
  userData: UserRegistration | null = null;
  registrationForm: FormGroup;

  constructor(private fb: FormBuilder) {
    this.registrationForm = this.fb.group({
      fullName: ['', Validators.required],
      email: ['', [Validators.required, Validators.email]],
      gender: ['', Validators.required],
      country: ['', Validators.required],
      agree: [false, Validators.requiredTrue]
    });
  }

  onSubmit() {
    if (this.registrationForm.valid) {
      this.submitted = true;
      this.userData = this.registrationForm.value as UserRegistration;
    }
  }
}
