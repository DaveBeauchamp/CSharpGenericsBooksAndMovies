﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BooksAndMovies
{
    public partial class Default : System.Web.UI.Page
    {
        Database db = new Database();
        Book book = new Book();
        Movie movie = new Movie();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;
            //string connstring = Constants.ConnectionStringBuilder();
            Database.CreateDatabase();

            gvBooks.DataSource = db.SelectAllFromTable(book);
            gvBooks.DataBind();
            gvMovies.DataSource = db.SelectAllFromTable(movie);
            gvMovies.DataBind();


            // build the UI and make the click events and go from there. test later when you have the nuGet packages

        }

        protected void btnFirstRecord_Click(object sender, EventArgs e)
        {
            if (RadioSelection() == 0)
            {
                // do nothing
            }
            else 
            {
                if (RadioSelection() == 1)
                    db.FirstRecord(book);
                else
                    db.FirstRecord(movie);
            }
        }

        protected void btnPreviousRecord_Click(object sender, EventArgs e)
        {
            if (RadioSelection() == 0)
            {
                // do nothing
            }
            else
            {
                if (RadioSelection() == 1)
                    db.PreviousRecord(book, txtTableId.Text);
                else
                    db.PreviousRecord(movie, txtTableId.Text);
            }
        }

        protected void btnNextRecord_Click(object sender, EventArgs e)
        {
            if (RadioSelection() == 0)
            {
                // do nothing
            }
            else
            {
                if (RadioSelection() == 1)
                    db.NextRecord(book, txtTableId.Text);
                else
                    db.NextRecord(movie, txtTableId.Text);
            }
        }

        protected void btnLastRecord_Click(object sender, EventArgs e)
        {
            if (RadioSelection() == 0)
            {
                // do nothing
            }
            else
            {
                if (RadioSelection() == 1)
                    db.LastRecord(book);
                else
                    db.LastRecord(movie);
            }
        }

        protected void btnInsertMedia_Click(object sender, EventArgs e)
        {
            int radioSelect = 0;    
            radioSelect = RadioSelection();
            if (radioSelect == 0)
            {
                // do nothing
            }
            else
            {
                if (radioSelect == 1)
                    db.InsertIntoTable(book, txtTitle.Text, txtGenre.Text, txtLengthOfMedia.Text);
                else
                    db.InsertIntoTable(movie, txtTitle.Text, txtGenre.Text, txtLengthOfMedia.Text);
            }
        }

        protected void btnUpdateMedia_Click(object sender, EventArgs e)
        {
            if (RadioSelection() == 0)
            {
                // do nothing
            }
            else
            {
                if (RadioSelection() == 1)
                    db.UpdateTable(book, txtTableId.Text, txtTitle.Text, txtGenre.Text, txtLengthOfMedia.Text);
                else
                    db.UpdateTable(movie, txtTableId.Text, txtTitle.Text, txtGenre.Text, txtLengthOfMedia.Text);
            }
        }

        protected void btnDeleteMedia_Click(object sender, EventArgs e)
        {
            if (RadioSelection() == 0)
            {
                // do nothing
            }
            else
            {
                if (RadioSelection() == 1)
                    db.DeleteFromTable(book, txtTableId.Text);
                else
                    db.DeleteFromTable(movie, txtTableId.Text);
            }
        }

        protected void btnClearFields_Click(object sender, EventArgs e)
        {
            txtTableId.Text = string.Empty;
            txtTitle.Text = string.Empty;
            txtGenre.Text = string.Empty;
            txtLengthOfMedia.Text = string.Empty;
        }

        private int RadioSelection()
        {
            int ret = 0;
            if (rdoBook.Checked)
            {
                ret = 1;
            }
            if (rdoMovie.Checked)
            {
                ret = 2;
            }

            return ret;
        }

        protected void rdoBook_CheckedChanged(object sender, EventArgs e)
        {
            lblRunTime.Visible = false;
            lblPages.Visible = true;
        }

        protected void rdoMovie_CheckedChanged(object sender, EventArgs e)
        {
            lblPages.Visible = false;
            lblRunTime.Visible = true;
        }
    }
}