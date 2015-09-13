using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccessObject;
using DataTransferObject;
using System.Data;

namespace BusinessObjects
{
    public class BOAttendance
    {
        public DataTable GetStudentsList(DTOAttendance toAtt)
        {
            return new DAOAttendance().GetStudentsList(toAtt);
        }

        public bool SaveUpdateAttendance(DTOAttendance toAtt)
        {
           return new DAOAttendance().SaveUpdateAttendance(toAtt);
        }

        public DataTable GetStudentsListEdit(DTOAttendance toAtt)
        {
            return new DAOAttendance().GetStudentsListEdit(toAtt);
        }
    }
}
