using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using ClassLibrary1;

namespace BinarySerialization
{
    

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
            try
            {
                Stream stream = new FileStream("Department.bin", FileMode.Create, FileAccess.Write);
                formatter.Serialize(stream, department);
                stream.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception happened: " + e);
                throw;
            }

            //Deserialization
            try
            {
                
                Stream readStream = new FileStream("Department.bin",FileMode.Open, FileAccess.Read,FileShare.Read);
                Department department2 = (Department)formatter.Deserialize(readStream);
                readStream.Close();
                Console.WriteLine(department2.DepartmentName);
                foreach(var employees in department2.Employees)
                {
                    Console.WriteLine(employees.EmployeeName);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

    }
}