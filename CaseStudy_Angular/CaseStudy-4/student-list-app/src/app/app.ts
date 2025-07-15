import { Component, signal } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { StudentList } from './student-list/student-list';


@Component({
  selector: 'app-root',
  imports: [RouterOutlet, StudentList],
  templateUrl: './app.html',
  styleUrls: ['./app.css']
})
export class App {
  protected readonly title = signal('student-list-app');
}
