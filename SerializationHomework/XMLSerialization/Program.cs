using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace XMLSerialization
{
    public class Employee 
    {
        public string EmployeeName { get; set; }
        public Employee() { }

    }
    [Serializable]
   public class Department : ISerializable 
    {
        public string DepartmentName { get; set; }
        public List<Employee> Employees { get; set; }
        public Department() 
        {
            Employees = new List<Employee>();
        }
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("DepartmentName", DepartmentName);
            info.AddValue("EmployeeList", Employees);
        }
        public Department(SerializationInfo info, StreamingContext context)
        {
            DepartmentName = (string)info.GetValue("DepartmentName", typeof(string));
            Employees = (List<Employee>)info.GetValue("Employees", typeof(List<Employee>));
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