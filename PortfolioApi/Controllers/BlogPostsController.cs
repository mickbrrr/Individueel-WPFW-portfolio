using Microsoft.AspNetCore.Mvc;
using PortfolioApi.Services;
using PortfolioApi.DTOs;

namespace PortfolioApi.Controllers;

[ApiController]
[Route("api/blogposts")]
public class BlogPostsController : ControllerBase
{
    private readonly BlogPostService _service;

    public BlogPostsController(BlogPostService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetBlogPosts()
    {
        var blogPosts = await _service.GetAllAsync();
        return Ok(blogPosts);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetBlogPostById(int id)
    {
        var blogPost = await _service.GetByIdAsync(id);

        if (blogPost == null)
        {
            return NotFound();
        }

        return Ok(blogPost);
    }


    [HttpPost]
public async Task<IActionResult> CreateBlogPost(
    [FromBody] BlogPostCreateDto dto)
{
    var blogPost = await _service.CreateAsync(dto);

    return CreatedAtAction(
        nameof(GetBlogPostById),
        new { id = blogPost.Id },
        blogPost);
}



[HttpPut("{id:int}")]
public async Task<IActionResult> UpdateBlogPost(
    int id, [FromBody] BlogPostUpdateDto dto)
{
    var updated = await _service.UpdateAsync(id, dto);

    if (!updated)
    {
        return NotFound();
    }

    return NoContent();
}


[HttpDelete("{id:int}")]
public async Task<IActionResult> DeleteBlogPost(int id)
{
    var deleted = await _service.DeleteAsync(id);

    if (!deleted)
    {
        return NotFound();
    }

    return NoContent();
}


}