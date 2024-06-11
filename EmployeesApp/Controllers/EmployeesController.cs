using EmployeesApp.Data;
using Microsoft.AspNetCore.Mvc;
using EmployeesApp.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeesApp.Controllers;
public class EmployeesController(DataContext context) : Controller
{
    public IActionResult Index()
    {
        var res = context.Employees
            .Include(e => e.Department)
            .Include(e => e.WorkExperiences)
            .ThenInclude(we => we.ProgrammingLanguage)
            .Where(x=>!x.IsRemove)
            .ToList();

        return View(res);
    }
    
    [HttpGet("add")]
    public IActionResult AddEmployee()
    {
        var programmingLangs = context.ProgrammingLangs.ToList();
        var departments = context.Departments.ToList();
        
        return View( new List<object>{departments,programmingLangs});
    }
    
    [HttpPost("add")]
    [ValidateAntiForgeryToken]
    public IActionResult AddEmployee(EmployeeCreate employeeCreate)
    {
        var employee = new Employee
        {
            FirstName = employeeCreate.FirstName,
            LastName = employeeCreate.LastName,
            Gender = employeeCreate.Gender,
            Age = employeeCreate.Age,
            Department = context.Departments.First(x => x.ID == employeeCreate.DepartmentID),
        };

        context.Add(employee);
        
       context.SaveChanges();

       context.WorkExperiences.Add(new EmployeeWorkExperience
       {
           Employee = employee,
           ProgrammingLanguage = context.ProgrammingLangs.First(x => x.ID == employeeCreate.ProgrammingLangID)
       });
       
       context.SaveChanges();
       
        return Redirect("/");
    }
    
    [HttpGet("edit")]
    public IActionResult UpdateEmployee(int id)
    {
      var employee =  context.Employees
            .Include(e => e.Department)
            .Include(e => e.WorkExperiences)
            .ThenInclude(we => we.ProgrammingLanguage)
            .First(x=>x.ID == id);
        var programmingLangs = context.ProgrammingLangs.ToList();
        var departments = context.Departments.ToList();
        
        return View( new List<object>{departments,programmingLangs,employee});
    }
    
    [HttpPost("edit")]
    [ValidateAntiForgeryToken]
    public IActionResult UpdateEmployee(EmployeeUpdate employeeUpdate)
    {
        var employee = context.Employees.First(x => x.ID == employeeUpdate.ID);

        employee.FirstName = employeeUpdate.FirstName;
        employee.LastName = employeeUpdate.LastName;
        employee.Gender = employeeUpdate.Gender;
        employee.Age = employeeUpdate.Age;
        employee.Department = context.Departments.First(x => x.ID == employeeUpdate.DepartmentID);

        context.Update(employee);
        
        context.SaveChanges();

        var experience = context.WorkExperiences.First(x => x.Employee.ID == employeeUpdate.ID);

        context.WorkExperiences.Update(experience);
       
        context.SaveChanges();
       
        return Redirect("/");
    }
    
    [HttpGet("remove")]
    public IActionResult RemoveEmployee(int id)
    {
        var employee = context.Employees.First(x => x.ID == id);
        employee.IsRemove = true;
        context.Employees.Update(employee);
        context.SaveChanges();

        return Redirect("/");
    }

}
