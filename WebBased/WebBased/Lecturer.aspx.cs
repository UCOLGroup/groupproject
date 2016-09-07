using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace WebBased
{
    public partial class Lecturer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
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
    }
}