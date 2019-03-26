using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BooksAndMovies
{
    public class Book
    {
        public int BookId { get; set; }
        public string BookTitle  { get; set; }
        public string BookGenre { get; set; }
        public int PageCount { get; set; }
    }
}