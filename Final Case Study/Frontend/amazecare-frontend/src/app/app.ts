import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { Router, RouterModule } from '@angular/router';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [CommonModule, RouterModule], 
  templateUrl: './app.html',
  styleUrls: ['./app.css']
})
export class AppComponent implements OnInit {
  isLoggedIn = false;
  isPatient = false;
  isDoctor = false;

  constructor(private router: Router) {}

  ngOnInit() {
    const token = localStorage.getItem('token');
    if (token) {
      this.isLoggedIn = true;

      try {
        const payload = JSON.parse(atob(token.split('.')[1]));
        const role = payload["http://schemas.microsoft.com/ws/2008/06/identity/claims/role"];

        this.isPatient = role === 'Patient';
        this.isDoctor = role === 'Doctor';
      } catch (e) {
        console.error('Invalid token');
      }
    }
  }

  scrollToDoctors() {
    document.getElementById('doctor-section')?.scrollIntoView({ behavior: 'smooth' });
  }

  scrollToSection(id: string) {
    document.getElementById(id)?.scrollIntoView({ behavior: 'smooth' });
  }

  navigateToPatientLogin() {
    this.router.navigate(['/patient-login']);
  }

  navigateToDoctorLogin() {
    this.router.navigate(['/doctor-login']);
  }

  logout() {
    localStorage.clear();
    this.isLoggedIn = false;
    this.isPatient = false;
    this.isDoctor = false;
    this.router.navigate(['/']);
  }
  
  onLoginSuccess() {
    this.checkLoginStatus();
  }
  
  
  checkLoginStatus() {
  const token = localStorage.getItem('token');
  this.isLoggedIn = false;
  this.isPatient = false;
  this.isDoctor = false;

  if (token) {
    this.isLoggedIn = true;

    try {
      const payload = JSON.parse(atob(token.split('.')[1]));
      const role = payload["http://schemas.microsoft.com/ws/2008/06/identity/claims/role"];

      this.isPatient = role === 'Patient';
      this.isDoctor = role === 'Doctor';
    } catch (e) {
      console.error('Invalid token');
    }
    }
  }

}