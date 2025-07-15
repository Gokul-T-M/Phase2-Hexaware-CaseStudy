import { Component, signal } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { EmployeeAttendance } from './employee-attendance/employee-attendance';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet, EmployeeAttendance],
  templateUrl: './app.html',
  styleUrls: ['./app.css']
})
export class App {
  protected readonly title = signal('attendance-dashboard');
}
