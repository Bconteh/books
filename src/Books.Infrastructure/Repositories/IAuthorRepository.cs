using Books.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Books.Infrastructure.Repositories
{
    public interface IAuthorRepository
    {
        Task<Author> GetAuthorAsync(string name);
        Task<IEnumerable<string>> GetAuthorsAsync();
        Task AddAuthorAsync(Author author);
        Task UpdateAuthorAsync(Author author);
        Task RemoveAuthorAsync(string name);
    }
}
