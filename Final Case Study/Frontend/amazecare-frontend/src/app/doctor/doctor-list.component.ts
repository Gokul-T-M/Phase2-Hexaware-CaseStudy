import { Component, OnInit } from '@angular/core';
import { DoctorService, Doctor } from '../shared/doctor.service';
import { CommonModule } from '@angular/common';
import { Router } from '@angular/router';

@Component({
  selector: 'app-doctor-list',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './doctor-list.component.html',
  styleUrl: './doctor-list.component.css'
})
export class DoctorListComponent implements OnInit {
  doctors: Doctor[] = [];

  constructor(private doctorService: DoctorService, private router: Router) {}

  ngOnInit() {
    this.doctorService.getAllDoctors().subscribe(data => {
      console.log('Doctors received:', data);
      this.doctors = data;
    });
  }

  
 onDoctorClick(doctor: Doctor) {
  const token = localStorage.getItem('token');
  if (!token) {
    localStorage.setItem('redirectDoctorId', doctor.doctorId.toString());
    alert('Please log in as a patient to book an appointment.');
    this.router.navigate(['/patient-login']);
  } else {
    this.router.navigate(['/book-appointment', doctor.doctorId]);
  }
}



  

}
