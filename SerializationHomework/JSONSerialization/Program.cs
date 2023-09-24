using System.Text.Json;

namespace JSONSerialization
{
    class Employee
    {
        public string EmployeeName { get; set; }
        public Employee() { }
    }

    class Department
    {
        public string DepartmentName { get; set; }
        public List<Employee> Employees { get; set; }
        public Department() 
        {
            Employees = new List<Employee>();
        }
    }

    public class Program
    {
        public static void Main()
        {

            // Serialization
            Employee employee = new Employee();
            Employee employee2 = new Employee();
            Employee employee3 = new Employee();
            employee.EmployeeName = "First json";
            employee2.EmployeeName = "Second json";
            employee3.EmployeeName = "Third json";
            Department department = new Department();
            department.DepartmentName = "JSON department";
            department.Employees.Add(employee);
            department.Employees.Add(employee2);
            department.Employees.Add(employee3);

            string fileName = "department.json";
            using FileStream fileStream = File.Create(fileName);
            JsonSerializer.Serialize(fileStream, department);
            fileStream.Close();

            //Deserialization

            string[] lines = File.ReadAllLines(fileName);
            Department departmentDeserialized = JsonSerializer.Deserialize<Department>(lines[0]);
            Console.WriteLine("Deserialized object");
            Console.WriteLine(departmentDeserialized.DepartmentName);
            foreach(Employee employeeDeserialized in  departmentDeserialized.Employees)
            {
                Console.WriteLine($"{employeeDeserialized.EmployeeName}");
            }


        }

    }
}