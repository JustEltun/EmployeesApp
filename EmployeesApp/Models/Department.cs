using System.ComponentModel.DataAnnotations;

namespace EmployeesApp.Models;

public record Department
{
    [Key]
    public int ID { get; set; }
    public string? Name { get; set; }
    public int Floor { get; set; }
}
