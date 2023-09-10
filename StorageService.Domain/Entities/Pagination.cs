namespace StorageService.Domain.Entities;

public class Pagination
{
    public int PageNumber { get; set; } = 1;

    public int PageSize { get; set; } = 10;
    
    public SortOptions SortBy { get; set; } = SortOptions.DateCreatedAsc;
}