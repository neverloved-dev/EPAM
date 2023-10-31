namespace ClassLibrary1;

[Serializable]
public class Employee : ICloneable
{
    public  string EmployeeName { get; set; }

    public object Clone()
    {
        return new Employee { EmployeeName = this.EmployeeName };
    }
}