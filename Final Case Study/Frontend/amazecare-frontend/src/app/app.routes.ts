import { Routes } from '@angular/router';
import { provideRouter } from '@angular/router';

export const routes: Routes = [
  { path: '', redirectTo: 'doctors', pathMatch: 'full' },

  {
    path: 'doctors',
    loadComponent: () =>
      import('./doctor/doctor-list.component').then(m => m.DoctorListComponent)
  },
  {
    path: 'book-appointment/:doctorId',
    loadComponent: () =>
      import('./appointment/appointment-book.component').then(m => m.AppointmentBookComponent)
  },
  {
    path: 'patient-dashboard',
    loadComponent: () =>
      import('./patient/patient-dashboard.component').then(m => m.PatientDashboardComponent)
  },
  {
    path: 'patient-login',
    loadComponent: () =>
      import('./auth/patient-login.component').then(m => m.PatientLoginComponent)
  },
  {
    path: 'patient-register',
    loadComponent: () =>
      import('./auth/patient-register.component').then(m => m.PatientRegisterComponent)
  },
  {
  path: 'doctor-login',
  loadComponent: () =>
    import('./auth/doctor-login.component').then(m => m.DoctorLoginComponent)
  },
  {
  path: 'doctor-dashboard',
  loadComponent: () =>
    import('./doctor/doctor-dashboard/doctor-dashboard.component').then(m => m.DoctorDashboardComponent)
  }

];

export const appRouter = provideRouter(routes);
