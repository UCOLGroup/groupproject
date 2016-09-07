using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebBased.Models;

namespace WebBased
{
    public partial class Students_Course : System.Web.UI.Page
    {  

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
        }
    }
}