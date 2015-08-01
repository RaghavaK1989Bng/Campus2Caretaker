﻿using System;
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
           if(toint.SemesterId > 0)
           {
               return dbContext.GetStudentsInternalsDetails(toint.InstituteId).Where(x => x.colBranchId == toint.BranchId && x.colSemesterId == toint.SemesterId).ToDataTable();
           }
           return dbContext.GetStudentsInternalsDetails(toint.InstituteId).Where(x => x.colBranchId == toint.BranchId).ToDataTable();
       }

       public DataTable GetStudentsListEdit(DTOInternals toint)
       {
           Campus2CaretakerDataContext dbContext = new Campus2CaretakerDataContext();
           if (!string.IsNullOrEmpty(toint.Year) && !string.IsNullOrEmpty(toint.Month))
           {
               return dbContext.GetStudentsInternalsDetails(toint.InstituteId).Where(x => x.colBranchId == toint.BranchId && x.colSemesterId == toint.SemesterId && x.colMonth == toint.Month && x.colYear == toint.Year).ToDataTable();
           }
           if (toint.SemesterId > 0)
           {
               return dbContext.GetStudentsInternalsDetails(toint.InstituteId).Where(x => x.colBranchId == toint.BranchId && x.colSemesterId == toint.SemesterId).ToDataTable();
           }
           return dbContext.GetStudentsInternalsDetails(toint.InstituteId).Where(x => x.colBranchId == toint.BranchId).ToDataTable();
       }

       public void SaveUpdateInternals(DTOInternals toInt)
       {
           Campus2CaretakerDataContext dbContext = new Campus2CaretakerDataContext();
          if(dbContext.tblInternalMarks.Where(x => x.colStudentId == toInt.StudentId && x.colMonth == toInt.Month && x.colYear == toInt.Year).ToList().Count > 0)
          {
              tblInternalMark InternalMarks = dbContext.tblInternalMarks.Where(x => x.colStudentId == toInt.StudentId && x.colMonth == toInt.Month && x.colYear == toInt.Year).FirstOrDefault();
              InternalMarks.colBranchId = toInt.BranchId;
              InternalMarks.colSemesterId = toInt.SemesterId;
              InternalMarks.colMonth = toInt.Month;
              InternalMarks.colYear = toInt.Year;
              InternalMarks.colInstituteId = toInt.InstituteId;
              InternalMarks.colMarksScored = toInt.MarksScored;
              InternalMarks.colMaxMarks = toInt.MaxMarks;
              InternalMarks.colMinMarks = toInt.MinMarks;
              InternalMarks.colStudentId = toInt.StudentId;

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

              dbContext.tblInternalMarks.InsertOnSubmit(InternalMarks);
              dbContext.SubmitChanges();
          }

       }
    }
}
