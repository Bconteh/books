using System;
using System.Collections.Generic;
using System.Text;

namespace Books.Core.DTO
{
    public class AuthorDTO
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public IList<BookDTO> Books { get; set; }
        public DateTime ActiveYear { get; set; }
    }
}
