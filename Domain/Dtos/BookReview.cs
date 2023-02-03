namespace Domain.Dtos;

public class BookReviewDto
{
    public int Id { get; set; }
    public string Title { get; set; }
    public List<ReviewDto> Reviews { get; set; }
}

public class ReviewDto
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Comment { get; set; }
    public int Rating { get; set; }
    public int UserId { get; set; }
    public string UserFullName { get; set; }

    public ReviewDto(int id, string title, string comment, int rating, int userId, string userFullName)
    {
        Id = id;
        Title = title;
        Comment = comment;
        Rating = rating;
        UserId = userId;
        UserFullName = userFullName;
    }
}