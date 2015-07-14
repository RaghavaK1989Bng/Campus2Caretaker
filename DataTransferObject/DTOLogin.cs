using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataTransferObject
{
    public class DTOLogin
    {
        private string userid;
        public string UserID
        {
            get { return userid; }
            set { userid = value; }
        }

        private string password;
        public string Password
        {
            get { return password; }
            set { password = value; }
        }
    }
}
