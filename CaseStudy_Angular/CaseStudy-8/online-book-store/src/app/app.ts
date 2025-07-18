import { Component, signal } from '@angular/core';
import { RouterOutlet, RouterModule } from '@angular/router';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, RouterModule], // <-- RouterModule for routerLink
  templateUrl: './app.html',
  styleUrls: ['./app.css'] // <-- Correct property name
})
export class App {
  protected readonly title = signal('online-book-store');
}
