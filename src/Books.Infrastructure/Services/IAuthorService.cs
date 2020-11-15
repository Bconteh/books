using Books.Core.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Books.Infrastructure.Services
{
    public interface IAuthorService
    {
        Task<AuthorDTO> GetAuthorAsync(string name);
        Task<IEnumerable<string>> GetAuthorsAsync();
        Task AddAuthorAsync(string name, string surname, IList<BookDTO> books, DateTime activeYear);
        //Task UpdateAuthorAsync(Author author);
        Task RemoveAuthorAsync(string name); //full name more accurate
    }
}
