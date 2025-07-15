import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';

export interface StudentFeedback{

  studentName: string;
  courseName: string;
  rating: number;
  comments: string;
}

@Component({
  selector: 'app-student-feedback',
  standalone:true,
  imports: [FormsModule,CommonModule],
  templateUrl: './student-feedback.html',
  styleUrls: ['./student-feedback.css']
})
export class StudentFeedbackComponent {

  courses = ['Mathematics','Science','History','English','Art'];

  feedback: StudentFeedback = {
    studentName:'',
    courseName:this.courses[0],
    rating:3,
    comments:''
  };

}
