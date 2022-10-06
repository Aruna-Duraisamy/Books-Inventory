using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Books_Inventory.Data.Models;

namespace Books_Inventory.Data.Services
{
    public class PublisherService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public PublisherService(AppDbContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public void AddPublisher(PublisherDto publisherDto)
        {
            var publisher = _mapper.Map<Publisher>(publisherDto);
            _context.Publishers.Add(publisher);
            _context.SaveChanges();
        }

        public PublisherBooksWithAuthorsDto GetPublisherBooksWithAuthors(int publisherId)
        {
            var publisherBooks = _context.Publishers
            .Where(n => n.Id == publisherId)
            .Select(
                b => new PublisherBooksWithAuthorsDto()
                {
                    Name = b.Name,
                    BookAndAuthors = b.Books.Select(c => new BookAuthorsDto()
                    {
                        BookTitle = c.Title,
                        BookAuthors = c.Authors.Select(m => m.Author.FullName).ToList()
                    }).ToList()
                }
            ).FirstOrDefault();
            return publisherBooks;
        }
    }
}