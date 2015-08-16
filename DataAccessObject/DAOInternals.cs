using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataTransferObject;
using System.Data;

namespace DataAccessObject
{
    public class DAOInternals
    {
        public DataTable GetStudentsList(DTOInternals toint)
        {
            Campus2CaretakerDataContext dbContext = new Campus2CaretakerDataContext();
            if (toint.SemesterId > 0)
            {
                return dbContext.GetStudentsInternalsDetailsNewEntry(toint.InstituteId,toint.SubjectId).Where(x => x.colBranchId == toint.BranchId && x.colSemesterId == toint.SemesterId && x.colMarksScored <= 0).ToDataTable();
            }
            return dbContext.GetStudentsInternalsDetailsNewEntry(toint.InstituteId, toint.SubjectId).Where(x => x.colBranchId == toint.BranchId && x.colMarksScored <= 0).ToDataTable();
        }

        public DataTable GetStudentsListEdit(DTOInternals toint)
        {
            Campus2CaretakerDataContext dbContext = new Campus2CaretakerDataContext();
            if (!string.IsNullOrEmpty(toint.Year) && !string.IsNullOrEmpty(toint.Month))
            {
                return dbContext.GetStudentsInternalsDetails(toint.InstituteId, toint.SubjectId).Where(x => x.colBranchId == toint.BranchId && x.colSemesterId == toint.SemesterId && x.colMonth == toint.Month && x.colYear == toint.Year && x.colMarksScored > 0).ToDataTable();
            }
            if (toint.SemesterId > 0)
            {
                return dbContext.GetStudentsInternalsDetails(toint.InstituteId, toint.SubjectId).Where(x => x.colBranchId == toint.BranchId && x.colSemesterId == toint.SemesterId && x.colMarksScored > 0).ToDataTable();
            }
            return dbContext.GetStudentsInternalsDetails(toint.InstituteId, toint.SubjectId).Where(x => x.colBranchId == toint.BranchId && x.colMarksScored > 0).ToDataTable();
        }

        public void SaveUpdateInternals(DTOInternals toInt)
        {
            Campus2CaretakerDataContext dbContext = new Campus2CaretakerDataContext();
            if (dbContext.tblInternalMarks.Where(x => x.colStudentId == toInt.StudentId && x.colMonth == toInt.Month && x.colYear == toInt.Year && x.colSubjectId == toInt.SubjectId).ToList().Count > 0)
            {
                tblInternalMark InternalMarks = dbContext.tblInternalMarks.Where(x => x.colStudentId == toInt.StudentId && x.colMonth == toInt.Month && x.colYear == toInt.Year && x.colSubjectId == toInt.SubjectId).FirstOrDefault();
                InternalMarks.colBranchId = toInt.BranchId;
                InternalMarks.colSemesterId = toInt.SemesterId;
                InternalMarks.colMonth = toInt.Month;
                InternalMarks.colYear = toInt.Year;
                InternalMarks.colInstituteId = toInt.InstituteId;
                InternalMarks.colMarksScored = toInt.MarksScored;
                InternalMarks.colMaxMarks = toInt.MaxMarks;
                InternalMarks.colMinMarks = toInt.MinMarks;
                InternalMarks.colStudentId = toInt.StudentId;
                InternalMarks.colSubjectId = toInt.SubjectId;

                dbContext.SubmitChanges();
            }
            else
            {
                tblInternalMark InternalMarks = new tblInternalMark();
                InternalMarks.colBranchId = toInt.BranchId;
                InternalMarks.colSemesterId = toInt.SemesterId;
                InternalMarks.colMonth = toInt.Month;
                InternalMarks.colYear = toInt.Year;
                InternalMarks.colInstituteId = toInt.InstituteId;
                InternalMarks.colMarksScored = toInt.MarksScored;
                InternalMarks.colMaxMarks = toInt.MaxMarks;
                InternalMarks.colMinMarks = toInt.MinMarks;
                InternalMarks.colStudentId = toInt.StudentId;
                InternalMarks.colSubjectId = toInt.SubjectId;

                dbContext.tblInternalMarks.InsertOnSubmit(InternalMarks);
                dbContext.SubmitChanges();
            }

        }

        public DataTable GetInternalsChartDetails(DTOInternals toint)
        {
            using (Campus2CaretakerDataContext dbContext = new Campus2CaretakerDataContext())
            {
                int _year = int.Parse(toint.Year);
                return dbContext.GetBarChartInternalsDetails(toint.InstituteId, toint.Month, _year).ToDataTable();
            }
        }
    }
}
