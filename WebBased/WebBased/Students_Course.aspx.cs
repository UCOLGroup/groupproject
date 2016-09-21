using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebBased.Models;
using System.Data.OleDb;
namespace WebBased
{
    public partial class Students_Course : System.Web.UI.Page
    {
        private OleDbConnection connection = new OleDbConnection();
        protected void Page_Load(object sender, EventArgs e)
        {
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\Student_Papers.accdb;
            Persist Security Info = False;";

            if (PreviousPage != null)
            {
                TextBox SourceTextBox =
                    (TextBox)PreviousPage.FindControl("tbxUsername");
                if (SourceTextBox != null)
                {
                    lblUserNameFromLoginForm.Text = SourceTextBox.Text;
                }
            }


            //connection.Open();
            //OleDbCommand command = new OleDbCommand();
            //command.Connection = connection;
            ////Selecting the userinput from the login form and matching it with the database so that it can compare the username and password
            //string query = "Select paper_name from papers";
            //command.CommandText = query;
            //OleDbDataReader reader = command.ExecuteReader();

            //while (reader.Read())
            //{




            //}
            Literal1.Text += "<div class='row' style='border: 2px solid black; margin: 30px; padding: 15px;'>";
            Literal1.Text += "<div class='col-md-4'>";

            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                if (GridView1.Rows[i].Cells[4].Text == "Software Development" && GridView1.Rows[i].Cells[5].Text == "5")
                {
                    Literal1.Text += "<button class='' style='background-color: blue;'>" + GridView1.Rows[i].Cells[3].Text + "<br>" + GridView1.Rows[i].Cells[2].Text + "</button>";
                }
                
            }

            Literal1.Text += "</div>";
            Literal1.Text += "<div class='col-md-4'>";

            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                if (GridView1.Rows[i].Cells[4].Text == "Information Management" && GridView1.Rows[i].Cells[5].Text == "5")
                {
                    Literal1.Text += "<button style='background-color: yellow;'>" + GridView1.Rows[i].Cells[3].Text + "<br>" + GridView1.Rows[i].Cells[2].Text + "</button>";
                }

            }

            Literal1.Text += "</div>";
            Literal1.Text += "<div class='col-md-4'>";

            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                if (GridView1.Rows[i].Cells[4].Text == "Technology" && GridView1.Rows[i].Cells[5].Text == "5")
                {
                    Literal1.Text += "<button style='background-color: red;'>" + GridView1.Rows[i].Cells[3].Text + "<br>" + GridView1.Rows[i].Cells[2].Text + "</button>";
                }

            }

            Literal1.Text += "</div>";
            Literal1.Text += "</div>";

            // 1st year end

            Literal1.Text += "<div class='row' style='border: 2px solid black; margin: 30px; padding: 15px;'>";
            Literal1.Text += "<div class='col-md-4'>";

            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                if (GridView1.Rows[i].Cells[4].Text == "Software Development" && GridView1.Rows[i].Cells[5].Text == "6")
                {
                    Literal1.Text += "<button class='' style='background-color: blue;'>" + GridView1.Rows[i].Cells[3].Text + "<br>" + GridView1.Rows[i].Cells[2].Text + "</button>";
                }

            }

            Literal1.Text += "</div>";
            Literal1.Text += "<div class='col-md-4'>";

            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                if (GridView1.Rows[i].Cells[4].Text == "Information Management" && GridView1.Rows[i].Cells[5].Text == "6")
                {
                    Literal1.Text += "<button style='background-color: yellow;'>" + GridView1.Rows[i].Cells[3].Text + "<br>" + GridView1.Rows[i].Cells[2].Text + "</button>";
                }

            }

            Literal1.Text += "</div>";
            Literal1.Text += "<div class='col-md-4'>";

            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                if (GridView1.Rows[i].Cells[4].Text == "Technology" && GridView1.Rows[i].Cells[5].Text == "6")
                {
                    Literal1.Text += "<button style='background-color: red;'>" + GridView1.Rows[i].Cells[3].Text + "<br>" + GridView1.Rows[i].Cells[2].Text + "</button>";
                }

            }

            Literal1.Text += "</div>";
            Literal1.Text += "</div>";

            // 2nd year end


            Literal1.Text += "<div class='row' style='border: 2px solid black; margin: 30px; padding: 15px;'>";
            Literal1.Text += "<div class='col-md-4'>";

            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                if (GridView1.Rows[i].Cells[4].Text == "Software Development" && GridView1.Rows[i].Cells[5].Text == "7")
                {
                    Literal1.Text += "<button class='' style='background-color: blue;'>" + GridView1.Rows[i].Cells[3].Text + "<br>" + GridView1.Rows[i].Cells[2].Text + "</button>";
                }

            }

            Literal1.Text += "</div>";
            Literal1.Text += "<div class='col-md-4'>";

            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                if (GridView1.Rows[i].Cells[4].Text == "Information Management" && GridView1.Rows[i].Cells[5].Text == "7")
                {
                    Literal1.Text += "<button style='background-color: yellow;'>" + GridView1.Rows[i].Cells[3].Text + "<br>" + GridView1.Rows[i].Cells[2].Text + "</button>";
                }

            }

            Literal1.Text += "</div>";
            Literal1.Text += "<div class='col-md-4'>";

            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                if (GridView1.Rows[i].Cells[4].Text == "Technology" && GridView1.Rows[i].Cells[5].Text == "7")
                {
                    Literal1.Text += "<button style='background-color: red;'>" + GridView1.Rows[i].Cells[3].Text + "<br>" + GridView1.Rows[i].Cells[2].Text + "</button>";
                }

            }

            Literal1.Text += "</div>";
            Literal1.Text += "</div>";

        }
        }
}