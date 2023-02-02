using AutoMapper;
using Domain.Dtos;
using Domain.Entities;
using Domain.Wrapper;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class BookService
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;

    public BookService(DataContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    
    //get all books with authors
    public async Task<Response<List<BookDto>>> GetAllBooksAsync()
    {
        var list = (
            from b in _context.Books
            join ba in _context.AuthorBooks on b.Id equals ba.BookId 
            join a in _context.Authors on ba.AuthorId equals a.Id
            join p in _context.Publishers on b.PublisherId equals p.Id
            select new BookDto()
            {
                Id = b.Id,
                Isbn = b.Isbn,
                Title = b.Title,
                Publisher = p.Name,
                AuthorFullName = string.Concat(a.Firstname, " ", a.Lastname),
            }).ToList();
        return new Response<List<BookDto>>(list);
    }

    public async Task<Response<List<PublisherDto>>> GetPublishers()
    {
       var list  = await (
                from b in _context.Books
                join  p  in _context.Publishers on b.PublisherId equals p.Id
                group b by new {p.Id, p.Name} into g
                select new PublisherDto()
            {
                Id = g.Key.Id,
                Name = g.Key.Name,
                Books = _mapper.Map<List<BookDto>>(g.ToList())
            }).ToListAsync();
       return new Response<List<PublisherDto>>(list);
    }

    public async Task<Response<List<AuthorDto>>> GetAuthors()
    {
        var list = await (from a in _context.Authors
                join ba in _context.AuthorBooks on a.Id equals ba.AuthorId
                join b in _context.Books on ba.BookId equals b.Id
                group b by new { a.Id, FullName = string.Concat(a.Firstname, " ", a.Lastname) }
                into gr
                select new AuthorDto()
                {
                    Id = gr.Key.Id,
                    Fullname = gr.Key.FullName,
                    Books = _mapper.Map<List<BookDto>>(gr.ToList()),
                    Count = gr.Count()
                }
            ).ToListAsync();

        return new Response<List<AuthorDto>>(list);
    }

    public async Task<Response<List<BookReviewDto>>> GetReviews()
    {
        var list = await (from b in _context.Books
            join r in _context.Reviews on b.Id equals r.BookId
            group r by new { b.Id, b.Title }
            into g
            select new BookReviewDto()
            {
                Id = g.Key.Id,
                Title = g.Key.Title,
                Reviews = (from r in g 
                        join u in _context.Users on r.UserId equals u.Id
                        select new ReviewDto()
                        {
                            Comment = r.Comment,
                            Id = r.Id,
                            Rating = r.Rating,
                            UserFullName = string.Concat(u.FirstName,' ',u.LastName)
                        }).ToList()
                    
            }).ToListAsync();
        return new Response<List<BookReviewDto>>(list);
    }
}