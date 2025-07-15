import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { UserRegistration } from '../../models/user-registration.model'; 
import { CommonModule } from '@angular/common';
import { JsonPipe } from '@angular/common';

@Component({
  selector: 'app-template-driven-registration',
  standalone: true,
  imports: [FormsModule, CommonModule,JsonPipe],
  templateUrl: './template-driven-registration.html',
  styleUrls: ['./template-driven-registration.css']
})
export class TemplateDrivenRegistration {
  countries = ['India', 'USA', 'UK', 'Australia'];
  user: UserRegistration = {
    fullName: '',
    email: '',
    gender: '',
    country: '',
    agree: false
  };
  submitted = false;

  onSubmit(form: any) {
    if (form.valid) {
      this.submitted = true;
    }
  }
}
