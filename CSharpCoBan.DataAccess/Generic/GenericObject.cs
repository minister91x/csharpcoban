using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpCoBan.DataAccess.Generic
{
    public struct GenericObject<T>
    {
        public T MyProperties;

        public T GetValue()
        {
            return MyProperties;
        }
    }
}
