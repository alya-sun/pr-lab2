using Microsoft.AspNetCore.Mvc;

namespace pr_lab2_students.Controllers;
[ApiController]
[Route("api/service/courses")]

public class CoursesServiceController(IHttpClientFactory httpClientFactory) : ControllerBase
{
    private readonly HttpClient _httpClient = httpClientFactory.CreateClient("CoursesApi");

    [HttpGet("")]
    public async Task<IActionResult> GetCourses()
    {
        var response = await _httpClient.GetAsync("courses");
        response.EnsureSuccessStatusCode();
        var courses = await response.Content.ReadAsStringAsync();
        return Content(courses, "application/json");
    }

    [HttpPost("")]
    public async Task<IActionResult> AddCourse([FromBody] Course newCourse)
    {
        var response = await _httpClient.PostAsJsonAsync("courses", newCourse);
        response.EnsureSuccessStatusCode();
        var createdCourse = await response.Content.ReadAsStringAsync();
        return Content(createdCourse, "application/json");
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdateCourse(int id, [FromBody] Course updatedCourse)
    {
        var response = await _httpClient.PutAsJsonAsync($"courses/{id}", updatedCourse);
        return Ok(response);
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteCourse(int id)
    {
        var response = await _httpClient.DeleteAsync($"courses/{id}");
        return Ok(response);
    }
}