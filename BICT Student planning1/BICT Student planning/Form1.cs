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
{
    public partial class FrmBICTLogin : Form
    {
        private OleDbConnection connection = new OleDbConnection();
        public FrmBICTLogin()
        {
            InitializeComponent();
            //this is the connection string that connects to the Microsoft access database to the login Form
            connection.ConnectionString = @"Provider = Microsoft.ACE.OLEDB.12.0; Data Source = H:\groupproject\Database\Student_Papers.accdb;
            Persist Security Info = False;";
        }

        private void FrmBICTLogin_Load(object sender, EventArgs e)
        {
            try
            {
                //Open connection to the database
                connection.Open();
                //Setting the lblConnectionStatus label to connection successfull to show the connection is complete
                lblConnectionStatus.Text = "Connection Successfull";
                //closing the connection
                connection.Close();
            }
            catch (Exception Ex)
            {//Message box throws the error if not connected
                MessageBox.Show("Error" + Ex);
            }

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            connection.Open();
            OleDbCommand command = new OleDbCommand();
            command.Connection = connection;
            //Selecting the userinput from the login form and matching it with the database so that it can compare the username and password
            command.CommandText = "Select * from students where first_name='"+tbxUserName.Text+"' and password='"+tbxPassword.Text+"';";
            // Read out of the database
            OleDbDataReader reader = command.ExecuteReader();
            int count = 0;
            while (reader.Read())
            {
                count = count + 1;
            }
            if (count == 1)
            {
                MessageBox.Show("login successfull");
                connection.Close();
                connection.Dispose();
                //this hides the first login form 
                this.Hide();
                Student_Course SC = new Student_Course();
                //this shows the Student COurse form(i.e the second form)
                SC.ShowDialog();
        }
            else if (count > 1) 
            {
                MessageBox.Show("Duplicate username or password");
            }
            
            else
            {
                MessageBox.Show("Wrong Username or Password");
            }
connection.Close();
        }
    }
}
