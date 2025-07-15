import { Component, signal } from '@angular/core';
import { RouterOutlet } from '@angular/router';
//import { FormsModule } from '@angular/forms';
import { StudentFeedbackComponent } from './student-feedback/student-feedback';
//import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet,StudentFeedbackComponent],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App {
  protected readonly title = signal('student-feedback-app');
}
