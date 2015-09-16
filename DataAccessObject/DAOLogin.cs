using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataTransferObject;
using System.Data;
using System.Reflection;

namespace DataAccessObject
{
    public class DAOLogin
    {
        #region Admin Login

        public bool CheckAdminUser(DTOLogin tologin)
        {
            try
            {
                using (Campus2CaretakerDataContext ctx = new Campus2CaretakerDataContext())
                {

                    var count = (from u in ctx.tblSuperAdminLogins where u.colUsername.ToLower() == tologin.UserID.ToLower() && u.colPassword == tologin.Password select u).Count();
                    if (count > 0)
                    {
                        return true;
                    }
                    return false;
                }

            }
            catch
            {
                return false;
            }

        }

        #endregion

        public bool CheckInstituteUser(DTOLogin tologin)
        {
            try
            {
                using (Campus2CaretakerDataContext ctx = new Campus2CaretakerDataContext())
                {

                    var count = (from u in ctx.tblInstituteLogins where u.colUsername.ToLower() == tologin.UserID.ToLower() && u.colPassword == tologin.Password select u).Count();
                    if (count > 0)
                    {
                        return true;
                    }
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }

        public bool ChangeInstituteUserPassword(DTOLogin tologin)
        {
            try
            {
                using (Campus2CaretakerDataContext ctx = new Campus2CaretakerDataContext())
                {

                    var user = (from u in ctx.tblInstituteLogins where u.colUsername == tologin.UserID select u).FirstOrDefault();
                    user.colPassword = tologin.Password;
                    ctx.SubmitChanges();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        public bool CheckParentsMobileNumber(DTOLogin tologin)
        {
            try
            {
                using (Campus2CaretakerDataContext ctx = new Campus2CaretakerDataContext())
                {

                    var count = (from u in ctx.tblStudentDetails where u.colParentsMobileNo == tologin.UserID select u).Count();
                    if (count > 0)
                    {
                        return true;
                    }
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }
    }
    public static class myExtension
    {
        #region extension methods

        public static DataTable ToDataTable<T>(this IEnumerable<T> items)
        {
            var tb = new DataTable(typeof(T).Name);
            //try
            // {
            PropertyInfo[] props =
        typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (var prop in props)
            {
                Type pt = prop.PropertyType;
                if (pt.IsGenericType &&
            pt.GetGenericTypeDefinition() == typeof(Nullable<>))
                    pt = Nullable.GetUnderlyingType(pt);
                tb.Columns.Add(prop.Name, pt);
            }

            foreach (var item in items)
            {
                var values = new object[props.Length];
                for (var i = 0; i < props.Length; i++)
                {
                    values[i] = props[i].GetValue(item, null);
                }

                tb.Rows.Add(values);
            }
            // }
            // catch { }
            return tb;
        }

        #endregion
    }
}
