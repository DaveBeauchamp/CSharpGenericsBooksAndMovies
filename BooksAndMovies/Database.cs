using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Data.SQLite;
using Dapper;

namespace BooksAndMovies
{
    public class Database
    {
        public static SQLiteConnection GetConnection()
        {
            return new SQLiteConnection(Constants.CONNECTION_STRING);
        }

        public static void CreateDatabase()
        {
            var appDataFolder = HttpContext.Current.Server.MapPath("~/App_Data");
            var createScriptName = "dbseed.txt";
            var createScriptFullPath = Path.Combine(appDataFolder, createScriptName);
            var createScriptQuery = File.ReadAllText(createScriptFullPath);
            GetConnection().Execute(createScriptQuery);
        }

        public List<T> SelectAllFromTable<T>(T mediaType)
        {
            using (var db = new SQLiteConnection(GetConnection()))
            {
                string tableName = TypeHandler(mediaType);
                try
                {
                    string query = $"SELECT * FROM {tableName}";
                    var list = db.Query<T>(query).ToList();
                    return list;
                }
                catch
                {
                    return new List<T>();
                }
            }
        }
        
        public void InsertIntoTable<T>(T mediaType, string title, string genre, string mediaLength)
        {
            using (var db = new SQLiteConnection(GetConnection()).OpenAndReturn())
            using (var trans = db.BeginTransaction())
            {
                string media = TypeHandler(mediaType);
                string colBook = "(bookTitle, bookGenre, pageCount)";
                string colMovie = "(movieTitle, movieGenre, runTime)";
                string queryVal = "(@t, @g, @len)";
                string query = string.Empty;
                var param = new { t = title, g = genre, len = mediaLength };

                try
                {
                    if (media == Constants.Book)
                    {
                        query = $"INSERT INTO {media} {colBook} VALUES {queryVal}";
                    }
                    else
                    {
                        query = $"INSERT INTO {media} {colMovie} VALUES {queryVal}";           
                    }

                    db.Execute(query, param, trans);
                    trans.Commit();
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                }
            }
        }

        public void UpdateTable<T>(T mediaType, string id, string title, string genre, string mediaLength)
        {
            using (var db = new SQLiteConnection(GetConnection()).OpenAndReturn())
            using (var trans = db.BeginTransaction())
            {
                string media = TypeHandler(mediaType);
                string colBook = "bookTitle = @t, @bookGenre = @g, pageCount = @len WHERE bookId = @mid";
                string colMovie = "movieTitle = @t, @movieGenre = @g, runTime = @len WHERE movieId = @mid";
                string query = string.Empty;
                var param = new { t = title, g = genre, len = mediaLength, mid = id };

                try
                {
                    if (media == Constants.Book)
                    {
                        query = $"UPDATE {media} SET {colBook}";
                    }
                    else
                    {
                        query = $"UPDATE {media} SET {colMovie}";
                    }
   
                    db.Execute(query, param, trans);
                    trans.Commit();
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                }
            }
        }

        public void DeleteFromTable<T>(T mediaType, string id)
        {
            using (var db = new SQLiteConnection(GetConnection()))
            using (var trans = db.BeginTransaction())
            {
                string media = TypeHandler(mediaType);
                string bookId = Constants.BookId;
                string movieId = Constants.MovieId;
                string query = string.Empty;

                try
                {
                    if (media == Constants.Book && id != null)
                    {
                        query = $"DELETE FROM {media} WHERE {bookId} = {id}";
                    }
                    else
                    {
                        query = $"DELETE FROM {media} WHERE {movieId} = {id}";
                    }

                    db.Execute(query, null, trans);
                    trans.Commit();
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                }
            }
        }

        public T FirstRecord<T>(T mediaType)
        {
            using (var db = new SQLiteConnection(GetConnection()))
            {
                string tableName = TypeHandler(mediaType);
                string Id = string.Empty;

                if (tableName == Constants.Book)
                {
                    Id = Constants.BookId;
                }
                else
                {
                    Id = Constants.MovieId;
                }
                
                var query = $"SELECT * FROM {tableName} ORDER BY {Id} ASC LIMIT 1";
                var result = db.QuerySingle<T>(query);
                return result;
            }
        }

        public T LastRecord<T>(T mediaType)
        {
            using (var db = new SQLiteConnection(GetConnection()))
            {
                string tableName = TypeHandler(mediaType);
                string Id = string.Empty;

                if (tableName == Constants.Book)
                {
                    Id = Constants.BookId;
                }
                else
                {
                    Id = Constants.MovieId;
                }

                var query = $"SELECT * FROM {tableName} ORDER BY {Id} DESC LIMIT 1";
                var result = db.QuerySingle<T>(query);
                return result;
            }
        }

        public T NextRecord<T>(T mediaType, string tableId)
        {
            using (var db = new SQLiteConnection(GetConnection()))
            {
                string tableName = TypeHandler(mediaType);
                string recordId = tableId;

                //if (tableName == Constants.Book)
                //{
                //    Id = Constants.BookId;
                //}
                //else
                //{
                //    Id = Constants.MovieId;
                //}

                var query = $"SELECT * FROM {tableName} WHERE {recordId} > @id LIMIT 1";
                var param = new { id = recordId };
                var result = db.QuerySingle<T>(query, param);
                return result;
            }
        }

        public T PreviousRecord<T>(T mediaType, string tableId)
        {
            using (var db = new SQLiteConnection(GetConnection()))
            {
                string tableName = TypeHandler(mediaType);
                string RecordId = tableId;
                string Id = string.Empty;

                if (tableName == Constants.Book)
                {
                    Id = Constants.BookId;
                }
                else
                {
                    Id = Constants.MovieId;
                }

                var query = $"SELECT * FROM {tableName} WHERE {RecordId} < @id ORDER BY {Id} DESC LIMIT 1";
                var param = new { id = RecordId };
                var result = db.QuerySingle<T>(query, param);
                return result;
            }
        }

        private string TypeHandler<T>(T mediaType)
        {
            string ret = string.Empty;
            
            if (mediaType.GetType() == typeof(Book))
            {
                ret = Constants.Book;
            }
            if (mediaType.GetType() == typeof(Movie))
            {
                ret = Constants.Movie;
            }

            return ret;
        }
    }
}