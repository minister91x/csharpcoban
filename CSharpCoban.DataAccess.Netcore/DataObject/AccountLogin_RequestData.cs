using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpCoban.DataAccess.Netcore.DataObject
{
    public class AccountLogin_RequestData
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string DeviceID { get; set; }
        public string LocationID { get; set; }
    }

    public class Account_LogOutRequestData
    {
        public string DeviceID { get; set; }

    }
}
