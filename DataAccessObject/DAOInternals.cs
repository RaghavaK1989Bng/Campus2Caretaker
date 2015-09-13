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
                return dbContext.GetStudentsInternalsDetailsNewEntry(toint.InstituteId,
                                                                     toint.SubjectId,
                                                                     toint.Month,
                                                                     toint.Year,
                                                                     toint.SemesterId,
                                                                     toint.BranchId).ToDataTable();
            }
            // create stored procedure for schools without semester
            return dbContext.GetStudentsInternalsDetailsNewEntry(toint.InstituteId,
                                                                     toint.SubjectId,
                                                                     toint.Month,
                                                                     toint.Year,
                                                                     0,
                                                                     toint.BranchId).ToDataTable();
        }

        public DataTable GetStudentsListEdit(DTOInternals toint)
        {
            Campus2CaretakerDataContext dbContext = new Campus2CaretakerDataContext();
            if (toint.SemesterId > 0)
            {
                return dbContext.GetStudentsInternalsDetailsEdit(toint.InstituteId,
                                                                 toint.SubjectId,
                                                                 toint.Month,
                                                                 toint.Year,
                                                                 toint.SemesterId,
                                                                 toint.BranchId).ToDataTable();
            }
            // create stored procedure for schools without semester
            return dbContext.GetStudentsInternalsDetailsEdit(toint.InstituteId,
                                                                 toint.SubjectId,
                                                                 toint.Month,
                                                                 toint.Year,
                                                                 0,
                                                                 toint.BranchId).ToDataTable();
        }

        public bool SaveUpdateInternals(DTOInternals toInt)
        {
            Campus2CaretakerDataContext dbContext = new Campus2CaretakerDataContext();
            try
            {
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
                    InternalMarks.colRemarks = toInt.Remarks;
                    InternalMarks.colDescription = toInt.Description;

                    dbContext.SubmitChanges();
                    return true;
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
                    InternalMarks.colRemarks = toInt.Remarks;
                    InternalMarks.colDescription = toInt.Description;

                    dbContext.tblInternalMarks.InsertOnSubmit(InternalMarks);
                    dbContext.SubmitChanges();
                    return true;
                }
            }
            catch
            {
                return false;
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
