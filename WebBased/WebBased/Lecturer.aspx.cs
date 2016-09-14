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
            if (Session["USER_ID"] != null)
            {

                OleDbConnection connection = new OleDbConnection();

                connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\Student_Papers.accdb;
            Persist Security Info = False;";

                connection.Open();

                OleDbCommand command = new OleDbCommand();

                command.Connection = connection;

                command.CommandText = "Select * FROM lecturers WHERE user_name = '" + Session["USER_ID"].ToString() + "'"; //

                OleDbDataReader reader = command.ExecuteReader();

                reader.Read();

                TextBox1.Text = reader["lecturer_id"].ToString();

                if (lblWelcome.Text == "Welcome")
                {
                    lblWelcome.Text += " " + reader["first_name"].ToString() + " " + reader["last_name"].ToString();
                }

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
            else
            {
                Response.Redirect("User_Login_Page.aspx");
            }
        


                if (!this.IsPostBack)
            {
                //Attribute to show the Plus Minus Button.
                GridView1.HeaderRow.Cells[0].Attributes["data-class"] = "expand";

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
            Session.Clear();
            Session.Abandon();
            Response.Redirect("user_login_page.aspx");
        }
    }
}