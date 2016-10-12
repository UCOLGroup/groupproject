using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebBased.Models;
using System.Data.OleDb;
using System.Data;

namespace WebBased
{
    public partial class Students_Course : System.Web.UI.Page
    {
        private OleDbConnection connection = new OleDbConnection();

        protected DataSet GetPapersCompleted(string studentId)
        {
            connection.Open();
            OleDbCommand command = new OleDbCommand();
            command.Connection = connection;
            //Selecting the userinput from the login form and matching it with the database so that it can compare the username and password
            string query = "SELECT papers.category, papers.[level], papers.credits, papers.semester, papers.paper_name AS Expr1, papers.code, papers.lecturer_id, papers.paper_id, papers.* FROM (student_papers INNER JOIN papers ON student_papers.paper_id = papers.paper_id) WHERE student_papers.student_id = " + studentId;
            command.CommandText = query;
            OleDbDataAdapter adapter = new OleDbDataAdapter(query, connection);
            DataSet studentPapers = new DataSet();
            adapter.Fill(studentPapers, "student_papers");

            connection.Close();

            return studentPapers;
        }

        protected string GetIdFromDB(string userId)
        {
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\Student_Papers.accdb;
            Persist Security Info = False;";

            connection.Open();
            OleDbCommand command = new OleDbCommand();
            command.Connection = connection;
            //Selecting the userinput from the login form and matching it with the database so that it can compare the username and password
            string query = "Select student_id from students WHERE user_name = '" + userId + "'";
            command.CommandText = query;
            OleDbDataReader reader = command.ExecuteReader();

            reader.Read();


            string studentID = reader["student_id"].ToString();

            connection.Close();
            return studentID;
        }

        protected string GetNameFromDB(string userId)
        {
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\Student_Papers.accdb;
            Persist Security Info = False;";

            connection.Open();
            OleDbCommand command = new OleDbCommand();
            command.Connection = connection;
            //Selecting the userinput from the login form and matching it with the database so that it can compare the username and password
            string query = "Select first_name, last_name from students WHERE user_name = '" + userId + "'";
            command.CommandText = query;
            OleDbDataReader reader = command.ExecuteReader();

            reader.Read();


            string firstName = reader["first_name"].ToString();
            string lastName = reader["last_name"].ToString();
            string fullName = firstName + " " + lastName;

            connection.Close();
            return fullName;
        }

        protected void Page_Load(object sender, EventArgs e)
        {


            if (PreviousPage != null)
            {
                TextBox SourceTextBox =
                    (TextBox)PreviousPage.FindControl("tbxUsername");
                if (SourceTextBox != null)
                {
                    lblUserNameFromLoginForm.Text = SourceTextBox.Text;
                }
            }

            if (Session["USER_ID"] == null)
            {
                Response.Redirect("User_Login_Page.aspx");
            }

            // Get the primary key from the database so we can query what papers have been completed
            string studentID = GetIdFromDB(Session["USER_ID"].ToString());

            // Using the method put all of the records relating to the student id into a dataset.
            DataSet studentPapers = GetPapersCompleted(studentID);

            // Loop through the dataset and retreive papers that have been completed by the logged in user
            List<string> papersDone = new List<string>();
            for (int i = 0; i < studentPapers.Tables[0].Rows.Count; i++)
            {
                lblTester.Text += studentPapers.Tables[0].Rows[i]["paper_name"].ToString() + "<br>"; //testing purposes
            }


            // Use the method and grab the name from the database and input it into the text area based on session data
            lblName.Text = GetNameFromDB(Session["USER_ID"].ToString());




            Literal1.Text = "";


            Literal1.Text += "<div class='row'>";
            Literal1.Text += "<div class='year_label'><span class='label label-primary'>Year 1</span></div>";
            Literal1.Text += "<div class='col-md-4'>";
            Literal1.Text += "<div class='alert alert-info cat' role='alert'>Software Development</div>";


            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                if (GridView1.Rows[i].Cells[4].Text == "Software Development" && GridView1.Rows[i].Cells[5].Text == "5")
                {
                    // Testing to see if the paper has been completed or not, if it has it will add a border and bold the text.
                    bool paperIsComplete = false;

                    for (int z = 0; z < studentPapers.Tables[0].Rows.Count; z++)
                    {
                        if (studentPapers.Tables[0].Rows[z][3].ToString() == GridView1.Rows[i].Cells[3].Text)
                        {
                            paperIsComplete = true;
                        }
                    }

                    if (!paperIsComplete)
                    {
                        Literal1.Text += "<button class='paper s_dev_com'>" + GridView1.Rows[i].Cells[3].Text + "<br>" + GridView1.Rows[i].Cells[2].Text + "</button>";
                    }
                    else
                    {
                        Literal1.Text += "<button class='paper s_dev'>" + GridView1.Rows[i].Cells[3].Text + "<br>" + GridView1.Rows[i].Cells[2].Text + "</button>";
                    }




                }

            }


            Literal1.Text += "</div>";
            Literal1.Text += "<div class='col-md-4'>";
            Literal1.Text += "<div class='alert alert-warning cat' role='alert'>Information Management</div>";


            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                if (GridView1.Rows[i].Cells[4].Text == "Information Management" && GridView1.Rows[i].Cells[5].Text == "5")
                {
                    Literal1.Text += "<button class='paper info_man'" + GridView1.Rows[i].Cells[3].Text + "<br>" + GridView1.Rows[i].Cells[2].Text + "</button>";

                    //creating a dynamic checkbox

                }

            }

            Literal1.Text += "</div>";
            Literal1.Text += "<div class='col-md-4'>";
            Literal1.Text += "<div class='alert alert-danger cat' role='alert'>Technology</div>";

            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                if (GridView1.Rows[i].Cells[4].Text == "Technology" && GridView1.Rows[i].Cells[5].Text == "5")
                {
                    Literal1.Text += "<button class='paper tech'>" + GridView1.Rows[i].Cells[3].Text + "<br>" + GridView1.Rows[i].Cells[2].Text + "</button>";

                }

            }
            Literal1.Text += "</div>";
            Literal1.Text += "</div>";

            // 1st year end

            Literal1.Text += "<div class='row'>";
            Literal1.Text += "<div class='year_label'><span class='label label-primary'>Year 2</span></div>";
            Literal1.Text += "<div class='col-md-4'>";
            Literal1.Text += "<div class='alert alert-info cat' role='alert'>Software Development</div>";

            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                if (GridView1.Rows[i].Cells[4].Text == "Software Development" && GridView1.Rows[i].Cells[5].Text == "6")
                {
                    Literal1.Text += "<button class='paper s_dev'>" + GridView1.Rows[i].Cells[3].Text + "<br>" + GridView1.Rows[i].Cells[2].Text + "</button>";

                }

            }
            Literal1.Text += "</div>";
            Literal1.Text += "<div class='col-md-4'>";
            Literal1.Text += "<div class='alert alert-warning cat' role='alert'>Information Management</div>";

            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                if (GridView1.Rows[i].Cells[4].Text == "Information Management" && GridView1.Rows[i].Cells[5].Text == "6")
                {
                    Literal1.Text += "<button class='paper info_man'>" + GridView1.Rows[i].Cells[3].Text + "<br>" + GridView1.Rows[i].Cells[2].Text + "</button>";

                }

            }
            Literal1.Text += "</div>";
            Literal1.Text += "<div class='col-md-4'>";
            Literal1.Text += "<div class='alert alert-danger cat' role='alert'>Technology</div>";

            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                if (GridView1.Rows[i].Cells[4].Text == "Technology" && GridView1.Rows[i].Cells[5].Text == "6")
                {
                    Literal1.Text += "<button class='paper tech'>" + GridView1.Rows[i].Cells[3].Text + "<br>" + GridView1.Rows[i].Cells[2].Text + "</button>";

                }

            }
            Literal1.Text += "</div>";
            Literal1.Text += "</div>";

            // 2nd year end


            Literal1.Text += "<div class='row'>";
            Literal1.Text += "<div class='year_label'><span class='label label-primary'>Year 3</span></div>";
            Literal1.Text += "<div class='col-md-4'>";
            Literal1.Text += "<div class='alert alert-info cat' role='alert'>Software Development</div>";

            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                if (GridView1.Rows[i].Cells[4].Text == "Software Development" && GridView1.Rows[i].Cells[5].Text == "7")
                {
                    Literal1.Text += "<button class='paper s_dev'>" + GridView1.Rows[i].Cells[3].Text + "<br>" + GridView1.Rows[i].Cells[2].Text + "</button>";

                }

            }
            Literal1.Text += "</div>";
            Literal1.Text += "<div class='col-md-4'>";
            Literal1.Text += "<div class='alert alert-warning cat' role='alert'>Information Management</div>";

            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                if (GridView1.Rows[i].Cells[4].Text == "Information Management" && GridView1.Rows[i].Cells[5].Text == "7")
                {
                    Literal1.Text += "<button class='paper info_man'>" + GridView1.Rows[i].Cells[3].Text + "<br>" + GridView1.Rows[i].Cells[2].Text + "</button>";

                }

            }
            Literal1.Text += "</div>";
            Literal1.Text += "<div class='col-md-4'>";
            Literal1.Text += "<div class='alert alert-danger cat' role='alert'>Technology</div>";

            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                if (GridView1.Rows[i].Cells[4].Text == "Technology" && GridView1.Rows[i].Cells[5].Text == "7")
                {
                    Literal1.Text += "<button id ='" + i + "' class='paper tech'>" + GridView1.Rows[i].Cells[3].Text + "<br>" + GridView1.Rows[i].Cells[2].Text + "<br></button>";

                    // Adding dynamic checkboxes (testing)
                    AddCheckboxes(i.ToString());

                }

            }
            Literal1.Text += "</div>";
            Literal1.Text += "</div>";

        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Session.Abandon();
            Response.Redirect("user_login_page.aspx");
        }


        // Adding dynamic checkboxes
        CheckBox chkList1;
        private void AddCheckboxes(string strCheckboxText)
        {


            chkList1 = new CheckBox();
            chkList1.Text = strCheckboxText;
            chkList1.ID = "Chk" + strCheckboxText;
            chkList1.Font.Name = "Verdana";
            chkList1.Font.Size = 9;
            chkList1.Attributes.Add("dataAttributeA", "test");
            chkList1.Attributes["dataAttributeA"] = "hello";

            form1.Controls.Add(chkList1);
            form1.Controls.Add(new LiteralControl("<br>"));


        }
    }
}