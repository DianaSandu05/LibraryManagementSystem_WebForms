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
    public partial class lendingManagement : System.Web.UI.Page
    {
        DateTime today = DateTime.Today;
        DateTime fine_calculation;
        double total_fine;
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            GridView1.DataBind();
        }
        // lend book
        protected void Button2_Click(object sender, EventArgs e)
        {
            if (bookcheck() && membercheck())
            {

                issuescheck();
                Response.Write("<script>alert('This Member already has this book');</script>");
            }
            else
            {
                issueBook();
            }
        }
        // return book
        protected void Button4_Click(object sender, EventArgs e)
        {
                returnBook();
        }
        // go button
        protected void Button1_Click(object sender, EventArgs e)
        {
            findNames();
        }

        // user defined function

        void returnBook()
        {
            if (issuescheck())
            {


                try
                {
                    SqlConnection con = new SqlConnection(strcon);
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    SqlCommand cmd = new SqlCommand("DELETE from lending_tbl WHERE book_id='" + TextBox1.Text.Trim() + "' AND member_id='" + TextBox2.Text.Trim() + "'", con);
                    cmd.ExecuteNonQuery();
                    cmd = new SqlCommand("UPDATE books_tbl SET current_stock = current_stock+1 WHERE book_id='" + TextBox1.Text.Trim() + "'", con);
                    cmd.ExecuteNonQuery();
                    cmd = new SqlCommand("UPDATE books_tbl SET issued_books = issued_books-1 WHERE book_id='" + TextBox1.Text.Trim() + "'", con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    Response.Write("<script>alert('Record Deleted Successfully');</script>");
                    clearForm();
                    GridView1.DataBind();
                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('" + ex.Message + "');</script>");
                }
            }
        }

        void issueBook()
        {
            if(dateFine())
            {

            }

            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("INSERT INTO lending_tbl (member_id, full_name, book_id, book_name, issue_date," +
                    " due_date, lendingFine) values (@member_id," +
                    "@full_name, @book_id, @book_name, @issue_date, @due_date, @lendingFine )", con);
                cmd.Parameters.AddWithValue("@member_id", TextBox2.Text.Trim());
                cmd.Parameters.AddWithValue("@full_name", TextBox3.Text.Trim());
                cmd.Parameters.AddWithValue("@book_id", TextBox1.Text.Trim());
                cmd.Parameters.AddWithValue("@book_name", TextBox4.Text.Trim());
                cmd.Parameters.AddWithValue("@issue_date", TextBox5.Text.Trim());
                cmd.Parameters.AddWithValue("@due_date", TextBox6.Text.Trim());
                cmd.Parameters.AddWithValue("@lendingFine", TextBox7.Text.Trim());
                cmd.ExecuteNonQuery();
                cmd = new SqlCommand("UPDATE books_tbl SET current_stock = current_stock-1 WHERE book_id='" + TextBox1.Text.Trim() + "'", con);
                cmd.ExecuteNonQuery();
                cmd = new SqlCommand("UPDATE books_tbl SET issued_books = issued_books+1 WHERE book_id='" + TextBox1.Text.Trim() + "'", con);
                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('Book Issued Successfully');</script>");
                GridView1.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
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
                SqlCommand cmd = new SqlCommand("SELECT FROM books_tbl WHERE book_id='" + TextBox1.Text.Trim() + "' AND current_stock >0", con);
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
                return false;
            }

        }


        bool membercheck()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT full_name from member_tbl WHERE member_id='" + TextBox2.Text.Trim() + "'", con);
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
                return false;
            }

        }

        bool issuescheck()
        {
            try
            {
                
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT * from lending_tbl WHERE member_id='" + TextBox2.Text.Trim() + "' AND book_id='"
                    + TextBox1.Text.Trim() + "'", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count >= 1)
                {
                    TextBox3.Text = dt.Rows[0]["full_name"].ToString();
                    TextBox4.Text = dt.Rows[0]["book_name"].ToString();
                    TextBox5.Text = dt.Rows[0]["issue_date"].ToString();
                    TextBox6.Text = dt.Rows[0]["due_date"].ToString();
                    TextBox7.Text = dt.Rows[0]["lendingFine"].ToString();
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception ex)
            {
                return false;
            }

        }
        void findNames()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT book_name from books_tbl WHERE book_id='" + TextBox1.Text.Trim() + "'", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count >= 1)
                {
                    TextBox4.Text = dt.Rows[0]["book_name"].ToString();
                }
                else
                {
                    Response.Write("<script>alert('Wrong Book ID');</script>");
                }

                cmd = new SqlCommand("SELECT full_name from member_tbl WHERE member_id='" + TextBox2.Text.Trim() + "'", con);
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count >= 1)
                {
                    TextBox3.Text = dt.Rows[0]["full_name"].ToString();
                }
                else
                {
                    Response.Write("<script>alert('Wrong User ID');</script>");
                }
                cmd = new SqlCommand("SELECT * from lending_tbl WHERE member_id='" + TextBox2.Text.Trim() + "' AND book_id='"
                  + TextBox1.Text.Trim() + "'", con);
                 da = new SqlDataAdapter(cmd);
                 dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count >= 1)
                {
                    TextBox2.Text = dt.Rows[0]["member_id"].ToString();
                    TextBox1.Text = dt.Rows[0]["book_id"].ToString();
                    TextBox3.Text = dt.Rows[0]["full_name"].ToString();
                    TextBox4.Text = dt.Rows[0]["book_name"].ToString();
                    TextBox5.Text = dt.Rows[0]["issue_date"].ToString();
                    TextBox6.Text = dt.Rows[0]["due_date"].ToString();
                    TextBox7.Text = dt.Rows[0]["lendingFine"].ToString();

                }
                else
                {
                    Response.Write("<script>alert('The record does not exists. Please review your entry details');</script>");
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Wrong User ID');</script>");
            }
        }

          bool dateFine()
           { 
            double amount;
            double fine = 0.50;
            fine_calculation = Convert.ToDateTime(TextBox6.Text);
            DateTime today = DateTime.Today;
                   if (today > fine_calculation)
                   {
                       total_fine = (today - fine_calculation).TotalDays;
                       amount = total_fine * fine;
                       TextBox7.Text = Convert.ToString(amount);
                       
                       return true;
                   }
            else
            {
                return false;
            }
           }
        void clearForm()
        {
            TextBox1.Text = "";
            TextBox2.Text = "";
            TextBox3.Text = "";
            TextBox4.Text = "";
            TextBox5.Text = "";
            TextBox6.Text = "";
            TextBox7.Text = "";
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                 SqlConnection con = new SqlConnection(strcon);
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }

                    SqlCommand cmd = new SqlCommand("INSERT INTO lending_tbl (lendingFine) values (@lendingFine )", con);
                    if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    //Check your condition here
                    double totalfine;
                    double fine = 0.50;
                    DateTime dt = Convert.ToDateTime(e.Row.Cells[5].Text);
                    DateTime today = DateTime.Today;
                    if (today > dt)
                    {
                        e.Row.Cells[5].BackColor = System.Drawing.Color.PaleVioletRed ;
                        TimeSpan timeSpan = today - dt;
                        totalfine = Convert.ToDouble(timeSpan) * fine;
                        TextBox7.Text = Convert.ToString(totalfine);
                        cmd.Parameters.AddWithValue("@lendingFine",  TextBox7.Text.Trim());
                    }

                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        
    }
}