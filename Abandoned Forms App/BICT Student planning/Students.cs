using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BICT_Student_planning
{
    public class Students
    {
        private int user_id;
        private string user_name;
        private string first_name;
        private string last_name;
        private string address;
        private int phone;
        private string email;
        private string otherDetails;

        public int User_id
        {
            get
            {
                return user_id;
            }

            set
            {
                user_id = value;
            }
        }

        public string User_name
        {
            get
            {
                return user_name;
            }

            set
            {
                user_name = value;
            }
        }

        public string First_name
        {
            get
            {
                return first_name;
            }

            set
            {
                first_name = value;
            }
        }

        public string Last_name
        {
            get
            {
                return last_name;
            }

            set
            {
                last_name = value;
            }
        }

        public string Address
        {
            get
            {
                return address;
            }

            set
            {
                address = value;
            }
        }

        public int Phone
        {
            get
            {
                return phone;
            }

            set
            {
                phone = value;
            }
        }

        public string Email
        {
            get
            {
                return email;
            }

            set
            {
                email = value;
            }
        }

        public string OtherDetails
        {
            get
            {
                return otherDetails;
            }

            set
            {
                otherDetails = value;
            }
        }
    }
}
