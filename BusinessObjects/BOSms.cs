using DataAccessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObjects
{
    public class BOSms
    {
        public List<string> GetContactsListAll(int instituteId)
        {
            return new DAOSms().GetContactsListAll(instituteId);
        }

        public List<string> GetContactsListBranchwise(int instituteId, int classId)
        {
            return new DAOSms().GetContactsListBranchwise(instituteId, classId);
        }

        public List<string> GetContactsListSemesterwise(int instituteId, int semesterId)
        {
            return new DAOSms().GetContactsListSemesterwise(instituteId, semesterId);
        }

        public string GetSMSTemplate(string templateType)
        {
            return new DAOSms().GetSMSTemplate(templateType);
        }
    }
}
