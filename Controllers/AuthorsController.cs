using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Books_Inventory.Data.Models;
using Books_Inventory.Data.Services;
using Microsoft.AspNetCore.Mvc;

namespace Books_Inventory.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthorsController : ControllerBase
    {
        private readonly AuthorService _authorService;
        public AuthorsController(AuthorService authorService)
        {
            _authorService = authorService;
        }

        [HttpPost("add-author")]
        public IActionResult AddAuthor([FromBody] AuthorDto authorDto)
        {
            _authorService.AddAuthor(authorDto);
            return Ok();
        }
    }
}