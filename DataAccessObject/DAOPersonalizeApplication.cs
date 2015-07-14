using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace DataAccessObject
{
    public class DAOPersonalizeApplication
    {
        public DataTable GetClassesList(string _pInstituteId)
        {
            int InstituteId = int.Parse(_pInstituteId);
             Campus2CaretakerDataContext dbContext = new Campus2CaretakerDataContext();
             return dbContext.tblClassDetails.Where(x => x.colInstituteId == InstituteId).ToDataTable();
        }
    }
}
