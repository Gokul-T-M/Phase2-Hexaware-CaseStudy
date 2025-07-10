// 1. Enum for Course Names and Course Categories
enum CourseName {
    Angular = "Angular",
    NodeJS = "Node.js",
    FullStack = "FullStack"
}

enum CourseCategory {
    FrontEnd = "Front-End",
    BackEnd = "Back-End",
    FullStack = "Full-Stack"
}

// 2. Interface for Student
interface Student {
    name: string;
    age: number;
    courseName: CourseName;
    knowsHTML: boolean;
}

// 3. Class for Enrollment Logic
class Enrollment {
    private student: Student;
    private courseCategory: CourseCategory;
    private enrollmentStatus: string;

    constructor(student: Student) {
        this.student = student;
        this.courseCategory = this.getCourseCategory();
        this.enrollmentStatus = this.checkEligibility();
    }

    // Determine course category based on course name
    private getCourseCategory(): CourseCategory {
        switch (this.student.courseName) {
            case CourseName.Angular: return CourseCategory.FrontEnd;
            case CourseName.NodeJS: return CourseCategory.BackEnd;
            case CourseName.FullStack: return CourseCategory.FullStack;
        }
    }

    // Check if student is eligible for enrollment
    private checkEligibility(): string {
        if (this.student.age < 18) {
            return "Not Eligible";
        }
        if (this.student.courseName === CourseName.Angular && !this.student.knowsHTML) {
            return "Not Eligible";
        }
        return "Eligible";
    }

    // Display enrollment summary
    public displaySummary(): void {
        console.log(`Student Name: ${this.student.name}`);
        console.log(`Age: ${this.student.age}`);
        console.log(`Course: ${this.student.courseName}`);
        console.log(`Knows HTML: ${this.student.knowsHTML}`);
        console.log(`Course Category: ${this.courseCategory}`);
        console.log(`Enrollment Status: ${this.enrollmentStatus}`);
        console.log('------------------------');
    }
}

// 4. Array of Students
const students: Student[] = [
    { name: "Sneha", age: 20, courseName: CourseName.Angular, knowsHTML: true },
    { name: "Karan", age: 17, courseName: CourseName.NodeJS, knowsHTML: false },
    { name: "Riya", age: 22, courseName: CourseName.Angular, knowsHTML: false },
    { name: "Aman", age: 25, courseName: CourseName.FullStack, knowsHTML: true }
];

// 5. Loop through students and display their enrollment summary
for (const student of students) {
    const enrollment = new Enrollment(student);
    enrollment.displaySummary();
}
