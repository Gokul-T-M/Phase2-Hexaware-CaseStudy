import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
// 1. Interface at the top
interface Student {
  name: string;
  marks: number;
  active: boolean;
}

@Component({
  selector: 'app-student-list',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './student-list.html',
  styleUrls: ['./student-list.css']
})
export class StudentList {
  students: Student[] = [
    { name: 'Amit', marks: 72, active: true },
    { name: 'Priya', marks: 48, active: false },
    { name: 'Rahul', marks: 55, active: false },
    { name: 'Sneha', marks: 30, active: true }
  ];
}
