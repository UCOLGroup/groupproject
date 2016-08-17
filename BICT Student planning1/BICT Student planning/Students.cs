using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BICT_Student_planning
{
    class Students
    {
        private int userID;
        private string UserName;
        private string Address;
        private int Phone;
        private string Email;
        private string OtherDetails;

        public int UserID
        {
            get
            {
                return userID;
            }

            set
            {
                userID = value;
            }
        }
    }
}
