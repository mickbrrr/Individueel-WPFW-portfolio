using Microsoft.EntityFrameworkCore;
using PortfolioApi.Data;
using PortfolioApi.DTOs;
using PortfolioApi.Models;

namespace PortfolioApi.Services;

public class BlogPostService
{
    private readonly AppDbContext _context;

    public BlogPostService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<BlogPostReadDto>> GetAllAsync()
{
    return await _context.BlogPosts
        .AsNoTracking()
        .Select(blogPost => new BlogPostReadDto
        {
            Id = blogPost.Id,
            Titel = blogPost.Titel,
            Inhoud = blogPost.Inhoud,
            Publicatiedatum = blogPost.Publicatiedatum
        })
        .ToListAsync();
}
public async Task<BlogPostReadDto?> GetByIdAsync(int id)
{
    return await _context.BlogPosts
        .AsNoTracking()
        .Where(blogPost => blogPost.Id == id)
        .Select(blogPost => new BlogPostReadDto
        {
            Id = blogPost.Id,
            Titel = blogPost.Titel,
            Inhoud = blogPost.Inhoud,
            Publicatiedatum = blogPost.Publicatiedatum
        })
        .FirstOrDefaultAsync();
}
public async Task<BlogPostReadDto> CreateAsync(BlogPostCreateDto dto)
{
    var blogPost = new BlogPost
    {
        Titel = dto.Titel,
        Inhoud = dto.Inhoud,
        Publicatiedatum = dto.Publicatiedatum
    };

    _context.BlogPosts.Add(blogPost);
    await _context.SaveChangesAsync();

    return new BlogPostReadDto
    {
        Id = blogPost.Id,
        Titel = blogPost.Titel,
        Inhoud = blogPost.Inhoud,
        Publicatiedatum = blogPost.Publicatiedatum
    };
}
public async Task<bool> UpdateAsync(int id, BlogPostUpdateDto dto)
{
    var blogPost = await _context.BlogPosts.FindAsync(id);

    if (blogPost == null)
    {
        return false;
    }

    blogPost.Titel = dto.Titel;
    blogPost.Inhoud = dto.Inhoud;
    blogPost.Publicatiedatum = dto.Publicatiedatum;

    await _context.SaveChangesAsync();

    return true;
}
public async Task<bool> DeleteAsync(int id)
{
    var blogPost = await _context.BlogPosts.FindAsync(id);

    if (blogPost == null)
    {
        return false;
    }

    _context.BlogPosts.Remove(blogPost);
    await _context.SaveChangesAsync();

    return true;
}
}