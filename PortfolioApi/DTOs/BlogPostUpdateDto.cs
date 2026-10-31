using System.ComponentModel.DataAnnotations;

namespace PortfolioApi.DTOs;

public class BlogPostUpdateDto
{
    [Required]
    public string Titel { get; set; } = string.Empty;

    [Required]
    public string Inhoud { get; set; } = string.Empty;

    public DateTime Publicatiedatum { get; set; }
}