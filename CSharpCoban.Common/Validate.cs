using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpCoban.Common
{
    public class Validate
    {
        public bool ValidateInputData(string inputData)
        {
            if (string.IsNullOrEmpty(inputData)) return false;

            //int n = 0;
            //var isnumber = int.TryParse(inputData, out n);

            //if (!isnumber) return false;
            return true;


            // CTRL+ K + D để fomat code 
        }
    }
}
