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
            //connection.ConnectionString = @"Provider = Microsoft.ACE.OLEDB.12.0; Data Source = C:\myFolder\myAccessFile.accdb;
            //Persist Security Info = False;";
        }

        private void FrmBICTLogin_Load(object sender, EventArgs e)
        {
            //try {
            //    connection.Open();
            //    lblConnectionStatus.Text = "Connection Successfull";
            //    connection.Close();
            //}
            //catch (Exception Ex)
            //{
            //    MessageBox.Show("Error" + Ex);
            //}

         }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            //connection.Open();
            //OleDbCommand command = new OleDbCommand();
            //command.Connection = connection;
            //command.CommandText = "";
            //OleDbDataReader reader = command.ExecuteReader();
            //int count = 0;
            //while(reader.Read())
            //{
            //    count = count + 1;
            //}
            //if (count == 1)
            //{
            //    MessageBox.Show("login successfull");
            //    connection.Close();
            //    connection.Dispose();
                this.Hide();
                Student_Course SC = new Student_Course();
                SC.ShowDialog();
            }
            //else if (count > 1) 
            //{
            //    MessageBox.Show("Duplicate username or password");
            //}
            
            //else
            //{
            //    MessageBox.Show("Wrong Username or Password");
            //}
            //connection.Close();
        //}
    }
}
