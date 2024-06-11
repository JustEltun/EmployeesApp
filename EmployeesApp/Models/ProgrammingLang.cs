using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeesApp.Models;

public record ProgrammingLang
{
    [Key]
    public int ID { get; set; }
    public string? Name { get; set; }
}
