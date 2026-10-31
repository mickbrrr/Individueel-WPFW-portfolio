using System.ComponentModel.DataAnnotations;

namespace PortfolioApi.DTOs;

public class ProjectCreateDto
{
    [Required]
    public string Titel { get; set; } = string.Empty;

    [Required]
    public string Beschrijving { get; set; } = string.Empty;

    [Required]
    public string Categorie { get; set; } = string.Empty;

    [Required]
    public string GitHubUrl { get; set; } = string.Empty;

    public DateTime Datum { get; set; }
}