using DataTransferObject;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace DataAccessObject
{
    public class DAOStudentRegistration
    {
        public DataTable GetClassesList(string _pInstituteId)
        {
            int InstituteId = int.Parse(_pInstituteId);
            Campus2CaretakerDataContext dbContext = new Campus2CaretakerDataContext();
            return dbContext.tblBranchDetails.Where(x => x.colInstituteId == InstituteId).ToDataTable();
        }

        public DataTable GetStudentsList(string _pInstituteId)
        {
            int InstituteId = int.Parse(_pInstituteId);
            Campus2CaretakerDataContext dbContext = new Campus2CaretakerDataContext();
            return dbContext.tblStudentDetails.Where(x => x.colInstituteId == InstituteId).ToDataTable();
        }

        public bool SaveStudentDetails(DTOStudentRegistration tostudentreg)
        {
            try
            {
                Campus2CaretakerDataContext dbContext = new Campus2CaretakerDataContext();

                tblStudentDetail studDetail = new tblStudentDetail();
                studDetail.colStudentName = tostudentreg.StudentName;
                studDetail.colLastName = tostudentreg.LastName;
                studDetail.colAddress = tostudentreg.Address;
                studDetail.colFatherName = tostudentreg.FatherName;
                studDetail.colMotherName = tostudentreg.MotherName;
                studDetail.colDOB = tostudentreg.DOB;
                studDetail.colSemesterId = tostudentreg.SemesterId;
                studDetail.colBranchId = tostudentreg.BranchId;
                studDetail.colSection = tostudentreg.Section;
                studDetail.colRollNo = tostudentreg.RollNo;
                studDetail.colParentsMobileNo = tostudentreg.ParentsMobileNo;
                studDetail.colParentsEmail = tostudentreg.ParentsEmail;
                studDetail.colInstituteId = tostudentreg.InstituteId;
                studDetail.colGender = tostudentreg.Gender;

                dbContext.tblStudentDetails.InsertOnSubmit(studDetail);
                dbContext.SubmitChanges();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public string GetBranchId(string BranchName)
        {
            try
            {
                Campus2CaretakerDataContext db = new Campus2CaretakerDataContext();
                var BranchData = db.tblBranchDetails.Where(x => x.colBranchName == BranchName).First();
                return BranchData.colBranchId.ToString();
            }
            catch (Exception ex)
            {
                return string.Empty;
            }
        }

        public bool SaveStudentRegistrationExcel(DataTable dt, string instituteId)
        {
            try
            {
                System.Data.Common.DbTransaction trans = null;
                using (Campus2CaretakerDataContext db = new Campus2CaretakerDataContext())
                {
                    db.Connection.Open();
                    trans = db.Connection.BeginTransaction();
                    db.Transaction = trans;
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        tblStudentDetail table = new tblStudentDetail
                            {
                                colStudentName = dt.Rows[i][0].ToString(),
                                colLastName = dt.Rows[i][1].ToString(),
                                colFatherName = dt.Rows[i][2].ToString(),
                                colMotherName = dt.Rows[i][3].ToString(),
                                colDOB = DateTime.Parse(dt.Rows[i][4].ToString()),
                                colSemesterId = int.Parse(dt.Rows[i][5].ToString()),
                                colBranchId = int.Parse(dt.Rows[i][6].ToString()),
                                colSection = dt.Rows[i][7].ToString(),
                                colRollNo = dt.Rows[i][8].ToString(),
                                colParentsMobileNo = dt.Rows[i][9].ToString(),
                                colAddress = dt.Rows[i][10].ToString(),
                                colInstituteId = int.Parse(instituteId),
                                colGender = dt.Rows[i][11].ToString(),
                                colParentsEmail = dt.Rows[i][12].ToString(),
                            };
                        db.tblStudentDetails.InsertOnSubmit(table);
                        try
                        {
                            db.SubmitChanges();
                        }
                        catch
                        {
                            if (trans != null)
                                trans.Rollback();
                            if (db.Connection.State == ConnectionState.Open)
                                db.Connection.Close();
                            return false;
                        }
                    }
                    trans.Commit();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        public DataTable GetStudentDetails(DTOStudentRegistration tostu)
        {
            using (Campus2CaretakerDataContext dbcontext = new Campus2CaretakerDataContext())
            {
                return (dbcontext.GetStudentDetails(tostu.StudentId)).ToDataTable();
            }
        }

        public bool UpdateStudentDetails(DTOStudentRegistration tostud)
        {
            try
            {
                Campus2CaretakerDataContext dbContext = new Campus2CaretakerDataContext();

                // Student Details

                tblStudentDetail studDetail = dbContext.tblStudentDetails.Where(x => x.colStudentId == tostud.StudentId).FirstOrDefault();
                studDetail.colStudentName = tostud.StudentName;
                studDetail.colLastName = tostud.LastName;
                studDetail.colAddress = tostud.Address;
                studDetail.colFatherName = tostud.FatherName;
                studDetail.colMotherName = tostud.MotherName;
                studDetail.colDOB = tostud.DOB;
                studDetail.colSemesterId = tostud.SemesterId;
                studDetail.colBranchId = tostud.BranchId;
                studDetail.colSection = tostud.Section;
                studDetail.colRollNo = tostud.RollNo;
                studDetail.colParentsMobileNo = tostud.ParentsMobileNo;
                studDetail.colParentsEmail = tostud.ParentsEmail;
                studDetail.colInstituteId = tostud.InstituteId;
                studDetail.colGender = tostud.Gender;

                dbContext.SubmitChanges();
                return true;
            }
            catch { return false; }
        }


        public bool DeleteStudentDetails(DTOStudentRegistration tostu)
        {
            try
            {
                Campus2CaretakerDataContext dbContext = new Campus2CaretakerDataContext();

                // Institute Details

                tblStudentDetail StudDetail = dbContext.tblStudentDetails.Where(x => x.colStudentId == tostu.StudentId).FirstOrDefault();
                dbContext.tblStudentDetails.DeleteOnSubmit(StudDetail);
                dbContext.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<DTOStudentRegistration> GetAutoCompleteStudentNames(string reqString)
        {
            Campus2CaretakerDataContext dbcontext = new Campus2CaretakerDataContext();
            if (!string.IsNullOrEmpty(reqString))
            {
                return (from v in dbcontext.tblStudentDetails
                        where v.colStudentName.ToLower().Contains(reqString.ToLower())
                        select new DTOStudentRegistration
                        {
                            StudentName = v.colStudentName,
                            StudentId = v.colStudentId
                        }).ToList();
            }
            else
            {
                return (from v in dbcontext.tblStudentDetails
                        select new DTOStudentRegistration
                        {
                            StudentName = v.colStudentName,
                            StudentId = v.colStudentId
                        }).ToList();
            }
        }
    }
}
