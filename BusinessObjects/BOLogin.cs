using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataTransferObject;
using DataAccessObject;

namespace BusinessObjects
{
    public class BOLogin
    {
        #region Admin Login

        public bool CheckAdminUser(DTOLogin tologin)
        {
            return new DAOLogin().CheckAdminUser(tologin);
        }

        #endregion

        public bool CheckInstituteUser(DTOLogin tologin)
        {
            return new DAOLogin().CheckInstituteUser(tologin);
        }

        public bool ChangeInstituteUserPassword(DTOLogin tologin)
        {
            return new DAOLogin().ChangeInstituteUserPassword(tologin);
        }
    }
}
