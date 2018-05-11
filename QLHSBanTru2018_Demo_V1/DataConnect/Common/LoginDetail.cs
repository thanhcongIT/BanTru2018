using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLHSBanTru2018_Demo_V1.Common
{
    public class LoginDetail
    {
        public static int LoginID;
        public static string LoginName;
        public void setLoginID(int id)
        {
            LoginID = id;
        }
        public int getLoginID()
        {
            return LoginID;
        }
        public void setLoginName(string name)
        {
            LoginName = name;
        }
        public string getLoginName()
        {
            return LoginName;
        }
    }
}
