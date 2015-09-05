using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataTransferObject;
using System.Data;
using System.Data.Linq.SqlClient;

namespace DataAccessObject
{
    public class DAOInstituteDetails
    {
        public bool IsInstituteNameExists(DTOInstituteDetails toins)
        {
            try
            {
                Campus2CaretakerDataContext dbContext = new Campus2CaretakerDataContext();
                int inCount = dbContext.tblInstituteDetails.Where(x => x.colInstituteName == toins.InstituteName).Count();
                if (inCount > 0)
                    return true;
                else
                    return false;
            }
            catch
            {
                return false;
            }
        }

        public bool IsInstituteEmailExists(DTOInstituteDetails toins)
        {
            try
            {
                Campus2CaretakerDataContext dbContext = new Campus2CaretakerDataContext();
                int inemCount = dbContext.tblInstituteLogins.Where(x => x.colUsername == toins.InstituteEmail).Count();
                if (inemCount > 0)
                    return true;
                else
                    return false;
            }
            catch
            {
                return false;
            }
        }

        public bool InsertInstituteDetails(DTOInstituteDetails toins)
        {
            try
            {
                Campus2CaretakerDataContext dbContext = new Campus2CaretakerDataContext();

                // Institute Details

                tblInstituteDetail InstDetail = new tblInstituteDetail();
                InstDetail.colAddress = toins.InstituteAddress;
                InstDetail.colInstituteName = toins.InstituteName;
                InstDetail.colInstituteType = toins.InstituteType;
                InstDetail.colLogoPath = toins.LogoPath;
                InstDetail.colPhone = toins.InstitutePhoneNo;
                InstDetail.colPrincipalContact = toins.PrincipalContact;
                InstDetail.colPrincipalName = toins.PrincipalName;
                InstDetail.colState = toins.State;
                InstDetail.colDistrict = toins.District;
                InstDetail.colMaxStudents = toins.MaxStudents;

                dbContext.tblInstituteDetails.InsertOnSubmit(InstDetail);
                dbContext.SubmitChanges();

                // Institute Login Details

                tblInstituteLogin InstLogin = new tblInstituteLogin();
                InstLogin.colInstituteId = dbContext.tblInstituteDetails.Select(x => x.colInstituteId).Max();
                InstLogin.colPassword = toins.InstituteDefaultPwd;
                InstLogin.colUsername = toins.InstituteEmail;
                InstLogin.colUserType = toins.InstituteUserType;

                dbContext.tblInstituteLogins.InsertOnSubmit(InstLogin);
                dbContext.SubmitChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public DataTable GetInstituteDetails(DTOInstituteDetails toins)
        {
            using (Campus2CaretakerDataContext dbcontext = new Campus2CaretakerDataContext())
            {
                return (dbcontext.GetInstituteDetails(toins.InstituteID)).ToDataTable();
            }
        }

        public bool UpdateInstituteDetails(DTOInstituteDetails toins)
        {
            try
            {
                Campus2CaretakerDataContext dbContext = new Campus2CaretakerDataContext();

                // Institute Details

                tblInstituteDetail InstDetail = dbContext.tblInstituteDetails.Where(x => x.colInstituteId == toins.InstituteID).FirstOrDefault();
                InstDetail.colAddress = toins.InstituteAddress;
                InstDetail.colInstituteName = toins.InstituteName;
                InstDetail.colInstituteType = toins.InstituteType;
                InstDetail.colLogoPath = toins.LogoPath;
                InstDetail.colPhone = toins.InstitutePhoneNo;
                InstDetail.colPrincipalContact = toins.PrincipalContact;
                InstDetail.colPrincipalName = toins.PrincipalName;
                InstDetail.colState = toins.State;
                InstDetail.colDistrict = toins.District;
                InstDetail.colMaxStudents = toins.MaxStudents;

                dbContext.SubmitChanges();
                return true;
            }
            catch { return false; }

        }

        public bool DeleteInstituteDetails(DTOInstituteDetails toins)
        {
            try
            {
                Campus2CaretakerDataContext dbContext = new Campus2CaretakerDataContext();

                // Institute Details

                tblInstituteDetail InstDetail = dbContext.tblInstituteDetails.Where(x => x.colInstituteId == toins.InstituteID).FirstOrDefault();
                dbContext.tblInstituteDetails.DeleteOnSubmit(InstDetail);
                dbContext.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public DataTable GetInstitutes()
        {
            using (Campus2CaretakerDataContext dbcontext = new Campus2CaretakerDataContext())
            {
                return dbcontext.tblInstituteDetails.ToDataTable();
            }
        }

        public DataTable GetFilteredInstitutes(string _PInstName, string _PDistrict, string _PState)
        {
            using (Campus2CaretakerDataContext dbcontext = new Campus2CaretakerDataContext())
            {
                _PInstName = String.Concat("%", _PInstName, "%");
                _PDistrict = String.Concat("%", _PDistrict, "%");
                _PState = String.Concat("%", _PState, "%");

                var results = (from x in dbcontext.tblInstituteDetails
                               where SqlMethods.Like(x.colInstituteName, _PInstName)
                               || SqlMethods.Like(x.colDistrict, _PDistrict)
                               || SqlMethods.Like(x.colState, _PState)
                               select x).ToDataTable();

                return results;
            }
        }

        public int GetInstituteId(string email)
        {
            Campus2CaretakerDataContext dbcontext = new Campus2CaretakerDataContext();

            var res = from x in dbcontext.tblInstituteLogins
                      where x.colUsername == email
                      select x;

            return res.First().colInstituteId;
        }


        public List<DTOInstituteDetails> GetAutoCompleteInstitutes(string reqString)
        {
            Campus2CaretakerDataContext dbcontext = new Campus2CaretakerDataContext();
            if (!string.IsNullOrEmpty(reqString))
            {
                return (from v in dbcontext.tblInstituteDetails
                        where v.colInstituteName.Contains(reqString)
                        select new DTOInstituteDetails
                        {
                            InstituteName = v.colInstituteName,
                            InstituteID = v.colInstituteId
                        }).ToList();
            }
            else
            {
                return (from v in dbcontext.tblInstituteDetails
                        select new DTOInstituteDetails
                        {
                            InstituteName = v.colInstituteName,
                            InstituteID = v.colInstituteId
                        }).ToList();
            }
        }

        public List<DTOInstituteDetails> GetAutoCompleteInstituteDistricts(string reqString)
        {
            Campus2CaretakerDataContext dbcontext = new Campus2CaretakerDataContext();
            if (!string.IsNullOrEmpty(reqString))
            {
                return (from v in dbcontext.tblInstituteDetails
                        where v.colDistrict.Contains(reqString)
                        select new DTOInstituteDetails
                        {
                            District = v.colDistrict
                        }).ToList();
            }
            else
            {
                return (from v in dbcontext.tblInstituteDetails
                        select new DTOInstituteDetails
                        {
                            District = v.colDistrict
                        }).ToList();
            }
        }

        public List<DTOInstituteDetails> GetAutoCompleteStates(string reqString)
        {
            Campus2CaretakerDataContext dbcontext = new Campus2CaretakerDataContext();
            if (!string.IsNullOrEmpty(reqString))
            {
                return (from v in dbcontext.tblInstituteDetails
                        where v.colState.Contains(reqString)
                        select new DTOInstituteDetails
                        {
                            State = v.colState
                        }).ToList();
            }
            else
            {
                return (from v in dbcontext.tblInstituteDetails
                        select new DTOInstituteDetails
                        {
                            State = v.colState
                        }).ToList();
            }
        }
    }
}
