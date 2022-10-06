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
    public class PublishersController : ControllerBase
    {
        private readonly PublisherService _publisherService;
        public PublishersController(PublisherService publisherService)
        {
            _publisherService = publisherService;
        }

        [HttpPost("add-publisher")]
        public IActionResult AddPublisher([FromBody] PublisherDto publisherDto)
        {
            _publisherService.AddPublisher(publisherDto);
            return Ok();
        }

        [HttpGet("get-publisher-book-with-authors/{publisherId}")]
        public IActionResult GetPublisherBooksWithAuthors(int publisherId)
        {
            var publisherBooks = _publisherService.GetPublisherBooksWithAuthors(publisherId);
            if (publisherBooks == null) return NotFound();
            return Ok(publisherBooks);
        }
    }
}