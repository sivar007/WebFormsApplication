using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.DirectoryServices;

namespace ClassLibrary
{
    public class Authenticator
    {
        public class AuthenticateResult
        {
            public bool Error;
            public string ErrorMessage;
            public List<string> MemberOf = new List<string>();
            public string ExtensionAttribute13;
        }
        public static AuthenticateResult Authenticate(string userId, string password)
        {
            //var root = new DirectoryEntry("GC://DC=hscnet,DC=hsc,DC=usf,DC=edu", userId, password);
            var root = new DirectoryEntry("GC://hsc1.hscnet.hsc.usf.edu/DC=hscnet,DC=hsc,DC=usf,DC=edu", userId, password);

            var searcher = new DirectorySearcher(root);
            searcher.PropertiesToLoad.Add("memberOf");
            searcher.PropertiesToLoad.Add("extensionAttribute13");
            searcher.Filter = string.Format("(&(objectclass=user)(sAMAccountName={0}))", userId);

            try
            {
                var result = searcher.FindOne();

                var retVal = new AuthenticateResult() { ExtensionAttribute13 = result.Properties["extensionAttribute13"][0].ToString() };
                foreach (var item in result.Properties["memberOf"])
                {
                    retVal.MemberOf.Add(item.ToString().Split(',')[0].Split('=')[1]);
                }

                return retVal;
            }
            catch (DirectoryServicesCOMException ex)
            {
                if (ex.Message.Contains("Logon failure: unknown user name or bad password."))
                {
                    return new AuthenticateResult() { Error = true, ErrorMessage = "Logon failure: unknown user name or bad password." };
                }
                else
                    throw;
            }           


        }
    }
}
