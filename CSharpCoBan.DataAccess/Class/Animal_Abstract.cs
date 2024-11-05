using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpCoBan.DataAccess.Class
{
    public abstract class Animal_Abstract
    {
        public abstract string GetSound(); // Hàm trừu tượng 
        public abstract string Eat();

        public virtual string GetName()
        {
            return string.Empty;
        }
    }
}
