using Books.Core.Domain;
using Books.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Books.Infrastructure.Common
{
    public static class AuthorHelpers
    {
       
        public static async Task<Author> GetAuthorOrFailAsync(this IAuthorRepository repository, string name)
        {
            var author = await repository.GetAuthorAsync(name);
            if (author == null)
            {
                throw new Exception($"author with name: '{name}' was not found.");
            }

            return author;
        }
    }
}
