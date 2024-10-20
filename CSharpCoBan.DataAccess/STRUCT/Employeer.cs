using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpCoBan.DataAccess.STRUCT
{
    public struct Employeer
    {
        public string ID { get; set; }
        public string HoVaTen { get; set; }
        public DateTime NgaySinh { get; set; }

        public int Heso { get; set; }
        public DateTime NgayVao { get; set; }

        public string Getinfor()
        {
            return HoVaTen;
        }
    }
}
