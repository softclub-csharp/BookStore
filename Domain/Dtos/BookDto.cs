namespace Domain.Dtos;

public class BookDto
{
    public int Id { get; set; }
    public string Title { get; set; }
    public DateTime PublishDate { get; set; }
    public decimal Price { get; set; }
    public int PageCount { get; set; }
    public string Isbn { get; set; }
    public string Summary { get; set; }
    public string Notes { get; set; }
    public int PublisherId { get; set; }
    public string Publisher { get; set; }
    public int SubjectId { get; set; }
    public string Subject { get; set; }
    public List<string> Authors { get; set; }
    
}