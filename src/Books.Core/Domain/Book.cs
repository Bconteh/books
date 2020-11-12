using Books.Core.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Books.Core.Domain
{
    public class Book : Entity
    {
        public Guid BookId { get; protected set; }
        public string Title { get; protected set; }
        public DateTime PublishYear { get; protected set; }
        public string ISBN { get; protected set; }
        public string Rating { get; protected set; }
        public IList<string> Category { get; protected set; }

        protected Book()
        {

        }

        public Book(Guid bookId, string title, DateTime publishYear, string isbn, string rating, IList<string> category)
        {
            // Validate the values here

            BookId = bookId;
            Title = title;
            PublishYear = publishYear;
            ISBN = isbn;
            Rating = rating;
            Category = category;
        }

    }
}
