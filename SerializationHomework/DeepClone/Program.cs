using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text.Json;
using ClassLibrary1;

namespace CloningNamespace
{

    class Program
    {
        public static void Main()
        {
            Employee employee = new Employee();
            Employee employee2 = new Employee();
            Employee employee3 = new Employee();
            employee.EmployeeName = "First xml";
            employee2.EmployeeName = "Second xml";
            employee3.EmployeeName = "Third xml";
            Department department = new Department();
            department.DepartmentName = "XML department";
            department.Employees.Add(employee);
            department.Employees.Add(employee2);
            department.Employees.Add(employee3);

            Department cloned = Department.DeepCopy(department);
            cloned.DepartmentName = "CLONED NAME";
            cloned.Employees[0].EmployeeName = "Another employee";

            Console.WriteLine($"The original {department.DepartmentName} \t cloned {cloned.DepartmentName}");
            for (int i = 0; i < department.Employees.Count; i++)
            {
                Console.WriteLine($"{department.Employees[i].EmployeeName} \t {cloned.Employees[i].EmployeeName}");
            }
        }
    }
}
