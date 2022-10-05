using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Books_Inventory.Data.Models;

namespace Books_Inventory.Data.Services
{
    public class AuthorService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public AuthorService(AppDbContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public void AddAuthor(AuthorDto authorDto)
        {
            var author = _mapper.Map<Author>(authorDto);
            _context.Authors.Add(author);
            _context.SaveChanges();
        }

        public AuthorBooksDto GetAuthorBooksById(int authorId)
        {
            var authorWithBooks = _context.Authors
            .Where(n => n.Id == authorId)
            .Select(authorBooks => new AuthorBooksDto()
            {
                FullName = authorBooks.FullName,
                BooksName = authorBooks.Books.Select(b => b.Book.Title).ToList()
            }).FirstOrDefault();
            return authorWithBooks;
        }
    }
}