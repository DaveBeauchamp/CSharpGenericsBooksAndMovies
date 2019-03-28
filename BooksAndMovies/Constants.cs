using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace BooksAndMovies
{
    public static class Constants
    {
        public enum MediaEnum { Book, Movie };

        public const string Book = "books";
        public const string Movie = "movies";
        public const string BookId = "bookId";
        public const string MovieId = "movieId";

        public const string CONNECTION_STRING = "Data Source=C:\\GitRepos\\C#\\CSharpGenericsBooksAndMovies\\BooksAndMovies\\App_Data\\BooksAndMovies.db";


        // just a lazy way to get the connection string
        // not meant to be used in the app! just lazy
        // comment out once done
        public static string ConnectionStringBuilder()
        {
            var appDataFolder = HttpContext.Current.Server.MapPath("~/App_Data");
            var dbFileName = "BooksAndMovies.db";
            var createFullPath = Path.Combine(appDataFolder, dbFileName);
            var connectionString = $"Data Source={createFullPath}";

            return connectionString;
        }

    }

}