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

        /// <summary>
        /// Retreive papers that the student has completed
        /// </summary>
        /// <param name="studentId">Add the student ID of the paper</param>
        /// <returns></returns>
        protected DataSet GetPapersCompleted(string studentId)
        {
            // Using ADO.NET a OLE connection object is created
            connection.Open();

            // Create a new OLE Command object.  THis will store a Select statement
            OleDbCommand command = new OleDbCommand();

            // Adding the connection object to the command object
            command.Connection = connection;

            // Selecting all the papers that a student has passed (based on the student id parsed in)
            string query = "SELECT papers.category, papers.[level], papers.credits, papers.semester, papers.paper_name AS Expr1, papers.code, papers.lecturer_id, papers.paper_id, papers.* FROM (student_papers INNER JOIN papers ON student_papers.paper_id = papers.paper_id) WHERE student_papers.student_id = " + studentId;

            // Add the query to the CommandText object
            command.CommandText = query;

            // Set up an adapter object that holds the query and connection objects (The adapter is communicates between the database and the dataset)
            OleDbDataAdapter adapter = new OleDbDataAdapter(query, connection);

            // Create a dataset and Fill the dataset with the student_papers table data 
            DataSet studentPapers = new DataSet();
            adapter.Fill(studentPapers, "student_papers");

            // Close connection to database
            connection.Close();

            // Return the dataset that holds all the papers that a student has completed
            return studentPapers;
        }




        /// <summary>
        /// This method is used to return a student id (primary key) from the database using a select statement referencing the userId
        /// </summary>
        /// <param name="userId">The userId field from the student database</param>
        /// <returns>It will return a student id string variable based upon the userId</returns>
        protected string GetIdFromDB(string userId)
        {
            // Creating a connection string that connects to the access database in a dynamic directory (web based/app_data/Student_Papers.accdb)
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\Student_Papers.accdb;
            Persist Security Info = False;";

            connection.Open();
            OleDbCommand command = new OleDbCommand();
            command.Connection = connection;
            //Selecting the userinput from the login form and matching it with the database so that it can compare the username and password
            string query = "Select student_id from students WHERE user_name = '" + userId + "'";

            // adding the query variable to the command object
            command.CommandText = query;
            // Creating a db readerobject that holds the information from based on the select statement
            OleDbDataReader reader = command.ExecuteReader();

            // Each time that the reader is Read() it will retrieve one row from the database
            reader.Read();

            // Create a string variable called studentID and store the student_id field from the reader into that variable
            string studentID = reader["student_id"].ToString();

            // Close the connection and return the student id variable
            connection.Close();
            return studentID;
        }

        /// <summary>
        /// Retreiving a name from the database based on the userId field
        /// </summary>
        /// <param name="userId">The userId field from the student database</param>
        /// <returns>Returning a student Name (string variable) based on the userId from the database </returns>
        protected string GetNameFromDB(string userId)
        {
            // Creating a connection string that connects to the access database in a dynamic directory (web based/app_data/Student_Papers.accdb)
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\Student_Papers.accdb;
            Persist Security Info = False;";


            connection.Open();
            OleDbCommand command = new OleDbCommand();
            command.Connection = connection;
            //Selecting the userinput from the login form and matching it with the database so that it can compare the username and password
            string query = "Select first_name, last_name from students WHERE user_name = '" + userId + "'";
            command.CommandText = query;
            // Creating a db readerobject that holds the information from based on the select statement
            OleDbDataReader reader = command.ExecuteReader();

            // Each time that the reader is Read() it will retrieve one row from the database
            reader.Read();

            // This will grab the first and last name from the database and concatinate them together, then it will close the connection and return the fullname
            string firstName = reader["first_name"].ToString();
            string lastName = reader["last_name"].ToString();
            string fullName = firstName + " " + lastName;
            connection.Close();
            return fullName;
        }


        protected void Page_Load(object sender, EventArgs e)
        {

            // This will prevent users from using the back key to access the login page.
            if (PreviousPage != null)
            {
                TextBox SourceTextBox =
                    (TextBox)PreviousPage.FindControl("tbxUsername");
                if (SourceTextBox != null)
                {
                    lblUserNameFromLoginForm.Text = SourceTextBox.Text;
                }
            }

            // Check to see if the user_id session is null, if it is redirect back to the login page
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
                lblTester.Text += studentPapers.Tables[0].Rows[i][7].ToString() + "<br>"; //testing purposes
            }


            // Use the method and grab the name from the database and input it into the text area based on session data
            lblName.Text = GetNameFromDB(Session["USER_ID"].ToString());



            // Using the literal control to store all the dynamic html from the database


            ltlHtml.Text += "<div class='row'>";
            ltlHtml.Text += "<div class='year_label'><span class='label label-primary'>Year 1</span></div>";
            ltlHtml.Text += "<div class='col-md-4'>";
            ltlHtml.Text += "<div class='alert alert-info cat' role='alert'>Software Development</div>";

            // This will loop through the gridview and select all the level 5 software development papers
            for (int i = 0; i < gdvDatabase.Rows.Count; i++)
            {
                if (gdvDatabase.Rows[i].Cells[4].Text == "Software Development" && gdvDatabase.Rows[i].Cells[5].Text == "5")
                {
                    // Testing to see if the paper has been completed or not, if it has it will add a border and bold the text.
                    bool paperIsComplete = false;
                    // This will filter the results to see if the paper is completed 
                    for (int z = 0; z < studentPapers.Tables[0].Rows.Count; z++)
                    {

                        // Will compare values in studentpapers dataset to the gridview making sure that the paper id matches
                        if (studentPapers.Tables[0].Rows[z][7].ToString() == gdvDatabase.Rows[i].Cells[0].Text)
                        {

                            paperIsComplete = true;
                        }
                    }

                    // If the paper has been completed use a class that will display that paper in bold
                    if (paperIsComplete)
                    {
                        ltlHtml.Text += "<button class='paper s_dev complete' onclick='alert(\"You have completed this paper\")'>" + gdvDatabase.Rows[i].Cells[3].Text + "<br>" + gdvDatabase.Rows[i].Cells[2].Text;
                    }
                    else
                    {

                        ltlHtml.Text += "<button class='paper s_dev' onclick='alert(\"Saving Feature - Not Implemented\")'>" + gdvDatabase.Rows[i].Cells[3].Text + "<br>" + gdvDatabase.Rows[i].Cells[2].Text;
                    }


                    // If the paper is compulsory, add text below saying that it is compulsory.
                    if (gdvDatabase.Rows[i].Cells[8].Text == "Yes")
                    {
                        ltlHtml.Text += "<br><b>Compulsory</b>";
                    }

                    // close the button that surrounds the paper.
                    ltlHtml.Text += "</button>";

                }

            }
            ltlHtml.Text += "</div>";
            // First Year Software Development loop ends here.

            // First Year Information Management. Works in the same way as the commented code above (Level 5 Software Development)
            ltlHtml.Text += "<div class='col-md-4'>";
            ltlHtml.Text += "<div class='alert alert-warning cat' role='alert'>Information Management</div>";


            for (int i = 0; i < gdvDatabase.Rows.Count; i++)
            {
                if (gdvDatabase.Rows[i].Cells[4].Text == "Information Management" && gdvDatabase.Rows[i].Cells[5].Text == "5")
                {


                    // Start 
                    // Testing to see if the paper has been completed or not, if it has it will add a border and bold the text.
                    bool paperIsComplete = false;
                    // This will filter the results to see if the paper is completed 
                    for (int z = 0; z < studentPapers.Tables[0].Rows.Count; z++)
                    {

                        // Will compare values in studentpapers dataset to the gridview making sure that the paper id matches
                        if (studentPapers.Tables[0].Rows[z][7].ToString() == gdvDatabase.Rows[i].Cells[0].Text)
                        {

                            paperIsComplete = true;
                        }
                    }

                    // If the paper has been completed use a class that will display that paper in bold
                    if (paperIsComplete)
                    {
                        ltlHtml.Text += "<button class='paper info_man complete' onclick='alert(\"You have completed this paper\")'>" + gdvDatabase.Rows[i].Cells[3].Text + "<br>" + gdvDatabase.Rows[i].Cells[2].Text;
                    }
                    else
                    {
                        ltlHtml.Text += "<button class='paper info_man' onclick='alert(\"Saving Feature - Not Implemented\")'>" + gdvDatabase.Rows[i].Cells[3].Text + "<br>" + gdvDatabase.Rows[i].Cells[2].Text;
                    }
                    //Finish
             

                    if (gdvDatabase.Rows[i].Cells[8].Text == "Yes")
                    {
                        ltlHtml.Text += "<br><b>Compulsory</b>";
                    }
                    //// Testing (Not Implemented)
                    //else
                    //{
                    //    ltlHtml.Text += "<br> <input type='checkbox' name='save' value='1' onclick=Save'alert(\"Not Implemented\">";
                    //    ltlHtml.Text += "</button>";
                    //}




                }

            }
            ltlHtml.Text += "</div>";
            // First Year Information Management loop ends here.


            // First Year Technology Starts Here
            ltlHtml.Text += "<div class='col-md-4'>";
            ltlHtml.Text += "<div class='alert alert-danger cat' role='alert'>Technology</div>";

            for (int i = 0; i < gdvDatabase.Rows.Count; i++)
            {
                if (gdvDatabase.Rows[i].Cells[4].Text == "Technology" && gdvDatabase.Rows[i].Cells[5].Text == "5")
                {
                    

                    // Start 
                    // Testing to see if the paper has been completed or not, if it has it will add a border and bold the text.
                    bool paperIsComplete = false;
                    // This will filter the results to see if the paper is completed 
                    for (int z = 0; z < studentPapers.Tables[0].Rows.Count; z++)
                    {

                        // Will compare values in studentpapers dataset to the gridview making sure that the paper id matches
                        if (studentPapers.Tables[0].Rows[z][7].ToString() == gdvDatabase.Rows[i].Cells[0].Text)
                        {

                            paperIsComplete = true;
                        }
                    }

                    // If the paper has been completed use a class that will display that paper in bold
                    if (paperIsComplete)
                    {
                        ltlHtml.Text += "<button class='paper tech complete' onclick='alert(\"You have completed this paper\")'>" + gdvDatabase.Rows[i].Cells[3].Text + "<br>" + gdvDatabase.Rows[i].Cells[2].Text;
                    }
                    else
                    {
                        ltlHtml.Text += "<button class='paper tech' onclick='alert(\"Saving Feature - Not Implemented\")'>" + gdvDatabase.Rows[i].Cells[3].Text + "<br>" + gdvDatabase.Rows[i].Cells[2].Text;
                    }
                    //Finish


                    if (gdvDatabase.Rows[i].Cells[8].Text == "Yes")
                    {
                        ltlHtml.Text += "<br><b>Compulsory</b>";
                    }

                    ltlHtml.Text += "</button>";

                }

            }
            ltlHtml.Text += "</div>";
            ltlHtml.Text += "</div>";
            // First Year Technology Ends Here
            // 1st year end

            // Second Year Loops Start
            ltlHtml.Text += "<div class='row'>";
            ltlHtml.Text += "<div class='year_label'><span class='label label-primary'>Year 2</span></div>";
            ltlHtml.Text += "<div class='col-md-4'>";
            ltlHtml.Text += "<div class='alert alert-info cat' role='alert'>Software Development</div>";

            for (int i = 0; i < gdvDatabase.Rows.Count; i++)
            {
                if (gdvDatabase.Rows[i].Cells[4].Text == "Software Development" && gdvDatabase.Rows[i].Cells[5].Text == "6")
                {


                    // Start 
                    // Testing to see if the paper has been completed or not, if it has it will add a border and bold the text.
                    bool paperIsComplete = false;
                    // This will filter the results to see if the paper is completed 
                    for (int z = 0; z < studentPapers.Tables[0].Rows.Count; z++)
                    {

                        // Will compare values in studentpapers dataset to the gridview making sure that the paper id matches
                        if (studentPapers.Tables[0].Rows[z][7].ToString() == gdvDatabase.Rows[i].Cells[0].Text)
                        {

                            paperIsComplete = true;
                        }
                    }

                    // If the paper has been completed use a class that will display that paper in bold
                    if (paperIsComplete)
                    {
                        ltlHtml.Text += "<button class='paper s_dev complete' onclick='alert(\"You have completed this paper\")'>" + gdvDatabase.Rows[i].Cells[3].Text + "<br>" + gdvDatabase.Rows[i].Cells[2].Text;
                    }
                    else
                    {
                        ltlHtml.Text += "<button class='paper s_dev' onclick='alert(\"Saving Feature - Not Implemented\")'>" + gdvDatabase.Rows[i].Cells[3].Text + "<br>" + gdvDatabase.Rows[i].Cells[2].Text;
                    }
                    //Finish

                    if (gdvDatabase.Rows[i].Cells[8].Text == "Yes")
                    {
                        ltlHtml.Text += "<br><b>Compulsory</b>";
                    }

                    ltlHtml.Text += "</button>";
                }

            }
            ltlHtml.Text += "</div>";
            ltlHtml.Text += "<div class='col-md-4'>";
            ltlHtml.Text += "<div class='alert alert-warning cat' role='alert'>Information Management</div>";

            for (int i = 0; i < gdvDatabase.Rows.Count; i++)
            {
                if (gdvDatabase.Rows[i].Cells[4].Text == "Information Management" && gdvDatabase.Rows[i].Cells[5].Text == "6")
                {

                    // Start 
                    // Testing to see if the paper has been completed or not, if it has it will add a border and bold the text.
                    bool paperIsComplete = false;
                    // This will filter the results to see if the paper is completed 
                    for (int z = 0; z < studentPapers.Tables[0].Rows.Count; z++)
                    {

                        // Will compare values in studentpapers dataset to the gridview making sure that the paper id matches
                        if (studentPapers.Tables[0].Rows[z][7].ToString() == gdvDatabase.Rows[i].Cells[0].Text)
                        {

                            paperIsComplete = true;
                        }
                    }

                    // If the paper has been completed use a class that will display that paper in bold
                    if (paperIsComplete)
                    {
                        ltlHtml.Text += "<button class='paper info_man complete' onclick='alert(\"You have completed this paper\")'>" + gdvDatabase.Rows[i].Cells[3].Text + "<br>" + gdvDatabase.Rows[i].Cells[2].Text;
                    }
                    else
                    {
                        // Add the paper id value to the button value

                        ltlHtml.Text += "<button type='submit' name='paper' value='" + gdvDatabase.Rows[i].Cells[0].Text + "' class='paper info_man' onclick='alert(\"Saving Feature - Not Implemented\")'>" + gdvDatabase.Rows[i].Cells[3].Text + "<br>" + gdvDatabase.Rows[i].Cells[2].Text;
                    }
                    //Finish

                    if (gdvDatabase.Rows[i].Cells[8].Text == "Yes")
                    {
                        ltlHtml.Text += "<br><b>Compulsory</b>";
                    }

                    ltlHtml.Text += "</button>";

                }

            }
            ltlHtml.Text += "</div>";
            ltlHtml.Text += "<div class='col-md-4'>";
            ltlHtml.Text += "<div class='alert alert-danger cat' role='alert'>Technology</div>";

            for (int i = 0; i < gdvDatabase.Rows.Count; i++)
            {
                if (gdvDatabase.Rows[i].Cells[4].Text == "Technology" && gdvDatabase.Rows[i].Cells[5].Text == "6")
                {

                    // Start 
                    // Testing to see if the paper has been completed or not, if it has it will add a border and bold the text.
                    bool paperIsComplete = false;
                    // This will filter the results to see if the paper is completed 
                    for (int z = 0; z < studentPapers.Tables[0].Rows.Count; z++)
                    {

                        // Will compare values in studentpapers dataset to the gridview making sure that the paper id matches
                        if (studentPapers.Tables[0].Rows[z][7].ToString() == gdvDatabase.Rows[i].Cells[0].Text)
                        {

                            paperIsComplete = true;
                        }
                    }

                    // If the paper has been completed use a class that will display that paper in bold
                    if (paperIsComplete)
                    {
                        ltlHtml.Text += "<button class='paper tech complete' onclick='alert(\"You have completed this paper\")'>" + gdvDatabase.Rows[i].Cells[3].Text + "<br>" + gdvDatabase.Rows[i].Cells[2].Text;
                    }
                    else
                    {
                        ltlHtml.Text += "<button class='paper tech' onclick='alert(\"Saving Feature - Not Implemented\")'>" + gdvDatabase.Rows[i].Cells[3].Text + "<br>" + gdvDatabase.Rows[i].Cells[2].Text;
                    }
                    //Finish

                    if (gdvDatabase.Rows[i].Cells[8].Text == "Yes")
                    {
                        ltlHtml.Text += "<br><b>Compulsory</b>";
                    }

                    ltlHtml.Text += "</button>";

                }

            }
            ltlHtml.Text += "</div>";
            ltlHtml.Text += "</div>";

            // 2nd year end

            // 3rd year loops start
            ltlHtml.Text += "<div class='row'>";
            ltlHtml.Text += "<div class='year_label'><span class='label label-primary'>Year 3</span></div>";
            ltlHtml.Text += "<div class='col-md-4'>";
            ltlHtml.Text += "<div class='alert alert-info cat' role='alert'>Software Development</div>";

            for (int i = 0; i < gdvDatabase.Rows.Count; i++)
            {
                if (gdvDatabase.Rows[i].Cells[4].Text == "Software Development" && gdvDatabase.Rows[i].Cells[5].Text == "7")
                {

                    // Start 
                    // Testing to see if the paper has been completed or not, if it has it will add a border and bold the text.
                    bool paperIsComplete = false;
                    // This will filter the results to see if the paper is completed 
                    for (int z = 0; z < studentPapers.Tables[0].Rows.Count; z++)
                    {

                        // Will compare values in studentpapers dataset to the gridview making sure that the paper id matches
                        if (studentPapers.Tables[0].Rows[z][7].ToString() == gdvDatabase.Rows[i].Cells[0].Text)
                        {

                            paperIsComplete = true;
                        }
                    }

                    // If the paper has been completed use a class that will display that paper in bold
                    if (paperIsComplete)
                    {
                        ltlHtml.Text += "<button class='paper s_dev complete' onclick='alert(\"You have completed this paper\")'>" + gdvDatabase.Rows[i].Cells[3].Text + "<br>" + gdvDatabase.Rows[i].Cells[2].Text;
                    }
                    else
                    {
                        ltlHtml.Text += "<button class='paper s_dev' onclick='alert(\"Saving Feature - Not Implemented\")'>" + gdvDatabase.Rows[i].Cells[3].Text + "<br>" + gdvDatabase.Rows[i].Cells[2].Text;
                    }
                    //Finish

                    if (gdvDatabase.Rows[i].Cells[8].Text == "Yes")
                    {
                        ltlHtml.Text += "<br><b>Compulsory</b>";
                    }

                    ltlHtml.Text += "</button>";

                }

            }
            ltlHtml.Text += "</div>";
            ltlHtml.Text += "<div class='col-md-4'>";
            ltlHtml.Text += "<div class='alert alert-warning cat' role='alert'>Information Management</div>";

            for (int i = 0; i < gdvDatabase.Rows.Count; i++)
            {
                if (gdvDatabase.Rows[i].Cells[4].Text == "Information Management" && gdvDatabase.Rows[i].Cells[5].Text == "7")
                {
                    

                    // Start 
                    // Testing to see if the paper has been completed or not, if it has it will add a border and bold the text.
                    bool paperIsComplete = false;
                    // This will filter the results to see if the paper is completed 
                    for (int z = 0; z < studentPapers.Tables[0].Rows.Count; z++)
                    {

                        // Will compare values in studentpapers dataset to the gridview making sure that the paper id matches
                        if (studentPapers.Tables[0].Rows[z][7].ToString() == gdvDatabase.Rows[i].Cells[0].Text)
                        {

                            paperIsComplete = true;
                        }
                    }

                    // If the paper has been completed use a class that will display that paper in bold
                    if (paperIsComplete)
                    {
                        ltlHtml.Text += "<button class='paper info_man complete' onclick='alert(\"You have completed this paper\")'>" + gdvDatabase.Rows[i].Cells[3].Text + "<br>" + gdvDatabase.Rows[i].Cells[2].Text;
                    }
                    else
                    {
                        ltlHtml.Text += "<button class='paper info_man' onclick='alert(\"Saving Feature - Not Implemented\")'>" + gdvDatabase.Rows[i].Cells[3].Text + "<br>" + gdvDatabase.Rows[i].Cells[2].Text;
                    }
                    //Finish

                    if (gdvDatabase.Rows[i].Cells[8].Text == "Yes")
                    {
                        ltlHtml.Text += "<br><b>Compulsory</b>";
                    }

                    ltlHtml.Text += "</button>";

                }

            }
            ltlHtml.Text += "</div>";
            ltlHtml.Text += "<div class='col-md-4'>";
            ltlHtml.Text += "<div class='alert alert-danger cat' role='alert'>Technology</div>";

            for (int i = 0; i < gdvDatabase.Rows.Count; i++)
            {
                if (gdvDatabase.Rows[i].Cells[4].Text == "Technology" && gdvDatabase.Rows[i].Cells[5].Text == "7")
                {
                    

                    // Start 
                    // Testing to see if the paper has been completed or not, if it has it will add a border and bold the text.
                    bool paperIsComplete = false;
                    // This will filter the results to see if the paper is completed 
                    for (int z = 0; z < studentPapers.Tables[0].Rows.Count; z++)
                    {

                        // Will compare values in studentpapers dataset to the gridview making sure that the paper id matches
                        if (studentPapers.Tables[0].Rows[z][7].ToString() == gdvDatabase.Rows[i].Cells[0].Text)
                        {

                            paperIsComplete = true;
                        }
                    }

                    // If the paper has been completed use a class that will display that paper in bold
                    if (paperIsComplete)
                    {
                        ltlHtml.Text += "<button class='paper tech complete' onclick='alert(\"You have completed this paper\")'>" + gdvDatabase.Rows[i].Cells[3].Text + "<br>" + gdvDatabase.Rows[i].Cells[2].Text;
                    }
                    else
                    {
                        ltlHtml.Text += "<button class='paper tech' onclick='alert(\"Saving Feature - Not Implemented\")'>" + gdvDatabase.Rows[i].Cells[3].Text + "<br>" + gdvDatabase.Rows[i].Cells[2].Text;
                    }
                    //Finish

                    if (gdvDatabase.Rows[i].Cells[8].Text == "Yes")
                    {
                        ltlHtml.Text += "<br><b>Compulsory</b>";
                    }

                    ltlHtml.Text += "</button>";

                }

            }
            ltlHtml.Text += "</div>";
            ltlHtml.Text += "</div>";

        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Session.Abandon();
            Response.Redirect("user_login_page.aspx");
        }


        // Testing Adding dynamic checkboxes
        CheckBox chkList1;
        private void AddCheckboxes(string strCheckboxText)
        {


            chkList1 = new CheckBox();
            chkList1.Text = strCheckboxText;
            chkList1.ID = "Chk" + strCheckboxText;
            chkList1.Font.Name = "Verdana";
            chkList1.Font.Size = 9;
            //chkList1.Attributes.Add("onclick", "alert('Testing')");

            form1.Controls.Add(chkList1);
            form1.Controls.Add(new LiteralControl("<br>"));


        }
    }
}