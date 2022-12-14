using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Books_Inventory.Data.Models
{
    public class BookDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Genre { get; set; }
        public bool IsRead { get; set; }
        public int? Rate { get; set; }
        public string CoverUrl { get; set; }
        public DateTime? DateRead { get; set; }
        public int PublisherId { get; set; }
        public List<int> AuthorIds { get; set; }
    }

    public class BookWithAuthorsDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Genre { get; set; }
        public bool IsRead { get; set; }
        public int? Rate { get; set; }
        public string CoverUrl { get; set; }
        public DateTime? DateRead { get; set; }
        public string PublisherName { get; set; }
        public List<string> AuthorsName { get; set; }
    }
}