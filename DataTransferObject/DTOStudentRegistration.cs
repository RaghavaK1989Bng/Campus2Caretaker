using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataTransferObject
{
    public class DTOStudentRegistration
    {
       private int _instituteId;

        public int InstituteId
        {
            get { return _instituteId; }
            set { _instituteId = value; }
        }

        private string _studentName;
        public string StudentName
        {
            get { return _studentName; }
            set { _studentName = value; }
        }

        private string _fatherName;
        public string FatherName
        {
            get { return _fatherName; }
            set { _fatherName = value; }
        }

        private string _motherName;
        public string MotherName
        {
            get { return _motherName; }
            set { _motherName = value; }
        }

        private string _lastName;
        public string LastName
        {
            get { return _lastName; }
            set { _lastName = value; }
        }

        private DateTime _dob;
        public DateTime DOB
        {
            get { return _dob; }
            set { _dob = value; }
        }

        private int _semesterId;

        public int SemesterId
        {
            get { return _semesterId; }
            set { _semesterId = value; }
        }

        private int _branchId;

        public int BranchId
        {
            get { return _branchId; }
            set { _branchId = value; }
        }

        private int _sectionId;

        public int SectionId
        {
            get { return _sectionId; }
            set { _sectionId = value; }
        }

        private string _rollNo;

        public string RollNo
        {
            get { return _rollNo; }
            set { _rollNo = value; }
        }

        private string _parentsMobileNo;

        public string ParentsMobileNo
        {
            get { return _parentsMobileNo; }
            set { _parentsMobileNo = value; }
        }

        private int _studentId;

        public int StudentId
        {
            get { return _studentId; }
            set { _studentId = value; }
        }

        private string _address;
        public string Address
        {
            get { return _address; }
            set { _address = value; }
        }
    }
}
