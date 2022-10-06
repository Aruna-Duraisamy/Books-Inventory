using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Books_Inventory.Data.Models
{
    public class PublisherDto
    {
        public string Name { get; set; }
    }

    public class PublisherBooksWithAuthorsDto
    {
        public string Name { get; set; }
        public List<BookAuthorsDto> BookAndAuthors { get; set; }
    }
    public class BookAuthorsDto
    {
        public string BookTitle { get; set; }
        public List<string> BookAuthors { get; set; }
    }
}