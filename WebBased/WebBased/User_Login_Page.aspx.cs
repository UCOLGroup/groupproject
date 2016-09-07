using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;

namespace WebBased
{
    public partial class User_Login_Page : System.Web.UI.Page
    {
        private OleDbConnection connection = new OleDbConnection();
        public string UsernameLabel;
     
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

       
        protected void btnRegister_Click(object sender, EventArgs e)
        {
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=H:\groupproject\WebBased\WebBased\App_Data\Student_Papers.accdb;
            Persist Security Info = False;";
            if (chkLecturerLogin.Checked == false) { 
                //Response.Write("Successful Registration");
                connection.Open();
            //Creating a variable called command 
            OleDbCommand command = new OleDbCommand();
            command.Connection = connection;
            //Selecting the userinput from the login form and matching it with the database so that it can compare the username and password
            command.CommandText = "Select * from students where user_name='" + tbxUsername.Text + "' and password='" + tbxPassword.Text + "';";
            // Read out of the database
            OleDbDataReader reader = command.ExecuteReader();
            //count is Zero
            int count = 0;
            while (reader.Read())
            {
                count = count + 1;
            }

            if (count == 1)
            {   // Messagebox will show if the was login successful
                // MessageBox.Show("Login Successful");
                //Close the connection to the database
                connection.Close();

                connection.Dispose();
                    //this hides the first login form 
                    // Students student = new Students();
                    //student.User_name = tbxUsername.Text;

                    Response.Redirect("Students_Course.aspx");


                //Student_Course SC = new Student_Course(student);
                //this shows the Student course form(i.e the second form)
                // SC.ShowDialog();
            }
            //if the username and password match another user in the database display this message
            else if (count > 1)
            {

                //MessageBox.Show("Duplicate username or password");
            }
            //if the wrong password is entered Display this message "Wrong Username or Password"
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Wrong username & Password')</script>");
                // Response.Write("Wrong Username or Password");
                tbxUsername.Text = "";
                tbxPassword.Text = "";
                tbxUsername.Focus();
            }
            // close the connection to the access database
            connection.Close();
            }



            if (chkLecturerLogin.Checked == true)
            {
                connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=H:\groupproject\WebBased\WebBased\App_Data\Student_Papers.accdb;
            Persist Security Info = False;";
                connection.Open();
                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;
                //Selecting the userinput from the login form and matching it with the database so that it can compare the username and password
                command.CommandText = "Select * from lecturers where user_name='" + tbxUsername.Text + "' and password='" + tbxPassword.Text + "';";
                // Read out of the database
                OleDbDataReader reader = command.ExecuteReader();
                int count = 0;
                while
                    (reader.Read())
                {
                    count = count + 1;
                }

                if (count == 1)
                {
                    connection.Close();

                    connection.Dispose();
                    Response.Redirect("Lecturer.aspx");
                }

                else
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Wrong username & Password')</script>");
                    // Response.Write("Wrong Username or Password");
                    tbxUsername.Text = "";
                    tbxPassword.Text = "";
                    tbxUsername.Focus();
                }
                // close the connection to the access database
                connection.Close();

            }
        }

        protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
         

            }
        }
    }
