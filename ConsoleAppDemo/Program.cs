using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {

            // Bước 1: Nhập 2 số 
            
            // Bước 2 kiểm tra 
            // - không được trống 
            // - không phải text ( abc , < , !@...vvv)
            // - số không được vượt quá kích thước kiểu int 
            // Bước 3: Tính tổng 

            Console.InputEncoding = Encoding.UTF8;
            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine("số thứ nhất :");
            var so1 = Console.ReadLine();

            // chờ chú tý nhé 
            Console.WriteLine("số thứ hai:");
            var so2 = Console.ReadLine();
            var function_tinh = new CSharpCoBan.DataAccess.Function();

            var tong = function_tinh.TinhTong(so1, so2);

            if (tong < 0)
            {
                switch (tong)
                {
                    case -1:
                        Console.WriteLine("Số thứ nhất không hợp lệ:{0}", tong);
                        break;
                    case -2:
                        Console.WriteLine("Số thứ 2 không hợp lệ:{0}", tong);
                        break;

                    default:
                        Console.WriteLine("Hệ thống đang bận");
                        break;

                }
            }

            Console.WriteLine("Tổng hai số là: {0}", tong);



            int number = 15;
            Console.WriteLine("number first: {0}", number);

            function_tinh.Tong_ThamChieu(ref number);
            Console.WriteLine("number second: {0}", number);


            int outNumber;
            function_tinh.Tong_ThamChieu_Out(out outNumber);
            Console.WriteLine("outNumber second: {0}", outNumber);

            Console.WriteLine("số thứ nhất: {0}", so1);
            Console.WriteLine("số thứ hai {0}", so2);
            Console.WriteLine("Tổng là :{0}", tong);
            Console.ReadKey();
        }
    }
}