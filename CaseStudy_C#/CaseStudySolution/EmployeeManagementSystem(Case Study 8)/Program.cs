namespace EmployeeManagementSystem_Case_Study_8_
{
    class Program
    {
        static void Main(string[] args)
        {
            Employee emp1 = new Employee { EmpCode = 101, EmpName = "Gokul", Email = "gokul@example.com", DeptName = "Dev", Location = "Chennai" };

            PartTimeEmployee pte = new PartTimeEmployee { Basic = 10000 };
            pte.CalculateSalary();
            Console.WriteLine(pte.PrintEmployeeDetails(emp1));

            FullTimeEmployee fte = new FullTimeEmployee { Basic = 20000 };
            fte.CalculateSalary();
            Console.WriteLine(fte.PrintEmployeeDetails(emp1));
        }
    }

}
