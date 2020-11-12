using System;
using System.Collections.Generic;
using System.Text;

namespace Books.Core.DTO
{
    public class BookDTO
    {
        public string Title { get; set; }
        public DateTime PublishYear { get; set; }
        public string ISBN { get; set; }
        public string Rating { get; set; }
        public IList<string> Category { get; set; }
    }
}
