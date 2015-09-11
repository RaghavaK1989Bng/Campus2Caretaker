using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataTransferObject
{
    public class DTOParentsLoginDetails
    {
        private string _mobilenumber;

        public string Mobilenumber
        {
            get { return _mobilenumber; }
            set { _mobilenumber = value; }
        }
        private string _otp;

        public string Otp
        {
            get { return _otp; }
            set { _otp = value; }
        }
        private int _isused;

        public int Isused
        {
            get { return _isused; }
            set { _isused = value; }
        }



    }
}
