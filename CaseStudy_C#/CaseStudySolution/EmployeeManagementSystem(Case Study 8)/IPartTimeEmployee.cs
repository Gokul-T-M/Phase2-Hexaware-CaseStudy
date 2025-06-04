using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementSystem_Case_Study_8_
{
    public interface IPartTimeEmployee : IEmployee<Employee>
    {
        double Basic { get; set; }
        double Da { get; set; }
        double NetSalary { get; set; }

        double CalculateSalary();
    }

}
