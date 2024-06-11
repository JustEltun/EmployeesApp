namespace EmployeesApp.Models;

public record EmployeeUpdate
{
    public int ID { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public int Age { get; set; }
    public bool Gender { get; set; }
    public int DepartmentID { get; set; }
    public int ProgrammingLangID { get; set; }
}
