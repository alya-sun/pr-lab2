using Microsoft.AspNetCore.Mvc;

namespace pr_lab2_courses.Controllers;
[ApiController]
[Route("api/courses")]

public class CoursesController : ControllerBase
{
    private static List<Course> courses = [];

    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(courses);
    }

    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        var course = courses.FirstOrDefault(s => s.Id == id);
        if (course == null)
        {
            return NotFound();
        }
        return Ok(course);
    }

    [HttpPost]
    public IActionResult Post([FromBody] Course course)
    {
        courses.Add(course);
        return CreatedAtAction(nameof(Get), new { id = course.Id }, course);
    }

    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] Course courseUpdate)
    {
        var course = courses.FirstOrDefault(s => s.Id == id);
        if (course == null)
        {
            return NotFound();
        }
        course.Name = courseUpdate.Name;
        course.Description = courseUpdate.Description;
        
        return Ok(course);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var course = courses.FirstOrDefault(s => s.Id == id);
        courses.Remove(course);
        
        return Ok(course);
    }
}
