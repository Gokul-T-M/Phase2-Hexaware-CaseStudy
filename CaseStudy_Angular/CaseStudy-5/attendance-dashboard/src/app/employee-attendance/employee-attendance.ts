import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';

export interface Employee{
  name:string;
  department:'IT'|'HR'|'Sales';
  isPresent:boolean;
  workFromHome:boolean;
} 

@Component({
  selector: 'app-employee-attendance',
  imports: [CommonModule],
  templateUrl: './employee-attendance.html',
  styleUrl: './employee-attendance.css'
})
export class EmployeeAttendance {

  employees: Employee[] = [
  { name: 'Alice', department: 'IT', isPresent: true, workFromHome: false },
  { name: 'Bob', department: 'HR', isPresent: false, workFromHome: true },
  { name: 'Charlie', department: 'Sales', isPresent: false, workFromHome: false }
];

}

