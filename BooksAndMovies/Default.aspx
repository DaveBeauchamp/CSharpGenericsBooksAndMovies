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
            <div style="float: left; width: 100%;">
                <h1>Book and Movies basic generics example</h1>
                <br />
                <div class="row">
                    <div class="col-sm-3">
                        <asp:Label runat="server">Book Grid:</asp:Label>
                        <asp:GridView runat="server" ID="gvBooks"></asp:GridView>
                    </div>
                    <div class="col-sm-3">
                        <asp:Label runat="server">Movie Grid:</asp:Label>
                        <asp:GridView runat="server" ID="gvMovies"></asp:GridView>
                    </div>
                </div>
                <div class="row">
                    <div class="col-sm-8">
                        <h4>Add Books and Movies</h4>
                        <asp:Label runat="server">Book or Movie:</asp:Label>
                        <br />
                        <asp:RadioButton runat="server" GroupName="rdgBookOrMovie" ID="rdoBook" Text="Book" OnCheckedChanged="rdoBook_CheckedChanged" AutoPostBack="true"/>&nbsp
                        <asp:RadioButton runat="server" GroupName="rdgBookOrMovie" ID="rdoMovie" Text="Movie" OnCheckedChanged="rdoMovie_CheckedChanged" AutoPostBack="true"/>
                        <br />
                        <asp:Label runat="server">Table Id</asp:Label>
                        <asp:TextBox runat="server" ID="txtTableId" Text="0" />
                        <asp:Label runat="server">Title</asp:Label>
                        <asp:TextBox runat="server" ID="txtTitle" />
                        <asp:Label runat="server">Genre</asp:Label>
                        <asp:TextBox runat="server" ID="txtGenre" />
                        <asp:Label runat="server" ID="lblPages">Total Pages</asp:Label>
                        <asp:Label runat="server" ID="lblRunTime" Visible="false">Run Time</asp:Label>
                        <asp:TextBox runat="server" ID="txtLengthOfMedia" />
                    </div>
                </div>
                <br />
                <div class="row">
                    <div style="margin-left: 10px">
                        <h4>Add/Edit Buttons</h4>
                        <asp:Button runat="server" ID="btnNewMedia" Text ="New" Width="80px" OnClick="btnNewMedia_Click" />
                        <asp:Button runat="server" ID="btnInsertMedia" Text="Insert" Width="80px" OnClick="btnInsertMedia_Click" />
                        <asp:Button runat="server" ID="btnUpdateMedia" Text="Update" Width="80px" OnClick="btnUpdateMedia_Click" />
                        <asp:Button runat="server" ID="btnDeleteMedia" Text="Delete" Width="80px" OnClick="btnDeleteMedia_Click" />
                    </div>
                </div>
                <br />

            </div>
        </div>

    </form>
</body>
</html>
