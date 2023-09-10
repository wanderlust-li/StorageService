namespace StorageService.Domain.Entities;

public class Pagination
{
    public int PageNumber { get; set; }
    
    public int PageSize { get; set; }
    
    public string SortBy { get; set; } = "dateCreatedAsc";
}