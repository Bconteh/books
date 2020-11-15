using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Books.Core.DTO;
using Books.Infrastructure.Common;
using Books.Infrastructure.Repositories;
using Newtonsoft.Json;

namespace Books.Infrastructure.Services
{
    public class BookService : IBookService
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly IMapper _mapper;

        public BookService(IAuthorRepository authorRepository, IMapper mapper)
        {
            _authorRepository = authorRepository;
            _mapper = mapper;
        }
        public async Task AddBookAsync(string name, string title, DateTime publishYear, string isbn, string rating, IList<string> category)
        {
            var author = await _authorRepository.GetAuthorOrFailAsync(name);
            author.AddBook(title, publishYear, isbn, rating, category); // convert rating to enum
            await _authorRepository.UpdateAuthorAsync(author);
        }

        public async Task<BookDTO> GetBookAsync(string authorName, string title)
        {
            var author = await _authorRepository.GetAuthorOrFailAsync(authorName);
            var book = author.GetBookOrFail(title);

            return _mapper.Map<BookDTO>(book);
        }

        public async Task<IEnumerable<string>> GetBooksOfAuthorAsync(string name)
        {
            var author = await _authorRepository.GetAuthorOrFailAsync(name);

            return author.Books.Select(x => x.Title);
        }

        public async Task RemoveBookAsync(string author, string title) // should not work, as not implemented in imMemoryRepo
        {
            var foundAuthor = await _authorRepository.GetAuthorOrFailAsync(author);
            foundAuthor.RemoveBook(title);
            await _authorRepository.UpdateAuthorAsync(foundAuthor);
        }
    }
}
