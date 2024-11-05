using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpCoBan.DataAccess.Class
{
    public class Bird : Animal_Abstract
    {
        public override string Eat()
        {
            return "ăn sâu";
        }

        public override string GetSound()
        {
            return "chíp chíp";
        }
    }
}
