using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeesApp.Models;

public record Employee
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ID { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public int Age { get; set; }
    public bool Gender { get; set; }
    public Department Department { get; set; }
    public ICollection<EmployeeWorkExperience> WorkExperiences { get; set; } = new List<EmployeeWorkExperience>();

    public bool IsRemove { get; set; } = false;
}
