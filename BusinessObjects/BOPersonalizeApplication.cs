using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccessObject;
using System.Data;

namespace BusinessObjects
{
    public class BOPersonalizeApplication
    {
        public DataTable GetClassesList(string _pInstituteId)
        {
            return new DAOPersonalizeApplication().GetClassesList(_pInstituteId);
        }
    }
}
