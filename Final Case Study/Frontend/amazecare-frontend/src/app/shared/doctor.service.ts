import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

export interface Doctor {
  doctorId: number;
  name: string;
  email: string;
  specialty: string;
  experience: number;
  qualification: string;
  designation: string;
}

@Injectable({ providedIn: 'root' })
export class DoctorService {
  private apiUrl = 'http://localhost:5176/api/v1/doctors';

  constructor(private http: HttpClient) {}

  getAllDoctors(): Observable<Doctor[]> {
    return this.http.get<Doctor[]>(this.apiUrl);
  }
}
