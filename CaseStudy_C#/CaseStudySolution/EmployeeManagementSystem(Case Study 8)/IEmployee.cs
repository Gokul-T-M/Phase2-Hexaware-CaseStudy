using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementSystem_Case_Study_8_
{
    public interface IEmployee<T>
    {
        string PrintEmployeeDetails(T employee);
    }

}
