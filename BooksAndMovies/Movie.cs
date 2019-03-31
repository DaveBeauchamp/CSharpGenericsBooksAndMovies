using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BooksAndMovies
{
    public class Movie
    {
        public int MovieId { get; set; }
        public string MovieTitle { get; set; }
        public string MovieGenre { get; set; }
        public string RunTime { get; set; }
    }
}