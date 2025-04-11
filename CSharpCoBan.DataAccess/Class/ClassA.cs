using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpCoBan.DataAccess.Class
{
    public class ClassA
    {
        public ClassA()
        {             // Constructor logic here
        }

        public void MethodA()
        {
            var classB = IClassB();
            classB.MethodB();
        }
    }
}
