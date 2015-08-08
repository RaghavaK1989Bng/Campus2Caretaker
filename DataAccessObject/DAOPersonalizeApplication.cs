using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using DataTransferObject;

namespace DataAccessObject
{
    public class DAOPersonalizeApplication
    {
        public DataTable GetClassesList(string _pInstituteId)
        {
            int InstituteId = int.Parse(_pInstituteId);
            Campus2CaretakerDataContext dbContext = new Campus2CaretakerDataContext();
            return dbContext.tblBranchDetails.Where(x => x.colInstituteId == InstituteId).ToDataTable();
        }

        public DataTable GetSubjectsList(string _pInstituteId)
        {
            int InstituteId = int.Parse(_pInstituteId);
            Campus2CaretakerDataContext dbContext = new Campus2CaretakerDataContext();
            var res = (from s in dbContext.tblSubjectDetails
                       join c in dbContext.tblBranchDetails on s.colBranchId equals c.colBranchId
                       where s.colInstituteId == InstituteId
                       select s);
            return res.ToDataTable();

        }

        public DataTable GetSubjectsList(string _pInstituteId, int classId)
        {
            int InstituteId = int.Parse(_pInstituteId);
            Campus2CaretakerDataContext dbContext = new Campus2CaretakerDataContext();
            var res = (from s in dbContext.tblSubjectDetails
                       join c in dbContext.tblBranchDetails on s.colBranchId equals c.colBranchId
                       where s.colInstituteId == InstituteId && s.colBranchId == classId
                       select s);
            return res.ToDataTable();

        }

        public bool SaveClasses(DTOPersonalizeApplication DTOPApplication)
        {
            try
            {
                Campus2CaretakerDataContext dbContext = new Campus2CaretakerDataContext();

                foreach (string _classname in DTOPApplication.Classes)
                {
                    tblBranchDetail brnchDetail = new tblBranchDetail();
                    brnchDetail.colBranchName = _classname;
                    brnchDetail.colInstituteId = DTOPApplication.InstituteId;
                    dbContext.tblBranchDetails.InsertOnSubmit(brnchDetail);
                }
                dbContext.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool SaveSubjects(DTOPersonalizeApplication DTOPApplication)
        {
            try
            {
                Campus2CaretakerDataContext dbContext = new Campus2CaretakerDataContext();

                foreach (string _theorysubject in DTOPApplication.TheorySubjects)
                {
                    tblSubjectDetail subjDetail = new tblSubjectDetail();
                    subjDetail.colBranchId = DTOPApplication.ClassId;
                    subjDetail.colInstituteId = DTOPApplication.InstituteId;
                    subjDetail.colIsTheory = "Y";
                    subjDetail.colSubjectName = _theorysubject;
                    subjDetail.colSemester = DTOPApplication.Semester;
                    dbContext.tblSubjectDetails.InsertOnSubmit(subjDetail);
                }

                foreach (string _labsubject in DTOPApplication.LabSubjects)
                {
                    tblSubjectDetail subjDetail = new tblSubjectDetail();
                    subjDetail.colBranchId = DTOPApplication.ClassId;
                    subjDetail.colInstituteId = DTOPApplication.InstituteId;
                    subjDetail.colIsTheory = "N";
                    subjDetail.colSubjectName = _labsubject;
                    subjDetail.colSemester = DTOPApplication.Semester;
                    dbContext.tblSubjectDetails.InsertOnSubmit(subjDetail);
                }

                dbContext.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
