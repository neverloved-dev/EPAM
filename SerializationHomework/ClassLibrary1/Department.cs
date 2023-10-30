using System.Runtime.Serialization;

namespace ClassLibrary1;

[Serializable]
public class Department : ICloneable
{
    public string DepartmentName { get; set; }
    public List<Employee> Employees { get; set; }

    public Department()
    {
        Employees = new List<Employee>();
    }
    public object Clone()
    {
        Department cloned = new Department
        {
            DepartmentName = this.DepartmentName,
            Employees = new List<Employee>()
        };

        foreach (var employee in this.Employees)
        {
            cloned.Employees.Add((Employee)employee.Clone());
        }

        return cloned;
    }

    public static Department DeepCopy(Department department)
    {
        return (Department)department.Clone();
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