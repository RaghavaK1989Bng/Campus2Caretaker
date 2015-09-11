using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataTransferObject;
using System.Data;
using System.Data.Linq.SqlClient;

namespace DataAccessObject
{
    public class DAOParentsLoginDetails
    {
        public string GetParentsEmailId(string mobilenumber)
        {
            try
            {
                using (Campus2CaretakerDataContext ctx = new Campus2CaretakerDataContext())
                {

                    var pdet = (from u in ctx.tblStudentDetails where u.colParentsMobileNo == mobilenumber select u).FirstOrDefault();
                    if (!string.IsNullOrEmpty(pdet.colParentsEmail))
                    {
                        return pdet.colParentsEmail;
                    }
                    return string.Empty;
                }
            }
            catch
            {
                return string.Empty; ;
            }
        }

        public bool InsertParentsLoginOTP(DTOParentsLoginDetails tologin)
        {
            try
            {
                Campus2CaretakerDataContext dbContext = new Campus2CaretakerDataContext();
                tblParentsLoginOTP otpDetail = new tblParentsLoginOTP();
                otpDetail.colMobileNumber = tologin.Mobilenumber;
                otpDetail.colOTP = tologin.Otp;
                otpDetail.colisUsed = Convert.ToByte(tologin.Isused);
                dbContext.tblParentsLoginOTPs.InsertOnSubmit(otpDetail);
                dbContext.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public string GetExistingotp(string mobno)
        {
            try
            {
                using (Campus2CaretakerDataContext ctx = new Campus2CaretakerDataContext())
                {

                    var otpdet = (from u in ctx.tblParentsLoginOTPs where u.colMobileNumber == mobno && u.colisUsed == 0 select u).FirstOrDefault();
                    if (!string.IsNullOrEmpty(otpdet.colOTP))
                    {
                        return otpdet.colOTP;
                    }
                    return string.Empty;
                }
            }
            catch
            {
                return string.Empty; ;
            }
        }

        public bool CheckParentsLoginUser(DTOParentsLoginDetails tologin)
        {
            try
            {
                using (Campus2CaretakerDataContext ctx = new Campus2CaretakerDataContext())
                {

                    var usr = (from u in ctx.tblParentsLoginOTPs where u.colMobileNumber == tologin.Mobilenumber && u.colOTP == tologin.Otp select u);
                    if (usr.Count() > 0)
                    {
                        usr.FirstOrDefault().colisUsed = 1;
                        ctx.SubmitChanges();
                        return true;
                    }
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }

        public DataTable GetStudentsList(string mobilenumber)
        {
            try
            {
                using (Campus2CaretakerDataContext ctx = new Campus2CaretakerDataContext())
                {

                    var sdet = (from u in ctx.tblStudentDetails where u.colParentsMobileNo == mobilenumber select u).ToDataTable();
                    return sdet;
                }
            }
            catch
            {
                return null;
            }
        }

        public DataTable GetStudentsDetails(int StudentID)
        {
            try
            {
                using (Campus2CaretakerDataContext ctx = new Campus2CaretakerDataContext())
                {

                    var sdet = (from u in ctx.GetStudentDetailsParentsLogin(StudentID) select u).ToDataTable();
                    return sdet;
                }
            }
            catch
            {
                return null;
            }
        }

        public DataTable GetStudentInternalDetails(int StudentID)
        {
            try
            {
                using (Campus2CaretakerDataContext ctx = new Campus2CaretakerDataContext())
                {

                    var sdet = (from u in ctx.GetStudentInternalDetailsParentsLogin(StudentID) select u).ToDataTable();
                    return sdet;
                }
            }
            catch
            {
                return null;
            }
        }
    }
}
