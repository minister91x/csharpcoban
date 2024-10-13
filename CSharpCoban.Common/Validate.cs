using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CSharpCoban.Common
{
    public static class Validate
    {
        public static bool CheckString(string inputData)
        {
            if (string.IsNullOrEmpty(inputData)) return false;

            if (int.TryParse(inputData, out int value)) return false;

            if (inputData.Length > 100) return false;

            var regexItem = new Regex("^[a-zA-Z]*$");

            if (!regexItem.IsMatch(inputData)) return false;

            //var html_tag = "<a ,<p";
            //if (inputData.Contains(html_tag)) return false;

            return true;

        }
        public static bool CheckID(string inputData)
        {
            if (string.IsNullOrEmpty(inputData)) return false;

            if (int.TryParse(inputData, out int value)) return false;

            if (inputData.Length > 20) return false;

            return true;

        }
        public static bool CheckTuoi(string inputData)
        {
            if (string.IsNullOrEmpty(inputData)) return false;
            if (!int.TryParse(inputData, out int value)) return false;
            if (value < 18 || value > 150) return false;
            return true;

        }
        public static bool CheckNumber(string inputData)
        {
            if (string.IsNullOrEmpty(inputData)) return false;
            if (!int.TryParse(inputData, out int value)) return false;
            if (value < 18 || value > 150) return false;
            return true;

        }

        public static bool CheckHeSo(string inputData)
        {
            if (string.IsNullOrEmpty(inputData)) return false;
            if (!int.TryParse(inputData, out int value)) return false;
            return true;

        }

        public static bool CheckDateTime(string inputData)
        {
            if (string.IsNullOrEmpty(inputData)) return false;
            DateTime dateTime;
            var format = "dd/MM/yyyy";
            if (!DateTime.TryParseExact(inputData, format, CultureInfo.InvariantCulture,DateTimeStyles.None, out dateTime))
            {
                return false;
            }

            return true;
        }
    }
}
