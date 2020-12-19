using Lab8.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lab8.Services
{
    public class EmployeeService : MongoServiceBase<Employee>
    {
        public EmployeeService()
            : base("Employees")
        {

        }
    }
}
