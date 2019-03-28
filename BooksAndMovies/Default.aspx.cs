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
        protected void Page_Load(object sender, EventArgs e)
        {
            //string connstring = Constants.ConnectionStringBuilder();
            Database.CreateDatabase();

            // build the UI and make the click events and go from there. test later when you have the nuGet packages

        }
    }
}