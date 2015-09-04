using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataTransferObject;
using DataAccessObject;
using System.Data;

namespace BusinessObjects
{
    public class BOReport
    {
        public int? GetStudentCountReport(DTOInstituteDetails toinst, string gender)
        {
            return new DAOReport().GetStudentCountReport(toinst, gender);
        }

        public List<DTOClasswiseCount> GetStudentCountClasswiseReport(DTOInstituteDetails toinst, string gender, int branchid)
        {
            return new DAOReport().GetStudentCountClasswiseReport(toinst, gender, branchid);
        }

        public List<DTOClasswiseCount> GetStudentAttendanceCountClasswiseReport(int? instituteid, string columnname, int branchid, string month, string year)
        {
            return new DAOReport().GetStudentAttendanceCountClasswiseReport(instituteid, columnname, branchid, month, year);
        }

        public List<DTOClasswiseCount> GetStudentInternalsCountClasswiseReport(int? instituteid, string columnname, int branchid, string month, string year, int subjectId)
        {
            return new DAOReport().GetStudentInternalsCountClasswiseReport(instituteid, columnname, branchid, month, year, subjectId);
        }
    }
}
