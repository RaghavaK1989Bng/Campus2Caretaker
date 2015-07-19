using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccessObject;
using System.Data;
using DataTransferObject;

namespace BusinessObjects
{
    public class BOPersonalizeApplication
    {
        public DataTable GetClassesList(string _pInstituteId)
        {
            return new DAOPersonalizeApplication().GetClassesList(_pInstituteId);
        }

        public DataTable GetSubjectsList(string _pInstituteId)
        {
            return new DAOPersonalizeApplication().GetSubjectsList(_pInstituteId);
        }

        public bool SaveClasses(DTOPersonalizeApplication DTOPApplication)
        {
            return new DAOPersonalizeApplication().SaveClasses(DTOPApplication);
        }

        public bool SaveSubjects(DTOPersonalizeApplication DTOPApplication)
        {
            return new DAOPersonalizeApplication().SaveSubjects(DTOPApplication);
        }
    }
}
