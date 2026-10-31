using Microsoft.AspNetCore.Mvc;
using PortfolioApi.Services;
using PortfolioApi.DTOs;
namespace PortfolioApi.Controllers;

[ApiController]
[Route("api/projects")]
public class ProjectsController : ControllerBase
{
    private readonly ProjectService _service;

    public ProjectsController(ProjectService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetProjects()
    {
        var projects = await _service.GetAllAsync();
        return Ok(projects);
    }

    [HttpGet("{id:int}")]
public async Task<IActionResult> GetProjectById(int id)
{
    var project = await _service.GetByIdAsync(id);

    if (project == null)
    {
        return NotFound();
    }

    return Ok(project);
}
[HttpPost]
public async Task<IActionResult> CreateProject(
    [FromBody] ProjectCreateDto dto)
{
    var project = await _service.CreateAsync(dto);

    return CreatedAtAction(
        nameof(GetProjectById),
        new { id = project.Id },
        project);
}
[HttpPut("{id:int}")]
public async Task<IActionResult> UpdateProject(
    int id, [FromBody] ProjectUpdateDto dto)
{
    var updated = await _service.UpdateAsync(id, dto);

    if (!updated)
    {
        return NotFound();
    }

    return NoContent();
}

[HttpDelete("{id:int}")]
public async Task<IActionResult> DeleteProject(int id)
{
    var deleted = await _service.DeleteAsync(id);

    if (!deleted)
    {
        return NotFound();
    }

    return NoContent();
}


}