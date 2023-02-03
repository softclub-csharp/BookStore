using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class Book
{
    public int Id { get; set; }
    [Required,MaxLength(100)]
    public string Title { get; set; }
    public DateTime PublishDate { get; set; }
    public decimal Price { get; set; }
    public int PageCount { get; set; }
    [Required,MaxLength(100)]
    public string Isbn { get; set; }
    [Required,MaxLength(200)]
    public string Summary { get; set; }
    [Required,MaxLength(100)]
    public string Notes { get; set; }
    public int PublisherId { get; set; }
    public Publisher Publisher { get; set; }
    public int SubjectId { get; set; }
    public Subject Subject { get; set; }
    public List<BookAuthor> BookAuthors { get; set; }
    public List<Review> Reviews { get; set; }

    public Book(int id, string title, DateTime publishDate, decimal price, int pageCount, string isbn, string summary, string notes, int publisherId, int subjectId)
    {
        Id = id;
        Title = title;
        PublishDate = publishDate;
        Price = price;
        PageCount = pageCount;
        Isbn = isbn;
        Summary = summary;
        Notes = notes;
        PublisherId = publisherId;
        SubjectId = subjectId;

    }
}