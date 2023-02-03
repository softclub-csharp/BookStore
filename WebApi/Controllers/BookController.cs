using Domain.Dtos;
using Domain.Wrapper;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[Route("api/[controller]")]
public class BookController:ControllerBase
{
    private readonly BookService _bookService;

    public BookController(BookService bookService)
    {
        _bookService = bookService;
    }
    
    [HttpGet("GetAllBooks")]
    public async Task<Response<List<BookDto>>> Get()=>await _bookService.GetAllBooksAsync();
    
    [HttpGet("publishers")]
    public async Task<Response<List<PublisherDto>>> GetPublishers()=>await _bookService.GetPublishers();
    
    [HttpGet("authors")]
    public async Task<Response<List<AuthorDto>>> GetAuthors()=>await _bookService.GetAuthors();

    [HttpGet("reviews")]
    public async Task<Response<List<BookReviewDto>>> GetReviews()=>await _bookService.GetReviews();
    [HttpGet("subjects")]
    public async Task<Response<List<SubjectDto>>> GetSubjects()=>await _bookService.GetSubjects();
    
    [HttpGet("details")]
    public async Task<Response<List<BookDetailDto>>> GetBookDetails()=>await _bookService.GetBookDetails();
}