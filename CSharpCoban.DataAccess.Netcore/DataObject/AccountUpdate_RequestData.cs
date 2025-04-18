using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpCoban.DataAccess.Netcore.DataObject
{
    public class AccountUpdate_RequestData
    {
        public int AccountID { get; set; }
        public string? Address { get; set; }
    }
}
