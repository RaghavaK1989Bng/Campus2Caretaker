using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataTransferObject;
using DataAccessObject;
using System.Data;

namespace BusinessObjects
{
   public class BOInstituteDetails
    {
       public bool IsInstituteNameExists(DTOInstituteDetails toinst)
       {
           return new DAOInstituteDetails().IsInstituteNameExists(toinst);
       }

       public bool InsertInstituteDetails(DTOInstituteDetails toinst)
       {
           return new DAOInstituteDetails().InsertInstituteDetails(toinst);
       }

       public bool IsInstituteEmailExists(DTOInstituteDetails toinst)
       {
           return new DAOInstituteDetails().IsInstituteEmailExists(toinst);
       }

       public DataTable GetInstituteDetails(DTOInstituteDetails toins)
       {
           return new DAOInstituteDetails().GetInstituteDetails(toins);
       }

       public bool UpdateInstituteDetails(DTOInstituteDetails toinst)
       {
           return new DAOInstituteDetails().UpdateInstituteDetails(toinst);
       }

       public bool DeleteInstituteDetails(DTOInstituteDetails toins)
       {
           return new DAOInstituteDetails().DeleteInstituteDetails(toins);
       }

       public DataTable GetInstitutes()
       {
           return new DAOInstituteDetails().GetInstitutes();
       }

       public DataTable GetFilteredInstitutes(string _PInstName, string _PDistrict, string _PState)
       {
           return new DAOInstituteDetails().GetFilteredInstitutes(_PInstName, _PDistrict, _PState);
       }

       public int GetInstituteId(string email)
       {
           return new DAOInstituteDetails().GetInstituteId(email);
       }
    }
}
