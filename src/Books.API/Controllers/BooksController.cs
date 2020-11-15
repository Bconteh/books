using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Books.Core.DTO;
using Books.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace Books.API.Controllers
{
    [Route("api/authors/{author}/books")]
    public class BooksController : Controller
    {
        private readonly IBookService _bookService;

        public BooksController(IBookService itemService)
        {
            _bookService = itemService;
        }

        [HttpGet("")]
        public async Task<IActionResult> Get(string author)
        {
            var books = await _bookService.GetBooksOfAuthorAsync(author);

            return Json(books);
        }

        [HttpGet("{title}")]
        public async Task<IActionResult> Get(string author, string title)
        {
            var book = await _bookService.GetBookAsync(author, title);
            if (book == null)
            {
                return NotFound();
            }

            return Json(book);
        }

        [HttpPost("")]
        public async Task<IActionResult> Post(string author, [FromBody] BookDTO book)
        {
            await _bookService.AddBookAsync(author, book.Title, book.PublishYear, book.ISBN, book.Rating, book.Category);

            return Created($"api/authors/{author}/books/{book.Title}", null);
        }

        [HttpDelete("{title}")]
        public async Task<IActionResult> Delete(string author, string title)
        {
            await _bookService.RemoveBookAsync(author, title);

            return NoContent();
        }
    }
}