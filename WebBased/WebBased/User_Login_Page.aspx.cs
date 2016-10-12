using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;
using WebBased.Models;

namespace WebBased
{
    public partial class User_Login_Page : System.Web.UI.Page
    {
        //declare and initialize a variable called student
        public Student student = new Student();
        //declare and initialize a database connection variable called connection
        private OleDbConnection connection = new OleDbConnection();
        //declare and initialize a variable called UsernameLabel
        public static string UsernameLabel;

        protected void Page_Load(object sender, EventArgs e)
        {

        }


        protected void btnRegister_Click(object sender, EventArgs e)
        {
            //point to the database file in the software directory for the Student table
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\Student_Papers.accdb;
            Persist Security Info = False;";
            //If the lecturer checkbox hasn't been checked run this code
            if (chkLecturerLogin.Checked == false)
            {
                //Open up a connection to the database
                connection.Open();
                //declare and initialize a variable called command 
                OleDbCommand command = new OleDbCommand();
                //put the connection string into the command object
                command.Connection = connection;
                //Selecting the userinput from the login form and matching it with the database so that it can compare the username and password
                command.CommandText = "Select * from students where user_name='" + tbxUsername.Text + "' and password='" + tbxPassword.Text + "';";
                // Read out of the database
                OleDbDataReader reader = command.ExecuteReader();
                //var count is set to Zero
                int count = 0;
                //Loop through records and returning them to Count if they match what the Student typed in.
                while (reader.Read())
                {
                    count = count + 1;
                }

                if (count == 1)
                {   
                    //Close the connection to the database
                    connection.Close();
                    //Close the connection to the database
                    connection.Dispose();
                    //Updating the username label
                    UsernameLabel = tbxUsername.Text;
                    //if the username and password are correct login to this session
                    Session["USER_ID"] = tbxUsername.Text;
                    //open the lecturer page
                    Response.Redirect("Students_Course.aspx");

                }
                //if the username and password match another user in the database display this message
                else if (count > 1)
                {

                    //MessageBox.Show("Duplicate username or password");
                }
                //if the wrong password is entered Display this message "Wrong Username or Password"
                else
                {
                    //alert message will show if the username and password don't match the Student table in the database.
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Wrong username & Password')</script>");
                    //clears the Username textbox
                    tbxUsername.Text = "";
                    //clears the Password textbox
                    tbxPassword.Text = "";
                    //return cursor focus onto the Username textbox 
                    tbxUsername.Focus();
                }
                // close the connection to the database
                connection.Close();
            }



            if (chkLecturerLogin.Checked == true)
            {
                //point to the database file in the software directory for the Lecturer table
                connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\Student_Papers.accdb;
            Persist Security Info = False;";
                //Open up connection to the database
                connection.Open();
                //declare and initialize a variable called command
                OleDbCommand command = new OleDbCommand();
                //put the connection string into the command object
                command.Connection = connection;
                //Selecting the userinput from the login form and matching it with the database so that it can compare the username and password
                command.CommandText = "Select * from lecturers where user_name='" + tbxUsername.Text + "' and password='" + tbxPassword.Text + "';";
                // Read out of the database
                OleDbDataReader reader = command.ExecuteReader();
                //var count is set to Zero
                int count = 0;
                //Loop through records and returning them to Count if the Lecturer username and password match to the database.
                while
                    (reader.Read())
                {
                    count = count + 1;
                }
                //If the count has equals one 
                if (count == 1)
                {
                    //close database connection
                    connection.Close();
                    //close database connection
                    connection.Dispose();
                    //if the username and password are correct login to this session
                    Session["USER_ID"] = tbxUsername.Text;
                    //open the lecturer page
                    Response.Redirect("Lecturer.aspx");
                }

                else
                {
                    //alert message will show if the username and password don't match the lecturer table in the database.
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Wrong username & Password')</script>");
                    //clears the Username textbox
                    tbxUsername.Text = "";
                    //clears the password textbox
                    tbxPassword.Text = "";
                    //return cursor focus onto the Username textbox
                    tbxUsername.Focus();
                }
                // close the connection to the database
                connection.Close();

            }
        }

        protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {


        }
    }
}
