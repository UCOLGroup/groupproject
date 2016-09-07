using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace BICT_Student_planning
{/// <summary>
/// this is the main form 
/// </summary>
    public partial class FrmBICTLogin : Form
    {   //Creating a variable called connection 
        private OleDbConnection connection = new OleDbConnection();

        public string UsernameLabel;

        public FrmBICTLogin()
        {
            InitializeComponent();
            //this is the connection string that connects to the Microsoft access database to the login Form
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\Student_Papers.accdb;
            Persist Security Info = False;";
        }
        /// <summary>
        /// Once the form is Loaded the coonection will be verified by the label on the form showing a successful message
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmBICTLogin_Load(object sender, EventArgs e)
        {
            try
            {
                //Open connection to the database
                connection.Open();
                //Setting the lblConnectionStatus label to connection successfull to show the connection is complete
                lblConnectionStatus.Text = "Connection Successful";
                //closing the connection
                connection.Close();
            }
            catch (Exception Ex)
            {//Message box throws the error if not connected
                MessageBox.Show("Connection Error" + Ex);
            }

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            connection.Open();
            //Creating a variable called command 
            OleDbCommand command = new OleDbCommand();
            command.Connection = connection;
            //Selecting the userinput from the login form and matching it with the database so that it can compare the username and password
            command.CommandText = "Select * from students where user_name='"+tbxUserName.Text+"' and password='"+tbxPassword.Text+"';";
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
                Students student = new Students();
                student.User_name = tbxUserName.Text;

                this.Hide();

                
                Student_Course SC = new Student_Course(student);
                //this shows the Student course form(i.e the second form)
                SC.ShowDialog();
        }
            //if the username and password match another user in the database display this message
            else if (count > 1) 
            {
                  
                MessageBox.Show("Duplicate username or password");
            }
            //if the wrong password is entered Display this message "Wrong Username or Password"
            else
            {
                MessageBox.Show("Wrong Username or Password");
                tbxUserName.Text = "";
                tbxPassword.Text = "";
                tbxUserName.Focus();
            }
            // close the connection to the access database
        connection.Close();
        }
    }
}
