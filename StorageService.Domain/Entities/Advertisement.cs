using System.ComponentModel.DataAnnotations;

namespace StorageService.Domain.Entities;

public class Advertisement
{
    public int Id { get; set; }
    
    [Required]
    [MaxLength(200)]
    public string Title { get; set; }
    
    [MaxLength(1000)]
    public string Description { get; set; }
    
    [MaxLength(255)]
    public string ImageUrl { get; set; }
    
    [Required]
    public decimal Price { get; set; }
    
    public DateTime DateCreated { get; set; } = DateTime.Now; 
}