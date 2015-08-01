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
               return dbContext.GetStudentsAttendanceDetails(toAtt.InstituteId).Where(x => x.colBranchId == toAtt.BranchId && x.colSemesterId == toAtt.SemesterId).ToDataTable();
           }
           return dbContext.GetStudentsAttendanceDetails(toAtt.InstituteId).Where(x => x.colBranchId == toAtt.BranchId).ToDataTable();
       }

       public DataTable GetStudentsListEdit(DTOAttendance toAtt)
       {
           Campus2CaretakerDataContext dbContext = new Campus2CaretakerDataContext();
           if (toAtt.Year != 0 && !string.IsNullOrEmpty(toAtt.Month))
           {
               return dbContext.GetStudentsAttendanceDetails(toAtt.InstituteId).Where(x => x.colBranchId == toAtt.BranchId && x.colSemesterId == toAtt.SemesterId && x.colMonth == toAtt.Month && x.colYear == toAtt.Year).ToDataTable();
           }
           if (toAtt.SemesterId > 0)
           {
               return dbContext.GetStudentsAttendanceDetails(toAtt.InstituteId).Where(x => x.colBranchId == toAtt.BranchId && x.colSemesterId == toAtt.SemesterId).ToDataTable();
           }
           return dbContext.GetStudentsAttendanceDetails(toAtt.InstituteId).Where(x => x.colBranchId == toAtt.BranchId).ToDataTable();
       }

       public void SaveUpdateAttendance(DTOAttendance toAtt)
       {
           Campus2CaretakerDataContext dbContext = new Campus2CaretakerDataContext();
          if(dbContext.tblAttendanceDetails.Where(x => x.colStudentId == toAtt.StudentId && x.colMonth == toAtt.Month && x.colYear == toAtt.Year).ToList().Count > 0)
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

              dbContext.SubmitChanges();
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

              dbContext.tblAttendanceDetails.InsertOnSubmit(Attendance);
              dbContext.SubmitChanges();
          }

       }
    }
}
