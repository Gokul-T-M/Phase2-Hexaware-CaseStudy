var Department;
(function (Department) {
    Department["HR"] = "HR";
    Department["IT"] = "IT";
    Department["Sales"] = "Sales";
})(Department || (Department = {}));
var EmployeeDetails = /** @class */ (function () {
    function EmployeeDetails(employee) {
        this.netSalary = 0;
        this.category = "";
        this.employee = employee;
        this.calculateNetSalary();
        this.categorizeEmployee();
    }
    EmployeeDetails.prototype.getBonusPercent = function () {
        switch (this.employee.department) {
            case Department.HR: return 0.10;
            case Department.IT: return 0.15;
            case Department.Sales: return 0.12;
            default: return 0;
        }
    };
    EmployeeDetails.prototype.calculateNetSalary = function () {
        var bonus = this.employee.baseSalary * this.getBonusPercent();
        this.netSalary = this.employee.baseSalary + bonus;
    };
    EmployeeDetails.prototype.categorizeEmployee = function () {
        if (this.netSalary >= 80000) {
            this.category = "High Earner";
        }
        else if (this.netSalary >= 50000) {
            this.category = "Mid Earner";
        }
        else {
            this.category = "Low Earner";
        }
    };
    EmployeeDetails.prototype.displayReport = function () {
        console.log("Employee Name: ".concat(this.employee.name));
        console.log("Age: ".concat(this.employee.age));
        console.log("Department: ".concat(this.employee.department));
        console.log("Base Salary: \u20B9".concat(this.employee.baseSalary));
        console.log("Net Salary (with bonus): \u20B9".concat(this.netSalary));
        console.log("Category: ".concat(this.category));
        console.log('------------------------');
    };
    return EmployeeDetails;
}());
var employees = [
    { name: "Ravi", age: 28, department: Department.IT, baseSalary: 60000 },
    { name: "Priya", age: 32, department: Department.HR, baseSalary: 48000 },
    { name: "Arjun", age: 26, department: Department.Sales, baseSalary: 85000 }
];
for (var _i = 0, employees_1 = employees; _i < employees_1.length; _i++) {
    var emp = employees_1[_i];
    var empDetails = new EmployeeDetails(emp);
    empDetails.displayReport();
}
