using System.Runtime.Serialization;
using System.Xml.Serialization;
using ClassLibrary1;

namespace XMLSerialization
{
    public class Program
    {
        public static void Main()
        {

            // Serialization
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

            XmlSerializer serializer = new XmlSerializer(typeof(Department));
            using (TextWriter writer = new StreamWriter("department.xml"))
            {
                serializer.Serialize(writer, department);
            }

            XmlSerializer deserializer = new XmlSerializer(typeof(Department));
            TextReader reader = new StreamReader("department.xml");
            object deserializedObject = deserializer.Deserialize(reader);
            department = (Department)deserializedObject;
            reader.Close();
            Console.WriteLine(department.DepartmentName);
            foreach (Employee emp in department.Employees)
            {
                Console.WriteLine(emp.EmployeeName);
            }

        }

    }
}