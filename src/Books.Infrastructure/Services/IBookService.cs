using Books.Core.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Books.Infrastructure.Services
{
    public interface IBookService
    {
        Task<BookDTO> GetBookAsync(string authorName, string title);
        Task<IEnumerable<string>> GetBooksOfAuthorAsync(string author);
        Task AddBookAsync(string author, string title, DateTime publishYear, string isbn, string rating, IList<string> category); //should take author object
        //Task UpdateBookAsync(string author, string title, string isbn);
        Task RemoveBookAsync(string author, string title);
    }
}
