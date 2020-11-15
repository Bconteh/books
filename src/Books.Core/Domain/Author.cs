using Books.Core.Common;
using Books.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Books.Core.Domain
{
    public class Author : Entity //Aggregate root
    {
        private ISet<Book> _books = new HashSet<Book>();
        public string Name { get; protected set; }
        public string Surname { get; protected set; }
        public IEnumerable<Book> Books { get => _books; protected set => _books = new HashSet<Book>(value); }
        public DateTime ActiveYear { get; protected set; }

        protected Author()
        {

        }

        public Author(Guid id, string name, string surname, IList<BookDTO> books, DateTime activeYear)
        {
            // validate the values here

            Id = id;
            Name = name;
            Surname = surname;
            books.Each(book =>_books.Add(new Book(Guid.NewGuid(), book.Title, book.PublishYear, book.ISBN, book.Rating, book.Category)));
            ActiveYear = activeYear;
        }

        public Book GetBookOrFail(string isbn)
        {
            var fixedtitle = isbn.ToLowerInvariant();
            var book = Books.SingleOrDefault(x => x.Title == fixedtitle);
            if(book == null)
            {
                throw new Exception($"No result found for the book with Title : '{fixedtitle}'");
            }
            return book;
        }

        public void AddBook(string title, DateTime publishYear, string isbn, string rating, IList<string> category)
        {
            var fixedIsbn = isbn.ToLowerInvariant();
            if (Books.Any(x => x.ISBN == fixedIsbn))
            {
                throw new Exception($"The book with ISBN {fixedIsbn} exist with the title '{title}' for the author");
            }
            _books.Add(new Book(Id, title, publishYear, fixedIsbn, rating, category));
        }

        public void RemoveBook(string isbn)
        {
            var fixedIsbn = isbn.ToLowerInvariant();
            var book = GetBookOrFail(fixedIsbn);
            _books.Remove(book);
        }
    }
}
