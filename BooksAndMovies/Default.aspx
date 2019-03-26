<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="BooksAndMovies.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Basic Generics</title>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.0/css/bootstrap.min.css" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.0/js/bootstrap.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container-fluid">
            <%--maybe grab bootstrap from another project to make a nicer UI--%>
            <h3>fix the row divs up to format nicer, Books one column movies the other</h3>
            <div style="float: left; width: 100%;">
                <h1>Book and Movies basic generics example</h1>
                <div class="row">
                    <div class="col-sm-4">
                        <h3>Book</h3>
                        <asp:Label runat="server">Book Title: </asp:Label>
                        <asp:TextBox runat="server" ID="txtBookTitle" />
                    </div>
                    <br />
                    <div class="col-sm-4">
                        <asp:Label runat="server">Book Genre: </asp:Label>
                        <asp:TextBox runat="server" ID="txtBookGenre" />
                    </div>
                    <br />
                    <div class="col-sm-4">
                        <asp:Label runat="server">Total Pages: </asp:Label>
                        <asp:TextBox runat="server" ID="txtPagesCount" />
                    </div>
                    <br />
                    <div class="col-sm-4">
                        <h3>Movie</h3>
                        <asp:Label runat="server">Movie Title: </asp:Label>
                        <asp:TextBox runat="server" ID="txtMovieTitle" />
                    </div>
                    <br />
                    <div class="col-sm-4">
                        <asp:Label runat="server">Movie Genre: </asp:Label>
                        <asp:TextBox runat="server" ID="txtMovieGenre" />
                    </div>
                    <br />
                    <div class="col-sm-4">
                        <asp:Label runat="server">Run Time: </asp:Label>
                        <asp:TextBox runat="server" ID="txtRunTime" />
                    </div>
                    <div class="col-sm-4">
                    </div>

                    <div class="col-sm-8">
                        <asp:Label runat="server">Book Grid:</asp:Label>
                        <asp:Label runat="server">Movie Grid:</asp:Label>
                        <asp:GridView runat="server" ID="gvBooks"></asp:GridView>
                        <asp:GridView runat="server" ID="gvMovies"></asp:GridView>
                    </div>
                    <div class="col-sm-8">
                        <h4>Add Books and Movies</h4>
                        <asp:Label runat="server">Book or Movie:</asp:Label>
                        <asp:RadioButtonList ID="rdlBookOrMovie" runat="server" RepeatDirection="Horizontal" >
                        <asp:ListItem value="book">Book &nbsp &nbsp&nbsp</asp:ListItem><asp:ListItem value="movie" >Movie</asp:ListItem>
                    </asp:RadioButtonList>

                        <asp:Label runat="server" >Title</asp:Label>
                        <asp:TextBox runat="server" ID="txtTitle" />
                        <asp:Label runat="server" >Genre</asp:Label>
                        <asp:TextBox runat="server" ID="txtGenre" />
                        <asp:Label runat="server" >Total Pages</asp:Label>
                        <asp:Label runat="server" >Run Time</asp:Label>
                        <asp:TextBox runat="server" ID="txtLengthOfMedia" />

                    </div>


                </div>
            </div>

        </div>
    </form>
</body>
</html>
