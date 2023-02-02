using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class Author
{
    public int Id { get; set; }
    [Required,MaxLength(100)]
    public string Firstname { get; set; }
    [Required,MaxLength(100)]
    public string Lastname { get; set; }
    [Required,MaxLength(400)]
    public string Bio { get; set; }
    [Required,MaxLength(100)]
    public string Website { get; set; }
    public List<BookAuthor> BookAuthors { get; set; }

    public Author(int id, string firstname, string lastname, string bio, string website)
    {
        Id = id;
        Firstname = firstname;
        Lastname = lastname;
        Bio = bio;
        Website = website;
    }
}