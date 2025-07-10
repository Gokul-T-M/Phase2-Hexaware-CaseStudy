// 1. Enum for Course Names and Course Categories
var CourseName;
(function (CourseName) {
    CourseName["Angular"] = "Angular";
    CourseName["NodeJS"] = "Node.js";
    CourseName["FullStack"] = "FullStack";
})(CourseName || (CourseName = {}));
var CourseCategory;
(function (CourseCategory) {
    CourseCategory["FrontEnd"] = "Front-End";
    CourseCategory["BackEnd"] = "Back-End";
    CourseCategory["FullStack"] = "Full-Stack";
})(CourseCategory || (CourseCategory = {}));
// 3. Class for Enrollment Logic
var Enrollment = /** @class */ (function () {
    function Enrollment(student) {
        this.student = student;
        this.courseCategory = this.getCourseCategory();
        this.enrollmentStatus = this.checkEligibility();
    }
    // Determine course category based on course name
    Enrollment.prototype.getCourseCategory = function () {
        switch (this.student.courseName) {
            case CourseName.Angular: return CourseCategory.FrontEnd;
            case CourseName.NodeJS: return CourseCategory.BackEnd;
            case CourseName.FullStack: return CourseCategory.FullStack;
        }
    };
    // Check if student is eligible for enrollment
    Enrollment.prototype.checkEligibility = function () {
        if (this.student.age < 18) {
            return "Not Eligible";
        }
        if (this.student.courseName === CourseName.Angular && !this.student.knowsHTML) {
            return "Not Eligible";
        }
        return "Eligible";
    };
    // Display enrollment summary
    Enrollment.prototype.displaySummary = function () {
        console.log("Student Name: ".concat(this.student.name));
        console.log("Age: ".concat(this.student.age));
        console.log("Course: ".concat(this.student.courseName));
        console.log("Knows HTML: ".concat(this.student.knowsHTML));
        console.log("Course Category: ".concat(this.courseCategory));
        console.log("Enrollment Status: ".concat(this.enrollmentStatus));
        console.log('------------------------');
    };
    return Enrollment;
}());
// 4. Array of Students
var students = [
    { name: "Sneha", age: 20, courseName: CourseName.Angular, knowsHTML: true },
    { name: "Karan", age: 17, courseName: CourseName.NodeJS, knowsHTML: false },
    { name: "Riya", age: 22, courseName: CourseName.Angular, knowsHTML: false },
    { name: "Aman", age: 25, courseName: CourseName.FullStack, knowsHTML: true }
];
// 5. Loop through students and display their enrollment summary
for (var _i = 0, students_1 = students; _i < students_1.length; _i++) {
    var student = students_1[_i];
    var enrollment = new Enrollment(student);
    enrollment.displaySummary();
}
