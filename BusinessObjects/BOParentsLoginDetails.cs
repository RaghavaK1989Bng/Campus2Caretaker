using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataTransferObject;
using DataAccessObject;
using System.Data;

namespace BusinessObjects
{
    public class BOParentsLoginDetails
    {
        public string GetParentsEmailId(string mobilenumber)
        {
            return new DAOParentsLoginDetails().GetParentsEmailId(mobilenumber);
        }

        public bool InsertParentsLoginOTP(DTOParentsLoginDetails tologin)
        {
            return new DAOParentsLoginDetails().InsertParentsLoginOTP(tologin);
        }

        public string GetExistingotp(string mobno)
        {
            return new DAOParentsLoginDetails().GetExistingotp(mobno);
        }

        public bool CheckParentsLoginUser(DTOParentsLoginDetails tologin)
        {
            return new DAOParentsLoginDetails().CheckParentsLoginUser(tologin);
        }

        public DataTable GetStudentsList(string mobilenumber)
        {
            return new DAOParentsLoginDetails().GetStudentsList(mobilenumber);
        }

        public DataTable GetStudentsDetails(int StudentID)
        {
            return new DAOParentsLoginDetails().GetStudentsDetails(StudentID);
        }

        public DataTable GetStudentInternalDetails(int StudentID)
        {
            return new DAOParentsLoginDetails().GetStudentInternalDetails(StudentID);
        }

        public DataTable GetStudentAttendanceDetails(int StudentID)
        {
            return new DAOParentsLoginDetails().GetStudentAttendanceDetails(StudentID);
        }
    }
}
