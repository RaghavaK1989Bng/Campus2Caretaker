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
    }
}
