using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Books_Inventory.Data.Models;

namespace Books_Inventory.Data.Services
{
    public class BookService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public BookService(AppDbContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        //Add Book
        public void AddBook(BookDto bookDto)
        {
            var book = _mapper.Map<Book>(bookDto);
            /* var book = new Book()
            {
                Title = bookDto.Title,
                Description = bookDto.Description,
                Genre = bookDto.Genre,
                IsRead = bookDto.IsRead,
                Rate = bookDto.IsRead ? bookDto.Rate : null,
                CoverUrl = bookDto.CoverUrl,
                DateRead = bookDto.IsRead ? bookDto.DateRead : null,
                DateAdded = DateTime.Now
            }; */
            book.DateAdded = DateTime.Now;
            _context.Books.Add(book);
            _context.SaveChanges();

            foreach (var id in bookDto.AuthorIds)
            {
                var book_author = new Book_Author()
                {
                    BookId = book.Id,
                    AuthorId = id
                };
                _context.Books_Authors.Add(book_author);
                _context.SaveChanges();
            }
        }

        public List<Book> GetAllBooks() => _context.Books.ToList();

        public BookWithAuthorsDto? GetBookById(int id)
        {
            var bookWithAuthors = _context.Books
            .Where(n => n.Id == id)
            .Select
            (
                book => new BookWithAuthorsDto()
                {
                    Title = book.Title,
                    Description = book.Description,
                    Genre = book.Genre,
                    IsRead = book.IsRead,
                    Rate = book.IsRead ? book.Rate : null,
                    CoverUrl = book.CoverUrl,
                    DateRead = book.IsRead ? book.DateRead : null,
                    PublisherName = book.Publisher.Name,
                    AuthorsName = book.Authors.Select(m => m.Author.FullName).ToList()
                }
            )
            .FirstOrDefault();
            return bookWithAuthors;
        }

        public Book? UpdateBookById(int id, BookDto bookDto)
        {
            var book = _context.Books.FirstOrDefault(n => n.Id == id);
            if (book != null)
            {
                book.Title = bookDto.Title;
                book.Description = bookDto.Description;
                book.Genre = bookDto.Genre;
                book.IsRead = bookDto.IsRead;
                book.Rate = bookDto.IsRead ? bookDto.Rate : null;
                book.CoverUrl = bookDto.CoverUrl;
                book.DateRead = bookDto.IsRead ? bookDto.DateRead : null;
                _context.SaveChanges();
            }
            return book;
        }

        public void DeleteBookById(int id)
        {
            var book = _context.Books.FirstOrDefault(n => n.Id == id);
            if (book != null)
            {
                _context.Books.Remove(book);
                _context.SaveChanges();
            }
        }
    }
}