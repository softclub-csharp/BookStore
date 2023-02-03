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
            select new BookDto()
            {
                Id = b.Id,
                Isbn = b.Isbn,
                Title = b.Title,
                Publisher = b.Publisher.Name,
                Authors = b.BookAuthors.Select(x=>string.Concat(x.Author.Firstname," ",x.Author.Lastname)).ToList()
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
                        select new ReviewDto(r.Id,r.Title,r.Comment,r.Rating,r.UserId,string.Concat(u.FirstName,' ',u.LastName)))
                    .ToList()
                    
            }).ToListAsync();
        return new Response<List<BookReviewDto>>(list);
    }
    
    // analise
    public async Task<Response<List<SubjectDto>>> GetSubjects()
    {
        // var list = await (from s in _context.Subjects
        //     join b in _context.Books on s.Id equals b.SubjectId
        //     group b by new { s.Id, s.Name, s.Description }
        //     into gr
        //     select new SubjectDto(gr.Key.Id, gr.Key.Name, gr.Key.Description)
        //     {
        //         
        //         Books = _mapper.Map<List<BookDto>>(gr.ToList())
        //     }).ToListAsync();

        var listv3 = _context.Subjects.ToListAsync();

        var Books = await _context.Subjects.SelectMany(x => x.Books).ToListAsync();
        
        var listV2 = await _context.Subjects.Select(x => new SubjectDto(x.Id, x.Name, x.Description)
        {
          Books = _mapper.Map<List<BookDto>>(x.Books)
        }).ToListAsync();

        return new Response<List<SubjectDto>>(listV2);
    }
    
    // 
    public async Task<Response<List<BookDetailDto>>> GetBookDetails()
    {
        
        var listv1 = await (from b in _context.Books
            select new BookDetailDto()
            {
                Id = b.Id,
                Title = b.Title,
                ReviewCount = (from r in _context.Reviews where r.BookId == b.Id select r).Count(),
                AuthorCount = (from ab in _context.AuthorBooks where ab.BookId == b.Id select ab).Count()
            }).ToListAsync();

        var listV2 = await _context.Books.Select(x => new BookDetailDto()
        {
            Id = x.Id,
            Title = x.Title,
             ReviewCount = x.Reviews.Count,
             AuthorCount = x.BookAuthors.Count
        }).ToListAsync();
        return new Response<List<BookDetailDto>>(listv1);
    }
    
}