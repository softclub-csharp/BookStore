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
}