using Books.Core.Domain;
using Books.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Infrastructure.InMemory
{
    public class InMemoryAuthorRepository : IAuthorRepository
    {
        private readonly ISet<Author> _authors = new HashSet<Author>();

        public async Task<Author> GetAuthorAsync(string name)
        {
            var author = _authors.SingleOrDefault(x => x.Name.Equals(name, StringComparison.OrdinalIgnoreCase)); // what if 2 authors with same name?
            return await Task.FromResult(author);
        }

        public async Task<IEnumerable<string>> GetAuthorsAsync()
        => await Task.FromResult(_authors.Select(x => x.Name));

        public async Task AddAuthorAsync(Author author)
        {
            _authors.Add(author);
            await Task.CompletedTask;
        }

        public async Task UpdateAuthorAsync(Author author)
        {
            await Task.CompletedTask;
        }


        public async Task RemoveAuthorAsync(string name)
        {
            var author = await GetAuthorAsync(name);
            _authors.Remove(author);
        }

        
    }
}
