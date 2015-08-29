using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataTransferObject;
using System.Data;

namespace DataAccessObject
{
    public class DAOSms
    {
        public List<string> GetContactsListAll(int instituteId)
        {
            List<string> contactsList = new List<string>();
            Campus2CaretakerDataContext dbContext = new Campus2CaretakerDataContext();

            contactsList = (from a in dbContext.tblStudentDetails
                            where a.colInstituteId == instituteId
                            select a.colParentsMobileNo).ToList();

            return contactsList;
        }

        public List<string> GetContactsListBranchwise(int instituteId, int classId)
        {
            List<string> contactsList = new List<string>();
            Campus2CaretakerDataContext dbContext = new Campus2CaretakerDataContext();

            contactsList = (from a in dbContext.tblStudentDetails
                            where a.colInstituteId == instituteId && a.colBranchId == classId
                            select a.colParentsMobileNo).ToList();

            return contactsList;
        }

        public List<string> GetContactsListSemesterwise(int instituteId, int semesterId)
        {
            List<string> contactsList = new List<string>();
            Campus2CaretakerDataContext dbContext = new Campus2CaretakerDataContext();

            contactsList = (from a in dbContext.tblStudentDetails
                            where a.colInstituteId == instituteId && a.colSemesterId == semesterId
                            select a.colParentsMobileNo).ToList();

            return contactsList;
        }

        public string GetSMSTemplate(string templateType)
        {
            Campus2CaretakerDataContext dbContext = new Campus2CaretakerDataContext();

            return (from a in dbContext.tblSMSTemplates
                            where a.TemplateType == templateType
                            select a.Template).FirstOrDefault();
        }
    }
}
