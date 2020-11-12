using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Books.Core.DTO;
using Books.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace Books.API.Controllers
{
    [Route("api/[controller]")]
    public class AuthorsController : Controller
    {
        private readonly IAuthorService _authorService;

        public AuthorsController(IAuthorService bucketService)
        {
            _authorService = bucketService;
        }

        [HttpGet("")]
        public async Task<IActionResult> Get()
        {
            var buckets = await _authorService.GetAuthorsAsync();

            return Json(buckets);
        }

        [HttpGet("{name}")]
        public async Task<IActionResult> Get(string name)
        {
            var bucket = await _authorService.GetAuthorAsync(name);
            if (bucket == null)
            {
                return NotFound();
            }

            return Json(bucket);
        }

        [HttpPost("{name}")]
        public async Task<IActionResult> Post([FromBody] AuthorDTO author) // DTO should move to infra
        {
            await _authorService.AddAuthorAsync(author.Name, author.Surname, author.ActiveYear);

            return Created($"api/authors/{author.Name}", null);
        }

        [HttpDelete("{name}")]
        public async Task<IActionResult> Delete(string name)
        {
            await _authorService.RemoveAuthorAsync(name);

            return NoContent();
        }
    }
}