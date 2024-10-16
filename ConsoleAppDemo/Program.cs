﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppDemo
{

    internal class Program
    {
        public struct MyCar
        {
            public int id { get; set; }
            public string name { get; set; }

            public MyCar(int _id, string _name)
            {
                this.id = _id;
                this.name = _name;
            }

            public string Description()
            {
                return "tên của xe là :" + name;
            }

            // Hàm : là 1 nhóm lệnh thực thi 1 công việc nào đó
            // -Phải có kiểu trả về void / kiểu dữ liệu nào đó
            // -tên hàm : do người dùng tự quyết định
            // không cần phải khởi tạo thuộc tính 

            // Hàm khởi tạo là hàm mà :
            // -KHÔNG có kiểu trả về 
            // -Tên hàm thì trùng tên của Struct 
            // Hàm này phải khởi tạo hết tất cả các thuộc tính của struct
        }

        static MyCar GetMyCarInfor(int id, string name)
        {
            var myCar = new MyCar();
            myCar.id = id;
            myCar.name = name;

            return myCar;

        }

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
            //Console.WriteLine("số thứ nhất :");
            //var so1 = Console.ReadLine();

            //// chờ chú tý nhé 
            //Console.WriteLine("số thứ hai:");
            //var so2 = Console.ReadLine();
            //var function_tinh = new CSharpCoBan.DataAccess.Function();

            //var tong = function_tinh.TinhTong(so1, so2);

            //if (tong < 0)
            //{
            //    switch (tong)
            //    {
            //        case -1:
            //            Console.WriteLine("Số thứ nhất không hợp lệ:{0}", tong);
            //            break;
            //        case -2:
            //            Console.WriteLine("Số thứ 2 không hợp lệ:{0}", tong);
            //            break;

            //        default:
            //            Console.WriteLine("Hệ thống đang bận");
            //            break;

            //    }
            //}

            //Console.WriteLine("Tổng hai số là: {0}", tong);



            //int number = 15;
            //Console.WriteLine("number first: {0}", number);

            //function_tinh.Tong_ThamChieu(ref number);
            //Console.WriteLine("number second: {0}", number);


            //int outNumber;
            //function_tinh.Tong_ThamChieu_Out(out outNumber);
            //Console.WriteLine("outNumber second: {0}", outNumber);

            //Console.WriteLine("số thứ nhất: {0}", so1);
            //Console.WriteLine("số thứ hai {0}", so2);
            //Console.WriteLine("Tổng là :{0}", tong);



            Console.WriteLine("mời nhập id:");
            var id = Console.ReadLine();

            Console.WriteLine("mời nhập tên:");
            var name = Console.ReadLine();

            Console.WriteLine("mời nhập ngày sinh:");
            var ngaysinh = Console.ReadLine();

            Console.WriteLine("mời nhập ngày vào làm");
            var ngayvaolam = Console.ReadLine();

            Console.WriteLine("mời nhập hệ số");
            var heso = Console.ReadLine();

            var employeerManager = new CSharpCoBan.DataAccess.EmployeerManager();
            var ketqua = employeerManager.Employeer_Insert(id, name, ngaysinh, ngayvaolam, heso);

            var list = employeerManager.Employeer_GetList();
            if (list.Count > 0)
            {
                foreach (var item in list)
                {
                    Console.WriteLine("id: {0} \t ",item.ID);
                    Console.WriteLine("Name: {0} \t ", item.HoVaTen);
                }
            }
            Console.WriteLine("ketqua :{0}", ketqua);
            
            Console.ReadKey();
        }
    }
}