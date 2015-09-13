using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataTransferObject;
using System.Data;

namespace DataAccessObject
{
   public class DAOAttendance
    {
       public DataTable GetStudentsList(DTOAttendance toAtt)
       {
           Campus2CaretakerDataContext dbContext = new Campus2CaretakerDataContext();
           if(toAtt.SemesterId > 0)
           {
               string _year = toAtt.Year.ToString();
               return dbContext.GetStudentsAttendanceDetailsNewEntry(toAtt.InstituteId,
                                                                     toAtt.SubjectId,
                                                                     toAtt.Month,
                                                                     _year,
                                                                     toAtt.SemesterId,
                                                                     toAtt.BranchId).ToDataTable();

           }
           throw new NotImplementedException();
       }

       public DataTable GetStudentsListEdit(DTOAttendance toAtt)
       {
           Campus2CaretakerDataContext dbContext = new Campus2CaretakerDataContext();
           
           if (toAtt.SemesterId > 0)
           {
               string _year = toAtt.Year.ToString();
               return dbContext.GetStudentsAttendanceDetailsEdit(toAtt.InstituteId,
                                                                     toAtt.SubjectId,
                                                                     toAtt.Month,
                                                                     _year,
                                                                     toAtt.SemesterId,
                                                                     toAtt.BranchId).ToDataTable();
           }
           throw new NotImplementedException();
       }

       public bool SaveUpdateAttendance(DTOAttendance toAtt)
       {
           Campus2CaretakerDataContext dbContext = new Campus2CaretakerDataContext();
           try
           {
               if (dbContext.tblAttendanceDetails.Where(x => x.colStudentId == toAtt.StudentId && x.colMonth == toAtt.Month && x.colYear == toAtt.Year).ToList().Count > 0)
               {
                   tblAttendanceDetail Attendance = dbContext.tblAttendanceDetails.Where(x => x.colStudentId == toAtt.StudentId && x.colMonth == toAtt.Month && x.colYear == toAtt.Year).FirstOrDefault();
                   Attendance.colBranchId = toAtt.BranchId;
                   Attendance.colSemesterId = toAtt.SemesterId;
                   Attendance.colMonth = toAtt.Month;
                   Attendance.colYear = toAtt.Year;
                   Attendance.colInstituteId = toAtt.InstituteId;
                   Attendance.colClassesAttendedMonth = toAtt.ClassesAttended;
                   Attendance.colClassesAttendedMonthPercent = toAtt.ClassesPercentage;
                   Attendance.colClassesHeldMonth = toAtt.ClassesHeld;
                   Attendance.colAccumulatedClassesAttended = toAtt.CumClassesAttended;
                   Attendance.colAccumulatedClassesHeld = toAtt.CumClassesHeld;
                   Attendance.colAccumulatedClassesAttendedPercent = toAtt.CumClassesPercentage;
                   Attendance.colStudentId = toAtt.StudentId;
                   Attendance.colSubjectId = toAtt.SubjectId;
                   Attendance.colRemarks = toAtt.Remarks;
                   Attendance.colDescription = toAtt.Description;

                   dbContext.SubmitChanges();
                   return true;
               }
               else
               {
                   tblAttendanceDetail Attendance = new tblAttendanceDetail();
                   Attendance.colBranchId = toAtt.BranchId;
                   Attendance.colSemesterId = toAtt.SemesterId;
                   Attendance.colMonth = toAtt.Month;
                   Attendance.colYear = toAtt.Year;
                   Attendance.colInstituteId = toAtt.InstituteId;
                   Attendance.colClassesAttendedMonth = toAtt.ClassesAttended;
                   Attendance.colClassesAttendedMonthPercent = toAtt.ClassesPercentage;
                   Attendance.colClassesHeldMonth = toAtt.ClassesHeld;
                   Attendance.colAccumulatedClassesAttended = toAtt.CumClassesAttended;
                   Attendance.colAccumulatedClassesHeld = toAtt.CumClassesHeld;
                   Attendance.colAccumulatedClassesAttendedPercent = toAtt.CumClassesPercentage;
                   Attendance.colStudentId = toAtt.StudentId;
                   Attendance.colSubjectId = toAtt.SubjectId;
                   Attendance.colRemarks = toAtt.Remarks;
                   Attendance.colDescription = toAtt.Description;

                   dbContext.tblAttendanceDetails.InsertOnSubmit(Attendance);
                   dbContext.SubmitChanges();
                   return true;
               }
           }
           catch
           {
               return false;
           }
       }
    }
}
