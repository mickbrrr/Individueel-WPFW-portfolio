using Microsoft.EntityFrameworkCore;
using PortfolioApi.Data;
using PortfolioApi.DTOs;
using PortfolioApi.Models;

namespace PortfolioApi.Services;

public class ProjectService
{
    private readonly AppDbContext _context;


    public async Task<List<ProjectReadDto>> GetAllAsync()
{
    return await _context.Projects
        .AsNoTracking()
        .Select(project => new ProjectReadDto
        {
            Id = project.Id,
            Titel = project.Titel,
            Beschrijving = project.Beschrijving,
            Categorie = project.Categorie,
            GitHubUrl = project.GitHubUrl,
            Datum = project.Datum
        })
        .ToListAsync();
}


public async Task<ProjectReadDto?> GetByIdAsync(int id)
{
    return await _context.Projects
        .AsNoTracking()
        .Where(project => project.Id == id)
        .Select(project => new ProjectReadDto
        {
            Id = project.Id,
            Titel = project.Titel,
            Beschrijving = project.Beschrijving,
            Categorie = project.Categorie,
            GitHubUrl = project.GitHubUrl,
            Datum = project.Datum
        })
        .FirstOrDefaultAsync();
}

public async Task<ProjectReadDto> CreateAsync(ProjectCreateDto dto)
{
    var project = new Project
    {
        Titel = dto.Titel,
        Beschrijving = dto.Beschrijving,
        Categorie = dto.Categorie,
        GitHubUrl = dto.GitHubUrl,
        Datum = dto.Datum
    };

    _context.Projects.Add(project);
    await _context.SaveChangesAsync();

    return new ProjectReadDto
    {
        Id = project.Id,
        Titel = project.Titel,
        Beschrijving = project.Beschrijving,
        Categorie = project.Categorie,
        GitHubUrl = project.GitHubUrl,
        Datum = project.Datum
    };
}

public async Task<bool> UpdateAsync(int id, ProjectUpdateDto dto)
{
    var project = await _context.Projects.FindAsync(id);

    if (project == null)
    {
        return false;
    }

    project.Titel = dto.Titel;
    project.Beschrijving = dto.Beschrijving;
    project.Categorie = dto.Categorie;
    project.GitHubUrl = dto.GitHubUrl;
    project.Datum = dto.Datum;

    await _context.SaveChangesAsync();

    return true;
}


public async Task<bool> DeleteAsync(int id)
{
    var project = await _context.Projects.FindAsync(id);

    if (project == null)
    {
        return false;
    }

    _context.Projects.Remove(project);
    await _context.SaveChangesAsync();

    return true;
}


    public ProjectService(AppDbContext context)
    {


        _context = context;
    }
}



