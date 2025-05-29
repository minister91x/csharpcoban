using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpCoban.DataAccess.Netcore.DataObject
{
    public class User_Sessions
    {
        public int AccountID { get; set; }
        public string Token { get; set; }
        public string DeviceID { get; set; }
        public DateTime ExpriredTime { get; set; }
    }
}
