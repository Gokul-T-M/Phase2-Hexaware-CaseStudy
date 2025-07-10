enum Department {
    HR = "HR",
    IT = "IT",
    Sales = "Sales"
}

interface Employee {
    name: string;
    age: number;
    department: Department;
    baseSalary: number;
}

class EmployeeDetails {
    private employee: Employee;
    private netSalary: number = 0;
    private category: string = "";

    constructor(employee: Employee) {
        this.employee = employee;
        this.calculateNetSalary();
        this.categorizeEmployee();
    }

    private getBonusPercent(): number {
        switch (this.employee.department) {
            case Department.HR: return 0.10;
            case Department.IT: return 0.15;
            case Department.Sales: return 0.12;
            default: return 0;
        }
    }

    private calculateNetSalary(): void {
        const bonus = this.employee.baseSalary * this.getBonusPercent();
        this.netSalary = this.employee.baseSalary + bonus;
    }

    private categorizeEmployee(): void {
        if (this.netSalary >= 80000) {
            this.category = "High Earner";
        } else if (this.netSalary >= 50000) {
            this.category = "Mid Earner";
        } else {
            this.category = "Low Earner";
        }
    }

    public displayReport(): void {
        console.log(`Employee Name: ${this.employee.name}`);
        console.log(`Age: ${this.employee.age}`);
        console.log(`Department: ${this.employee.department}`);
        console.log(`Base Salary: ₹${this.employee.baseSalary}`);
        console.log(`Net Salary (with bonus): ₹${this.netSalary}`);
        console.log(`Category: ${this.category}`);
        console.log('------------------------');
    }
}

const employees: Employee[] = [
    { name: "Ravi", age: 28, department: Department.IT, baseSalary: 60000 },
    { name: "Priya", age: 32, department: Department.HR, baseSalary: 48000 },
    { name: "Arjun", age: 26, department: Department.Sales, baseSalary: 85000 }
];

for (const emp of employees) {
    const empDetails = new EmployeeDetails(emp);
    empDetails.displayReport();
}
