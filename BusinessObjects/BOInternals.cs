using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccessObject;
using DataTransferObject;
using System.Data;

namespace BusinessObjects
{
    public class BOInternals
    {
        public DataTable GetStudentsList(DTOInternals toint)
        {
            return new DAOInternals().GetStudentsList(toint);
        }

        public void SaveUpdateInternals(DTOInternals toInt)
        {
            new DAOInternals().SaveUpdateInternals(toInt);
        }

        public DataTable GetStudentsListEdit(DTOInternals toInt)
        {
            return new DAOInternals().GetStudentsListEdit(toInt);
        }

        public DataTable GetInternalsChartDetails(DTOInternals toint)
        {
            return new DAOInternals().GetInternalsChartDetails(toint);
        }
    }
}
