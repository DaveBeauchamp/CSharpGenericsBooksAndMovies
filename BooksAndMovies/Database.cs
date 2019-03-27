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
        /// <summary>
        /// This is for connecting to the database
        /// </summary>
        /// <returns>New Connection to the database</returns>
        public static SQLiteConnection GetConnection()
        {
            var appDataFolder = HttpContext.Current.Server.MapPath("~/App_Data");
            var dbFileName = "BooksAndMovies.db";
            var createFullPath = Path.Combine(appDataFolder, dbFileName);
            var connectionString = $"Data Source={createFullPath}";
            return new SQLiteConnection(connectionString);
        }

        /// <summary>
        /// This creates the database from the database script
        /// </summary>
        public static void CreateDatabase()
        {
            var appDataFolder = HttpContext.Current.Server.MapPath("~/App_Data");
            var createScriptName = "dbseed.txt";
            var createScriptFullPath = Path.Combine(appDataFolder, createScriptName);
            var createScriptQuery = File.ReadAllText(createScriptFullPath);
            GetConnection().Execute(createScriptQuery);
        }


        // ^^ use the above ^^

        //public const string CONNECTION_STRING = "Data Source=Books.db;Version=3";

        /// <summary>
        /// Create database method, the database script handles if the table have already been made
        /// so it will not overwrite the existing database
        /// </summary>
        //public void SeedDatabase()
        //{
        //    try
        //    {
        //        string seed = File.ReadAllText("dbScript.txt");

        //        using (var db = new SQLiteConnection(CONNECTION_STRING).OpenAndReturn()) //error from not having sqlite and dapper yet
        //        {
        //            var cmd = db.Execute(seed);
        //        }
        //    }

        //    catch (Exception ex)
        //    {
        //        throw new Exception("Problem creating db " + ex);
        //    }
        //}

        // do delete
        // migth need to think about this param more
        public List<T> SelectAll<T>(string table)
        {
            using (var db = new SQLiteConnection(GetConnection()))
            {
                try
                {
                    string query = "SELECT * FROM " + table;
                    var list = db.Query<T>(query).ToList();
                    return list;
                }
                catch
                {
                    return new List<T>();
                }
            }
        }

        // might try to do this with generics, have to think (check type to select what the query will be will be simple)
        public void InsertIntoTable(string title, string genre, int? pageCount = null, string runTime = null)
        {
            using (var db = new SQLiteConnection(GetConnection()).OpenAndReturn())
            using (var trans = db.BeginTransaction())
            {
                if (pageCount != null)
                {
                    try
                    {
                        string query = "INSERT INTO books (bookTitle, bookGenre, pageCount) VALUES (@bt, @bg, @pc)";
                        var param = new { bt = title, bg = genre, pc = pageCount };
                        db.Execute(query, param, trans);
                        trans.Commit();
                    }
                    catch (Exception ex)
                    {
                        trans.Rollback();
                    }
                }
                else
                {
                    try
                    {
                        string query = "INSERT INTO movies (movieTitle, movieGenre, runTime) VALUES (@mt, @mg, @rt)";
                        var param = new { mt = title, mg = genre, rt = runTime };
                        db.Execute(query, param, trans);
                        trans.Commit();
                    }
                    catch (Exception ex)
                    {
                        trans.Rollback();
                    }
                }
            }
        }


        public void UpdateTable<T>(string id, string title, string genre, int? pageCount = null, string runTime = null)
        {
            using (var db = new SQLiteConnection(GetConnection()).OpenAndReturn())
            using (var trans = db.BeginTransaction())
            {
                if (pageCount != null)
                {
                    try
                    {
                        string query = "UPDATE books SET bookTitle = @bt, @bookGenre = @bg, pageCount = @pc WHERE bookId = @id";
                        var param = new { bt = title, bg = genre, pc = pageCount, id = id };
                        db.Execute(query, param, trans);
                        trans.Commit();
                    }
                    catch (Exception ex)
                    {
                        trans.Rollback();
                    }
                }
                else
                {
                    try
                    {
                        string query = "UPDATE movie SET movieTitle = @mt, @movieGenre = @mg, runTime = @rt WHERE movieId = @id";
                        var param = new { mt = title, mg = genre, rt = pageCount, id = id };
                        db.Execute(query, param, trans);
                        trans.Commit();
                    }
                    catch (Exception ex)
                    {
                        trans.Rollback();
                    }
                }
            }
        }


        public void DeleteFromTable<T>(string id)
        {
            using (var db = new SQLiteConnection(GetConnection()))
            {
                string tableName = "";
                string tableId = "";
                try
                {
                    string query = "DELETE FROM " + tableName + "WHERE " + tableId + " = " + id;
                }
                catch (Exception ex)
                {
                    // add something here
                }
            }
        }

        private string TypeHandler<T>(T mediaType)
        {
            string ret = "";

            // type check the generic against the type
            // use enum after type check 

            if (true)
            {
                ret = Constants.Book;
            }
            else
            {
                ret = Constants.Movie;
            }

            return ret;
        }
    }
}