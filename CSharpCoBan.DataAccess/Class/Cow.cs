using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpCoBan.DataAccess.Class
{
    public class Cow : Animal_Abstract
    {
        public override string Eat()
        {
            return "ăn cỏ";
        }

        public override string GetSound()
        {
            return "be be";
        }
    }
}
