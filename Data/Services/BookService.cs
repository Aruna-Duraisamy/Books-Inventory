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
            //var book = _mapper.Map<Book>(bookDto);
            var book = new Book()
            {
                Title = bookDto.Title,
                Description = bookDto.Description,
                Author = bookDto.Author,
                Genre = bookDto.Genre,
                IsRead = bookDto.IsRead,
                Rate = bookDto.IsRead ? bookDto.Rate : null,
                CoverUrl = bookDto.CoverUrl,
                DateRead = bookDto.IsRead ? bookDto.DateRead : null,
                DateAdded = DateTime.Now
            };
            _context.Add(book);
            _context.SaveChanges();
        }
    }
}