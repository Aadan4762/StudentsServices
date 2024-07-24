using Microsoft.AspNetCore.Mvc;
using StudentsServices.Data;
using StudentsServices.Dtos;
using StudentsServices.Models.Entities;

namespace StudentsServices.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StudentController : Controller
{
    private readonly ApplicationDbContext dbContext;

    public StudentController(ApplicationDbContext dbContext)
    {
        this.dbContext = dbContext;
    }
  
    [HttpGet]
    public IActionResult GetAllStudents()
    {
        var allStudents = dbContext.Students.ToList();
        return Ok(allStudents);
    }

    [HttpGet]
    [Route("{id:guid}")]
    public IActionResult GetStudentById(Guid id)
    {
        var student = dbContext.Students.Find(id);
        if (student == null)
        {
            return NotFound();
        }
        return Ok(student);
    }

    [HttpPost]
    public IActionResult AddStudent(AddStudentDto addStudentDto)
    {
        var studentEntity = new Student()
        {
            firstName = addStudentDto.firstName,
            lastName = addStudentDto.lastName,
            email = addStudentDto.email,
            phone = addStudentDto.phone,
            fees = addStudentDto.fees
        };
        dbContext.Students.Add(studentEntity);
        dbContext.SaveChanges();
        return Ok(studentEntity);
    }
    

    [HttpPut]
    [Route("{id:guid}")]
    public IActionResult UpdateStudent(Guid id, UpdateStudentDto updateStudentDto)
    {
        var student = dbContext.Students.Find(id);

        if (student == null)
        {
            return NotFound();
        }
        student.firstName = updateStudentDto.firstName;
        student.lastName = updateStudentDto.lastName;
        student.email = updateStudentDto.email;
        student.phone = updateStudentDto.phone;
        student.fees = updateStudentDto.fees;

        dbContext.SaveChanges();
        return Ok(student);
    }

    
    [HttpDelete]
    [Route("{id:guid}")]
    public IActionResult DeleteStudentById(Guid id)
    {
        var student = dbContext.Students.Find(id);
        if (student == null)
        {
            return NotFound();
        }
        dbContext.Students.Remove(student);
        dbContext.SaveChanges();
        return Ok();
        {
            
        }
    }
    
}