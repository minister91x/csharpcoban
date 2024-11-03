using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpCoBan.DataAccess.Generic
{
    public class Generic<T>
    {
        public T Tong2So(T a, T b)
        {
            dynamic sothunhat = a;
            dynamic sothuhai = b;
            return sothunhat + sothuhai;
        }

        public void Swap<T>(ref T a, ref T b)
        {
            T temp = a;
            a = b;
            b = temp;
        }
    }



}
