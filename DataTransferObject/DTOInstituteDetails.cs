using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataTransferObject
{
   public class DTOInstituteDetails
    {
        private int instituteid;
        public int InstituteID
        {
            get { return instituteid; }
            set { instituteid = value; }
        }

        private string institutename;
        public string InstituteName
        {
            get { return institutename; }
            set { institutename = value; }
        }

        private string instituteaddress;
        public string InstituteAddress
        {
            get { return instituteaddress; }
            set { instituteaddress = value; }
        }

        private string institutephoneno;
        public string InstitutePhoneNo
        {
            get { return institutephoneno; }
            set { institutephoneno = value; }
        }

        private string logopath;
        public string LogoPath
        {
            get { return logopath; }
            set { logopath = value; }
        }

        private string principalname;
        public string PrincipalName
        {
            get { return principalname; }
            set { principalname = value; }
        }

        private string principalcontact;
        public string PrincipalContact
        {
            get { return principalcontact; }
            set { principalcontact = value; }
        }

        private string institutetype;
        public string InstituteType
        {
            get { return institutetype; }
            set { institutetype = value; }
        }

        private string instituteemail;
        public string InstituteEmail
        {
            get { return instituteemail; }
            set { instituteemail = value; }
        }

        private string institutedefaultpwd;
        public string InstituteDefaultPwd
        {
            get { return institutedefaultpwd; }
            set { institutedefaultpwd = value; }
        }

        private string instituteusertype;
        public string InstituteUserType
        {
            get { return instituteusertype; }
            set { instituteusertype = value; }
        }

        private string district;
        public string District
        {
            get { return district; }
            set { district = value; }
        }

        private string state;
        public string State
        {
            get { return state; }
            set { state = value; }
        }
    }
}
