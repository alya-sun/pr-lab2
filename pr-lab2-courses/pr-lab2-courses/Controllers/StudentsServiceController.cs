using Microsoft.AspNetCore.Mvc;

namespace pr_lab2_courses.Controllers;

[ApiController]
[Route("api/service/students")]

public class StudentsServiceController(IHttpClientFactory httpClientFactory) : ControllerBase
{
    private readonly HttpClient _httpClient = httpClientFactory.CreateClient("StudentsApi");

    [HttpGet]
    public async Task<IActionResult> GetStudents()
    {
        var response = await _httpClient.GetAsync("students");
        var students = await response.Content.ReadAsStringAsync();
        return Content(students, "application/json");
    }

    [HttpPost]
    public async Task<IActionResult> AddStudent([FromBody] Student newStudent)
    {
        var response = await _httpClient.PostAsJsonAsync("students", newStudent);
        var createdStudent = await response.Content.ReadAsStringAsync();
        return Content(createdStudent, "application/json");
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdateStudent(int id, [FromBody] Student updatedStudent)
    {
        var response = await _httpClient.PutAsJsonAsync($"students/{id}", updatedStudent);
        return Ok(response);
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteStudent(int id)
    {
        var response = await _httpClient.DeleteAsync($"students/{id}");
        return Ok(response);
    }
}