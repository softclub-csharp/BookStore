namespace Domain.Dtos;

public class SubjectDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public List<BookDto> Books { get; set; }

    public SubjectDto(int id, string name, string description)
    {
        Id = id;
        Name = name;
        Description = description;
    }

    public SubjectDto()
    {
        
    }
}