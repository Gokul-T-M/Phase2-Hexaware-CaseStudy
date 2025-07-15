import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SlicePipe } from '@angular/common';

export interface Course {
  id: number;
  title: string;
  instructor: string;
  startDate: Date;
  price: number;
  description: string;
}


@Component({
  selector: 'app-course-list',
  imports: [CommonModule, SlicePipe],
  templateUrl: './course-list.html',
  styleUrl: './course-list.css'
})
export class CourseList {

  courses: Course[] = [
  {
    id: 1,
    title: 'Angular Fundamentals',
    instructor: 'Alice Johnson',
    startDate: new Date(2025, 6, 20), // July 20, 2025
    price: 199.99,
    description: 'Learn the basics of Angular including components, directives, services, and routing.'
  },
  {
    id: 2,
    title: 'TypeScript Mastery',
    instructor: 'Bob Smith',
    startDate: new Date(2025, 7, 5), // August 5, 2025
    price: 149.5,
    description: 'A comprehensive course on TypeScript for modern web development.'
  }
  // Add more courses as needed
];


}
