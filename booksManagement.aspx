<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="booksManagement.aspx.cs" Inherits="LibraryManagementAssignment16451.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
       $(document).ready(function () {
           $(".table").prepend($("<thead></thead>").append($(this).find("tr:first"))).dataTable();
       });
 
       function readURL(input) {
           if (input.files && input.files[0]) {
               var reader = new FileReader();
 
               reader.onload = function (e) {
                   $('#imgview').attr('src', e.target.result);
               };
 
               reader.readAsDataURL(input.files[0]);
           }
       }
 
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="container-fluid">
      <div class="row justify-content-md-center">
         <div class="col-md-12">
            <div class="card">
               <div class="card-body">
                  <div class="row">
                     <div class="col">
                        <center>
                           <h4>Book Details</h4>
                        </center>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col">
                        <center>
                           <img Height="150px" Width="150px" src="imgs/books.png" />
                        </center>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col">
                        <hr>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col-md-4 align-content-center">
                        <label>Book ID</label>
                        <div class="form-group">
                           <div class="input-group">
                              <asp:TextBox CssClass="form-control" ID="TextBox1" runat="server" placeholder="Book ID"></asp:TextBox>
                              <asp:Button class="form-control btn btn-primary" ID="Button4"  runat="server" Text="Go" OnClick="Button4_Click" Width="1512px" />
                           </div>
                        </div>
                     </div>
                     <div class="col-md-4 align-content-center">
                        <label>Book Name</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="TextBox2" runat="server" placeholder="Book Name"></asp:TextBox>
                        </div>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col-md-4 align-content-center">      
                        <label>Publisher Name</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="TextBox8" runat="server" placeholder="Publisher Name"></asp:TextBox>
                          
                        </div>
                     </div>
                     <div class="col-md-4 align-content-center">
                        <label>Author Name</label>
                        <div class="form-group">
                          <asp:TextBox CssClass="form-control" ID="TextBox12" runat="server" placeholder="Author Name"></asp:TextBox>
                        </div>
                     </div>
                     <div class="col-md-4 align-content-center">
                        <label>Genre</label>
                        <div class="form-group">
                               <asp:DropDownList  CssClass="form-control" runat="server" ID="DropdownList2">
                                        <asp:ListItem Text="Select genre" Value="Business" />
                                        <asp:ListItem Text="Business" Value="Business" />
                                        <asp:ListItem Text="Health Care" Value="Health Care" /> 
                                        <asp:ListItem Text="Computing" Value="Computing" />
                           </asp:DropDownList>
                        </div>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col-md-4 align-content-center">
                        <label>Book Cost(per unit)</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="TextBox10" runat="server" placeholder="Book Cost(per unit)" TextMode="Number"></asp:TextBox>
                        </div>
                     </div>
                      <div class="col-md-4 align-content-center">
                        <label>Issued Books</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="TextBox7" runat="server" placeholder="Pages" TextMode="Number" ReadOnly="False"></asp:TextBox>
                        </div>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col-md-4 align-content-center">
                        <label>Actual Stock</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="TextBox4" runat="server" placeholder="Actual Stock" TextMode="Number"></asp:TextBox>
                        </div>
                     </div>
                     <div class="col-md-4 align-content-center">
                        <label>Current Stock</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="TextBox5" runat="server" placeholder="Book Cost(per unit)" TextMode="Number" ReadOnly="False"></asp:TextBox>
                        </div>
                     </div>
                    
                  </div>
                  <div class="row">
                     <div class="col-md-4 align-content-center">
                        <asp:Button ID="Button1" class="btn btn-lg btn-block btn-outline-info" runat="server" Text="Add" OnClick="Button1_Click" />
                     </div>
                     <div class="col-md-4 align-content-center">
                        <asp:Button ID="Button3" class="btn btn-lg btn-block btn-outline-info" runat="server" Text="Update" OnClick="Button3_Click" />
                     </div>
                     <div class="col-md-4 align-content-center">
                        <asp:Button ID="Button2" class="btn btn-lg btn-block btn-outline-info" runat="server" Text="Delete" OnClick="Button2_Click" />
                     </div>
                  </div>
               </div>
            </div>
            <a href="homepage.aspx"><< Back to Home</a><br>
            <br>
         </div>
         <div class="col-md-12">
            <div class="card">
               <div class="card-body">
                  <div class="row justify-content-md-center">
                     <div class="col">
                        <center>
                           <h4>Book Inventory List</h4>
                        </center>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col">
                        <hr>
                     </div>
                  </div>
                   <div class="row">
                     <div class="col">
                         <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:booksuniversedbConnectionString %>" SelectCommand="SELECT [publisher_name], [book_cost], [current_stock], [actual_stock], [issued_books], [book_name], [book_id], [author_name], [genre] FROM [books_tbl]"></asp:SqlDataSource>
                         <asp:GridView ID="GridView1" CssClass ="table" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" style="margin-left: 20px" Width="1293px">
                             <Columns>
                                 <asp:BoundField DataField="publisher_name" HeaderText="publisher_name" SortExpression="publisher_name" />
                                 <asp:BoundField DataField="book_cost" HeaderText="book_cost" SortExpression="book_cost" />
                                 <asp:BoundField DataField="current_stock" HeaderText="current_stock" SortExpression="current_stock" />
                                 <asp:BoundField DataField="actual_stock" HeaderText="actual_stock" SortExpression="actual_stock" />
                                 <asp:BoundField DataField="issued_books" HeaderText="issued_books" SortExpression="issued_books" />
                                 <asp:BoundField DataField="book_name" HeaderText="book_name" SortExpression="book_name" />
                                 <asp:BoundField DataField="book_id" HeaderText="book_id" SortExpression="book_id" />
                                 <asp:BoundField DataField="author_name" HeaderText="author_name" SortExpression="author_name" />
                                 <asp:BoundField DataField="genre" HeaderText="genre" SortExpression="genre" />
                             </Columns>
                             <HeaderStyle CssClass="thead-dark" />
                             <SelectedRowStyle BorderColor="Black" BorderStyle="Outset" BorderWidth="3px" />
                         </asp:GridView>
                     </div>
                 </div>
               </div>
            </div>
         </div>
      </div>
    </div>
 
</asp:Content>

