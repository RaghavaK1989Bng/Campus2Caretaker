using DataTransferObject;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace DataAccessObject
{
    public class DAOReport
    {

        public int? GetStudentCountReport(DTOInstituteDetails toinst, string gender)
        {
            using (Campus2CaretakerDataContext dbcontext = new Campus2CaretakerDataContext())
            {
                return (dbcontext.GetStudentCount(toinst.InstituteID)).Where(t => t.Gender == gender).Select(x => x.TotalCount).FirstOrDefault();
            }
        }

        public List<DTOClasswiseCount> GetStudentCountClasswiseReport(DTOInstituteDetails toinst, string gender, int branchid)
        {
            Campus2CaretakerDataContext dbcontext = new Campus2CaretakerDataContext();

            return (from v in dbcontext.GetStudentCountClasswiseGender(toinst.InstituteID)
                    where v.Gender == gender && v.colBranchId == branchid
                    select new DTOClasswiseCount
                    {
                        Count = v.TotalCount,
                        ClassName = v.colBranchName
                    }).ToList();
        }

        public List<DTOClasswiseCount> GetStudentAttendanceCountClasswiseReport(int? instituteid, string columnname, int branchid, string month, string year)
        {
            Campus2CaretakerDataContext dbcontext = new Campus2CaretakerDataContext();

            return (from v in dbcontext.GetStudentsAttendanceDetailsMonthwise(instituteid, month, year)
                    where v.columnname == columnname && v.colBranchId == branchid
                    select new DTOClasswiseCount
                    {
                        Count = v.AttendanceCount,
                        ClassName = v.colBranchName
                    }).ToList();
        }

        public List<DTOClasswiseCount> GetStudentInternalsCountClasswiseReport(int? instituteid, string columnname, int branchid, string month, string year,int subjectId)
        {
            Campus2CaretakerDataContext dbcontext = new Campus2CaretakerDataContext();

            return (from v in dbcontext.GetStudentsMarksDetailsMonthwise(instituteid, month, year)
                    where v.columnname == columnname && v.colBranchId == branchid && v.colSubjectId == subjectId
                    select new DTOClasswiseCount
                    {
                        Count = v.MarksScoredCount,
                        ClassName = v.colBranchName,
                        SubjectName = v.colSubjectName
                    }).ToList();
        }
    }
}
