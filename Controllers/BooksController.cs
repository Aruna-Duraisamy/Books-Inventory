using System.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Books_Inventory.Data.Services;
using Books_Inventory.Data.Models;

namespace Books_Inventory.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly BookService _bookService;
        public BooksController(BookService bookService)
        {
            _bookService = bookService;
        }

        [HttpPost("add-book")]
        public IActionResult AddBook([FromBody]BookDto bookDto)
        {
            _bookService.AddBook(bookDto);
            return Ok();
        }
    }
}