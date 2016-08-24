using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BICT_Student_planning
{
    public partial class Student_Course : Form
    {
        string username = "";
        public Student_Course(Students student)
        {
            InitializeComponent();
            lblWelcomeUserName.Text = student.User_name;
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Student_Course_Load(object sender, EventArgs e)
        {
            FrmBICTLogin fm1 = new FrmBICTLogin();
            
        }
    }
    }
