using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace BinarySerialization
{
    class Employee
    {
        public String EmployeeName { get; set;}
    }

    class Department
    {
        public String DepartmentName { get; set;}
        public List<Employee> Employees { get; set;}
        public Department()
        {
            Employees = new List<Employee>();
        }
    }

    public class Program
    {
        public static void main()
        {

            // Serialization
            Department department = new Department();
            department.DepartmentName = "Binary department";
            Employee employee = new Employee();
            Employee employee2 = new Employee();
            Employee employee3 = new Employee();
            employee.EmployeeName = "First binary";
            employee2.EmployeeName = "Second binary";
            employee3.EmployeeName = "Third binary";
            department.Employees.Add(employee);
            department.Employees.Add(employee2);
            department.Employees.Add(employee3);

            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream("Department.bin",FileMode.Create, FileAccess.Write);
            formatter.Serialize(stream, department);
            stream.Close();

            //Deserialization
            Stream readStream = new FileStream("Department.bin",FileMode.Open, FileAccess.Read,FileShare.Read);
            Department department2 = (Department)formatter.Deserialize(readStream);
            readStream.Close();
            Console.WriteLine(department2.DepartmentName);
            foreach(var employees in department2.Employees)
            {
                Console.WriteLine(employees.EmployeeName);
            }
        }

    }
}