namespace Domain.Dtos;

public class BookDetailDto
{
    public int Id { get; set; }
    public string Title { get; set; }
    public DateTime PublishDate { get; set; }
    public int PageCount { get; set; }
    public int ReviewCount { get; set; }
    public int AuthorCount { get; set; }
    public string PublisherName { get; set; }
    public string SubjectName { get; set; }
}