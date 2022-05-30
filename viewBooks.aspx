<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="viewBooks.aspx.cs" Inherits="LibraryManagementAssignment16451.viewBooks" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <script type="text/javascript">
            $(document).ready(function () {
                $(".table").prepend($("<thead></thead>").append($(this).find("tr:first"))).dataTable();
            });
     </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="container">
            <div class="row">
 
                <div class="col-md-12">
                    <center>
                        <h3>
                        Book Inventory List</h3>
                    </center>
                    <div class="row">
                        <div class="col-md-12 ">
                            <asp:Panel class="alert alert-success" role="alert" ID="Panel1" runat="server" Visible="False">
                                <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
                            </asp:Panel>
                        </div>
                    </div>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:booksuniversedbConnectionString %>" SelectCommand="SELECT [publisher_name], [book_cost], [book_name], [book_id], [author_name], [genre] FROM [books_tbl]"></asp:SqlDataSource>
                    <br />
                    <div class="row">
                        <div class="card">
                            <div class="card-body">
 
                                <div class="row">
                                    <div class="col-lg-12">
                                        <asp:GridView ID="GridView1" Cssclass="table" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" FooterStyle-CssClass="thead-dark" HeaderStyle-CssClass="thead-dark">
                                            <Columns>
                                                <asp:BoundField DataField="publisher_name" HeaderText="publisher_name" SortExpression="publisher_name" />
                                                <asp:BoundField DataField="book_cost" HeaderText="book_cost" SortExpression="book_cost" />
                                                <asp:BoundField DataField="book_name" HeaderText="book_name" SortExpression="book_name" />
                                                <asp:BoundField DataField="book_id" HeaderText="book_id" SortExpression="book_id" />
                                                <asp:BoundField DataField="author_name" HeaderText="author_name" SortExpression="author_name" />
                                                <asp:BoundField DataField="genre" HeaderText="genre" SortExpression="genre" />
                                            </Columns>
                                        </asp:GridView>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <center>
                    <a href="homepage.aspx">
                        << Back to Home</a><span class="clearfix"></span>
                            <br />
                            <center>
            </div>
        </div>
</asp:Content>
