using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OleDb;

namespace WebBased
{
    public partial class Lecturer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            // Checks to see if the Session ID has been passed from login page
            if (Session["USER_ID"] != null)
            {

                // Using ADO.NET a OLE connection object is created
                OleDbConnection connection = new OleDbConnection();

                //The connection string is added to the connection object and the string is dynamic, so if we move the 
                connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\Student_Papers.accdb;
            Persist Security Info = False;";

                // Opening up the connection to the database (student_papers)
                connection.Open();

                // Create a new OLE Command object.  THis will store a Select statement
                OleDbCommand command = new OleDbCommand();

                // Adding the connection object to the command object
                command.Connection = connection;

                // Adding the select statement that will select the lecturer with the id held in the session id
                command.CommandText = "Select * FROM lecturers WHERE user_name = '" + Session["USER_ID"].ToString() + "'"; //

                // Create a OLE reader object from the command ExecuteReader method.
                OleDbDataReader reader = command.ExecuteReader();

                // When the reader obect uses the Read() method, it will retreive one record from the table.
                reader.Read();

                // Add the lecturer id into the text box using the reader object.
                TextBox1.Text = reader["lecturer_id"].ToString();

                // If the text only says Welcome, then the username needs to  
                if (lblWelcome.Text == "Welcome")
                {
                    lblWelcome.Text += " " + reader["first_name"].ToString() + " " + reader["last_name"].ToString();
                }

                // If the user is an admin change the gridviews to show all papers otherwise, limit papers to what the lecturer is teaching.
                if (TextBox1.Text == "1")
                {
                    GridView1.Visible = false;
                    GridView2.Visible = true;
                    //lblWelcome.Text += " (HEAD OF SCHOOL)";
                }
                else
                {
                    GridView1.Visible = true;
                    GridView2.Visible = false;
                }

            }

            // If the session id is empty, redirect user to the login page 
            else
            {
                Response.Redirect("User_Login_Page.aspx");
            }
        

                if (!this.IsPostBack)
            {

                //This area is used for testing 

                //Attribute to show the Plus Minus Button.
                //GridView1.HeaderRow.Cells[0].Attributes["data-class"] = "expand";

                //Attribute to hide column in phone.


             // GridView1.HeaderRow.Cells[3].Attributes["data-hide"] = "phone";
              //GridView1.HeaderRow.Cells[5].Attributes["data-hide"] = "phone";
              //GridView1.HeaderRow.Cells[6].Attributes["data-hide"] = "phone";
             // GridView1.HeaderRow.Cells[7].Attributes["data-hide"] = "phone";
             // GridView1.HeaderRow.Cells[8].Attributes["data-hide"] = "phone";

                //Adds THEAD and TBODY to GridView.
                GridView1.HeaderRow.TableSection = TableRowSection.TableHeader;
            }


        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            // Clear and Abandon the session
            Session.Clear();
            Session.Abandon();

            // Redirect user to the login page
            Response.Redirect("user_login_page.aspx");
        }
    }
}