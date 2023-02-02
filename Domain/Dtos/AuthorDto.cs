namespace Domain.Dtos;

public class AuthorDto
{
    public int Id { get; set; }
    public string Fullname { get; set; }
    
    public List<BookDto> Books { get; set; }
    public int Count { get; set; }
}