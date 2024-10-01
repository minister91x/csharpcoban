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
            if (!int.TryParse(inputData, out int value)) return false;
            if(int.MaxValue >= value) return false;
            return true;

        }
    }
}
