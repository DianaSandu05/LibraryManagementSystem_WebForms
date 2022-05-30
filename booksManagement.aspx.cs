using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LibraryManagementAssignment16451
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            GridView1.DataBind();
        }
        //go button 
        protected void Button4_Click(object sender, EventArgs e)
        {
            findBook();
        }
        // add button
        protected void Button1_Click(object sender, EventArgs e)
        {

            if (bookcheck())
            {
                Response.Write("<script>alert('Author with this ID already Exist. You cannot add another Author with the same Author ID');</script>");
            }
            else
            {
                addBooks();
            }
        }
        // update button
        protected void Button3_Click(object sender, EventArgs e)
        {
            updateBook();
        }
        //delete button
        protected void Button2_Click(object sender, EventArgs e)
        {
            deleteBook();
        }
        // user defined functions
        void addBooks()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("INSERT INTO books_tbl(book_id,book_name,author_name, publisher_name, genre, book_cost, actual_stock, current_stock," +
                    " issued_books) values (@book_id,@book_name,@author_name," +
                    " @publisher_name, @genre, @book_cost, @actual_stock, @current_stock, @issued_books)", con);
                cmd.Parameters.AddWithValue("@book_id", TextBox1.Text.Trim());
                cmd.Parameters.AddWithValue("@book_name", TextBox2.Text.Trim());
                cmd.Parameters.AddWithValue("@genre", DropdownList2.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@author_name", TextBox12.Text.Trim());
                cmd.Parameters.AddWithValue("@publisher_name", TextBox8.Text.Trim());
                cmd.Parameters.AddWithValue("@book_cost", TextBox10.Text.Trim());
                cmd.Parameters.AddWithValue("@actual_stock", TextBox4.Text.Trim());
                cmd.Parameters.AddWithValue("@current_stock", TextBox5.Text.Trim());
                cmd.Parameters.AddWithValue("@issued_books", TextBox7.Text.Trim());
                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('Book added Successfully');</script>");
                clearForm();
                GridView1.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }
        void deleteBook()
        {
            if (bookcheck())
            {
                try
                {
                    SqlConnection con = new SqlConnection(strcon);
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }

                    SqlCommand cmd = new SqlCommand("DELETE from books_tbl WHERE book_id='" + TextBox1.Text.Trim() + "'", con);

                    cmd.ExecuteNonQuery();
                    con.Close();
                    clearForm();
                    Response.Write("<script>alert('Book Deleted Successfully');</script>");
                    GridView1.DataBind();

                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('" + ex.Message + "');</script>");
                }

            }
            else
            {
                Response.Write("<script>alert('Invalid Member ID');</script>");
            }
        }

        void updateBook()
        {

            if (bookcheck())
            {

                try
                {


                    SqlConnection con = new SqlConnection(strcon);
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }

                    SqlCommand cmd = new SqlCommand("UPDATE books_tbl SET book_name=@book_name,author_name=@author_name, publisher_name=@publisher_name," +
                        "genre=@genre, book_cost=@book_cost, actual_stock=@actual_stock, current_stock=@current_stock, issued_books =@issued_books where book_id='" + TextBox1.Text.Trim() + "'", con);

                    cmd.Parameters.AddWithValue("@book_name", TextBox2.Text.Trim());
                    cmd.Parameters.AddWithValue("@author_name", TextBox12.Text.Trim());
                    cmd.Parameters.AddWithValue("@publisher_name", TextBox8.Text.Trim());
                    cmd.Parameters.AddWithValue("@genre", DropdownList2.SelectedItem.Value);
                    cmd.Parameters.AddWithValue("@book_cost", TextBox10.Text.Trim());
                    cmd.Parameters.AddWithValue("@actual_stock", TextBox4.Text.Trim());
                    cmd.Parameters.AddWithValue("@current_stock", TextBox5.Text.Trim());
                    cmd.Parameters.AddWithValue("@issued_books", TextBox7.Text.Trim());
                    cmd.ExecuteNonQuery();
                    con.Close();
                    clearForm();
                    Response.Write("<script>alert('Book Updated Successfully');</script>");
                    GridView1.DataBind();


                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('" + ex.Message + "');</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('Invalid Book ID');</script>");
            }
        }


        void findBook()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT * from books_tbl WHERE book_id='" + TextBox1.Text.Trim() + "';", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count >= 1)
                {
                    TextBox2.Text = dt.Rows[0]["book_name"].ToString();
                    TextBox12.Text = dt.Rows[0]["author_name"].ToString().Trim();
                    TextBox8.Text = dt.Rows[0]["publisher_name"].ToString().Trim();
                    DropdownList2.SelectedItem.Value = dt.Rows[0]["genre"].ToString().Trim();
                    TextBox10.Text = dt.Rows[0]["book_cost"].ToString().Trim();
                    TextBox4.Text = dt.Rows[0]["actual_stock"].ToString().Trim();
                    TextBox5.Text = dt.Rows[0]["current_stock"].ToString().Trim();
                    TextBox7.Text = dt.Rows[0]["issued_books"].ToString().Trim();

                }
                else
                {
                    Response.Write("<script>alert('Invalid Book ID');</script>");
                }

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Wrong User ID');</script>");
            }
        }



        bool bookcheck()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("SELECT * from books_tbl where book_id='" + TextBox1.Text.Trim() + "' OR book_name='" + TextBox2.Text.Trim() + "';", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count >= 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }


            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
                return false;
            }
        }
      
        void clearForm()
        {
            TextBox1.Text = "";
            TextBox2.Text = "";
            TextBox12.Text = "";
            TextBox4.Text = "";
            TextBox10.Text = "";
            TextBox8.Text = "";
        }
    }
}