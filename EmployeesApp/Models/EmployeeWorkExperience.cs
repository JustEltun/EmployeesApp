using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeesApp.Models;

public record EmployeeWorkExperience
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ID { get; set; }
    public Employee Employee { get; set; }
    public ProgrammingLang ProgrammingLanguage { get; set; }
}
