using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Books_Inventory.Data.Models
{
    public class AuthorDto
    {
        public string FullName { get; set; }
    }

    public class AuthorBooksDto
    {
        public string FullName { get; set; }
        public List<string> BooksName { get; set; }
    }
}