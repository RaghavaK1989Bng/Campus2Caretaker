using DataAccessObject;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

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
    }
}
