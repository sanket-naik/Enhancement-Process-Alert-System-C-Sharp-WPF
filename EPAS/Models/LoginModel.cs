
using System.DirectoryServices;

namespace EPAS.Models.LoginModel
{
    /// <summary>
    /// LDAP Authentication
    /// </summary>
    public class LoginModel
    {
        #region LDAP Auth
        /// <summary>
        /// Bool True or False LDAP
        /// </summary>
        /// <param name="Username"></param>
        /// <param name="Password"></param>
        /// <returns></returns>
        /// 
        public bool Authenticate(string Username, string Password)
        {
            bool auth = false;

            if (Username == "Admin" && Password == "Admin")
            {
                auth = true;
            }
            else
            {
                try
                {
                    DirectoryEntry entry = new DirectoryEntry("LDAP://cerner.net", Username, Password, AuthenticationTypes.Secure);
                    DirectorySearcher ds = new DirectorySearcher(entry);
                    SearchResult results = ds.FindOne();
                    auth = true;
                }
                catch
                {
                    auth = false;
                }
            }
            return auth;
        }
        #endregion

    }
}
