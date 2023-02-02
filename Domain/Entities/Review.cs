namespace Domain.Entities;

public class Review
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Comment { get; set; }
    public int Rating { get; set; }
    public int BookId { get; set; }
    public Book Book { get; set; }
    public int UserId { get; set; }
    public User User { get; set; }

    public Review(int id, string title, string comment, int rating, int bookId,  int userId)
    {
        Id = id;
        Title = title;
        Comment = comment;
        Rating = rating;
        BookId = bookId;
        UserId = userId;
    }
}