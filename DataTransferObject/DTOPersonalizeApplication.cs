using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataTransferObject
{
   public class DTOPersonalizeApplication
    {
        private int _classId;

        public int ClassId
        {
            get { return _classId; }
            set { _classId = value; }
        }

        private string[] _classes;

        public string[] Classes
        {
            get { return _classes; }
            set { _classes = value; }
        }

        private int _instituteId;

        public int InstituteId
        {
            get { return _instituteId; }
            set { _instituteId = value; }
        }

        private string[] _theorysubjects;

        public string[] TheorySubjects
        {
            get { return _theorysubjects; }
            set { _theorysubjects = value; }
        }

        private string[] _labsubjects;

        public string[] LabSubjects
        {
            get { return _labsubjects; }
            set { _labsubjects = value; }
        }

        private string _semester;

        public string Semester
        {
            get { return _semester; }
            set { _semester = value; }
        }
    }
}
