using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataTransferObject
{
    public class DTOAttendance
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
        private int year;

        public int Year
        {
            get { return year; }
            set { year = value; }
        }
        
        private decimal classesHeld;

        public decimal ClassesHeld
        {
            get { return classesHeld; }
            set { classesHeld = value; }
        }
        private decimal classesAttended;

        public decimal ClassesAttended
        {
            get { return classesAttended; }
            set { classesAttended = value; }
        }
        private decimal classesPercentage;

        public decimal ClassesPercentage
        {
            get { return classesPercentage; }
            set { classesPercentage = value; }
        }

        private decimal cumClassesHeld;

        public decimal CumClassesHeld
        {
            get { return cumClassesHeld; }
            set { cumClassesHeld = value; }
        }
        private decimal cumClassesAttended;

        public decimal CumClassesAttended
        {
            get { return cumClassesAttended; }
            set { cumClassesAttended = value; }
        }
        private decimal cumClassesPercentage;

        public decimal CumClassesPercentage
        {
            get { return cumClassesPercentage; }
            set { cumClassesPercentage = value; }
        }
    }
}
