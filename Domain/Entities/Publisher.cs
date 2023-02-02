using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class Publisher   
{
    public int Id { get; set; }
    [Required,MaxLength(100)]
    public string Name { get; set; }
    [Required,MaxLength(100)]
    public string Logo { get; set; }
    [Required,MaxLength(100)]
    public string Website { get; set; }

    public Publisher(int id, string name, string logo, string website)
    {
        Id = id;
        Name = name;
        Logo = logo;
        Website = website;
    }
    public List<Book> Books { get; set; }
}