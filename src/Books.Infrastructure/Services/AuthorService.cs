using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Books.Core.Domain;
using Books.Core.DTO;
using Books.Infrastructure.Repositories;

namespace Books.Infrastructure.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly IMapper _mapper;

        public AuthorService(IAuthorRepository authorRepository, IMapper mapper)
        {
            _authorRepository = authorRepository;
            _mapper = mapper;
        }

        public async Task<AuthorDTO> GetAuthorAsync(string name)
        {
            var author = await _authorRepository.GetAuthorAsync(name);
            return _mapper.Map<AuthorDTO>(author);
        }

        public async Task<IEnumerable<string>> GetAuthorsAsync()
        => await _authorRepository.GetAuthorsAsync();
        

        public async Task AddAuthorAsync(string name, string surname, DateTime activeYear)
        {
            var author = await _authorRepository.GetAuthorAsync(name);
            if(author != null)
            {
                throw new Exception($"author with name {name} already exist");
            }
            author = new Author(Guid.NewGuid(), name, surname, activeYear);
            await _authorRepository.AddAuthorAsync(author);
        }

        public async Task RemoveAuthorAsync(string name)
        {
            await _authorRepository.RemoveAuthorAsync(name);
        }
    }
}
