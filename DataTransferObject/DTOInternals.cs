using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataTransferObject
{
    public class DTOInternals
    {
        private int _instituteId;

        public int InstituteId
        {
            get { return _instituteId; }
            set { _instituteId = value; }
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

        private string _section;

        public string Section
        {
            get { return _section; }
            set { _section = value; }
        }

        private int _studentId;

        public int StudentId
        {
            get { return _studentId; }
            set { _studentId = value; }
        }

        private string month;

        public string Month
        {
            get { return month; }
            set { month = value; }
        }
        private string year;

        public string Year
        {
            get { return year; }
            set { year = value; }
        }
        private decimal maxMarks;

        public decimal MaxMarks
        {
            get { return maxMarks; }
            set { maxMarks = value; }
        }
        private decimal minMarks;

        public decimal MinMarks
        {
            get { return minMarks; }
            set { minMarks = value; }
        }
        private decimal marksScored;

        public decimal MarksScored
        {
            get { return marksScored; }
            set { marksScored = value; }
        }
    }
}
