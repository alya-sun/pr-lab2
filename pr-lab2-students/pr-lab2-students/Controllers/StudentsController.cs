using Microsoft.AspNetCore.Mvc;

namespace pr_lab2_students.Controllers;

[ApiController]
[Route("api/students")]
public class StudentsController : ControllerBase
{
    private static List<Student> students = [];
    
    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(students);
    }

    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        var student = students.FirstOrDefault(s => s.Id == id);
        if (student == null)
        {
            return NotFound();
        }
        return Ok(student);
    }

    [HttpPost]
    public IActionResult Post([FromBody] Student student)
    {
        students.Add(student);
        return CreatedAtAction(nameof(Get), new { id = student.Id }, student);
    }

    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] Student studentUpdate)
    {
        var student = students.FirstOrDefault(s => s.Id == id);
        if (student == null)
        {
            return NotFound();
        }
        student.Name = studentUpdate.Name;
        student.Email = studentUpdate.Email;
        
        return Ok(student);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var student = students.FirstOrDefault(s => s.Id == id);
        if (student == null)
        {
            return NotFound();
        }
        students.Remove(student);
        return Ok(student);
    }
}