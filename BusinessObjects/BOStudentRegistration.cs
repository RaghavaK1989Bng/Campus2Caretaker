using DataAccessObject;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using DataTransferObject;

namespace BusinessObjects
{
    public class BOStudentRegistration
    {
        public DataTable GetClassesList(string _pInstituteId)
        {
            return new DAOStudentRegistration().GetClassesList(_pInstituteId);
        }

        public DataTable GetStudentsList(string _pInstituteId)
        {
            return new DAOStudentRegistration().GetStudentsList(_pInstituteId);
        }

        public bool SaveStudentDetails(DTOStudentRegistration tostudentreg)
        {
            return new DAOStudentRegistration().SaveStudentDetails(tostudentreg);
        }

        public string GetBranchId(string BranchName)
        {
            try
            {
                return new DAOStudentRegistration().GetBranchId(BranchName);
            }
            catch (Exception ex)
            {
                return string.Empty;
            }
        }

        public bool SaveStudentRegistrationExcel(DataTable dt, string instituteId)
        {
            return new DAOStudentRegistration().SaveStudentRegistrationExcel(dt, instituteId);
        }

        public DataTable GetStudentDetails(DTOStudentRegistration tostu)
        {
            return new DAOStudentRegistration().GetStudentDetails(tostu);
        }

        public bool UpdateStudentDetails(DTOStudentRegistration tostud)
        {
            return new DAOStudentRegistration().UpdateStudentDetails(tostud);
        }

        public bool DeleteStudentDetails(DTOStudentRegistration tostu)
        {
            return new DAOStudentRegistration().DeleteStudentDetails(tostu);
        }
    }
}
