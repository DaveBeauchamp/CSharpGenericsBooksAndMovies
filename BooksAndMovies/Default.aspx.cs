using System;
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
            Response.Redirect(Request.RawUrl);
        }

        protected void btnUpdateMedia_Click(object sender, EventArgs e)
        {
            int radioSelect = 0;
            radioSelect = RadioSelection();
            if (radioSelect == 0)
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
            Response.Redirect(Request.RawUrl);
        }

        protected void btnDeleteMedia_Click(object sender, EventArgs e)
        {
            int radioSelect = 0;
            radioSelect = RadioSelection();
            if (radioSelect == 0)
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
            Response.Redirect(Request.RawUrl);
        }

        protected void btnNewMedia_Click(object sender, EventArgs e)
        {
            txtTableId.Text = "0";
            txtTitle.Text = string.Empty;
            txtGenre.Text = string.Empty;
            txtLengthOfMedia.Text = string.Empty;

            Response.Redirect(Request.RawUrl);
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