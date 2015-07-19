using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataTransferObject
{
    public class DTOStudentRegistration
    {
        private int _classId;

        public int ClassId
        {
            get { return _classId; }
            set { _classId = value; }
        }

        private int _instituteId;

        public int InstituteId
        {
            get { return _instituteId; }
            set { _instituteId = value; }
        }
    }
}
