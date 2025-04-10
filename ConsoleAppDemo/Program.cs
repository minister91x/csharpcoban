﻿using CSharpCoBan.DataAccess.Class;
using CSharpCoBan.DataAccess.ENUM;
using CSharpCoBan.DataAccess.Generic;
using CSharpCoBan.DataAccess.Repository;
using CSharpCoBan.DataAccess.STRUCT;
using System;
using System.Collections;
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



            //Console.WriteLine("mời nhập id:");
            //var id = Console.ReadLine();

            //Console.WriteLine("mời nhập tên:");
            //var name = Console.ReadLine();

            //Console.WriteLine("mời nhập ngày sinh:");
            //var ngaysinh = Console.ReadLine();

            //Console.WriteLine("mời nhập ngày vào làm");
            //var ngayvaolam = Console.ReadLine();

            //Console.WriteLine("mời nhập hệ số");
            //var heso = Console.ReadLine();

            //var employeerManager = new CSharpCoBan.DataAccess.EmployeerManager();
            //var ketqua = employeerManager.Employeer_Insert(id, name, ngaysinh, ngayvaolam, heso);

            //var list = employeerManager.Employeer_GetList();
            //if (list.Count > 0)
            //{
            //    foreach (var item in list)
            //    {
            //        Console.WriteLine("id: {0} \t ",item.ID);
            //        Console.WriteLine("Name: {0} \t ", item.HoVaTen);
            //    }
            //}
            //Console.WriteLine("ketqua :{0}", ketqua);


            // nhân kỷ niệm cty sẽ tăng quà cho nhân viên lâu năm với mốc là 10 năm kể từ ngày hiện tại
            var sonam = 10;
            if (sonam == 10)
            {
                /// 
            }
            else
            {

                // code 
            }

            // đã đặt // đã thanh toán // thành công // thất bại 
            // giỏi / trung bình / khá 
            string[] trangthais = { "đã đặt", "thành công" };

            var name1 = trangthais[0];
            Console.WriteLine("trangthais[0] name1: = {0}", name1);

            // gán giá trị cho mảng
            trangthais[0] = "đã mua";

            var name2 = trangthais[0];
            Console.WriteLine("trangthais[0] name2 : = {0}", name2);

            var dodai_cuamang = trangthais.Length; // thuộc tính
            Console.WriteLine("trangthais[0] dodai_cuamang : = {0}", dodai_cuamang);
            bool isvalid = trangthais.Any(); // hàm 
            Console.WriteLine("trangthais[0] isvalid : = {0}", isvalid);

            int[] myArray = { 10, 6, 4, 19 };

            var value = myArray.GetValue(0);
            var min = myArray.Min();
            var max = myArray.Max();

            var newarr = myArray.OrderByDescending(x => x).ToArray();
            var sum = myArray.Sum();

            var asc = myArray.OrderBy(x => x).ToArray();

            Console.WriteLine("myArray value: = {0}", value);
            Console.WriteLine("myArray min: = {0}", min);
            Console.WriteLine("myArray max: = {0}", max);
            Console.WriteLine("myArray sum: = {0}", sum);
            foreach (var item in newarr)
            {
                Console.WriteLine("item: = {0}", item);
            }

            foreach (var item in asc)
            {
                Console.WriteLine("item: = {0}", item);
            }

            int[,] myvar = new int[3, 4];

            //var trangthai = 0;
            //if (trangthai == (int)TrangThai_MuaHang.KHOITAO)
            //{
            //    // code xử lý
            //}

            //if (trangthai == (int)TrangThai_MuaHang.THANH_CONG)
            //{
            //    // code xử lý
            //}

            //if (trangthai == (int)TrangThai_MuaHang.HOAN_TIEN)
            //{
            //    // code xử lý
            //}

            //switch (trangthai)
            //{
            //    case
            //        (int)TrangThai_MuaHang.KHOITAO:
            //        // code xử lý
            //        break;
            //    case
            //        (int)TrangThai_MuaHang.THANH_CONG:
            //        // code xử lý
            //        break;
            //    case
            //        (int)TrangThai_MuaHang.THAT_BAI:
            //        break;
            //    case
            //        (int)TrangThai_MuaHang.HOAN_TIEN:
            //        break;

            //    case
            //        (int)TrangThai_MuaHang.DATRUTIEN_CHUAGIAOHANG:
            //        break;
            //}


            // Thuộc tính : 
            // var dateNow = DateTime.Now; // trả về thời gian hiện tại theo location ( UTC+ 7)
            // var dateUTCNow = DateTime.UtcNow;// TRẢ VỀ GIỜ UTC + 0 

            // Phương thức : -> tất cả phương thức liên quan đến thời gian 
            // Thêm ,bớt , khoảng cách giữa 2 mốc thời , so sánh thời gian , định dạng thời gian ( dd/MM/yyyy ...vvv

            //1.Thêm bớt :
            //var newDateAdd = dateNow.AddDays(-1);

            // var timeSpan = new TimeSpan(-5, 10, 10); // 1 khoảng thời gian 

            //var newDateAddSpan = dateNow.Add(timeSpan);

            //var subdate = dateNow.Subtract(new DateTime(2005, 9, 5)); // khoảng cách giữa 2 mốc thời gian 

            // hãy tính số ngày mình đã được sinh ra 
            DateTime aDateTime = new DateTime(2022, 8, 22, 19, 30, 00);
            // Các định dạng date-time được hỗ trợ.
            //string[] formattedStrings = aDateTime.GetDateTimeFormats();

            //foreach (string format in formattedStrings)
            //{
            //    Console.WriteLine(format);
            //}

            //var days= DateTime.DaysInMonth(1980, 08);

            // Console.WriteLine("dateNow : = {0}", dateNow);
            // Console.WriteLine("dateUTCNow : = {0}", dateUTCNow);
            // Console.WriteLine("newDateAdd : = {0}", newDateAdd);
            // Console.WriteLine("newDateAddSpan : = {0}", newDateAddSpan);
            // Console.WriteLine("newDateAddSpan : = {0}", subdate.TotalDays);
            // Console.WriteLine("aDateTime : = {0}", aDateTime.ToString("dd-MM-yy HH:mm:ss"));
            // Console.WriteLine("days : = {0}", days);

            //var myGeneric = new Generic<long>();
            //myGeneric.Tong2So(10, 30);
            //Console.WriteLine("Tong2So : = {0}", myGeneric.Tong2So(10, 30));

            //var myGenericObject = new GenericObject<Employeer>();
            //myGenericObject.MyProperties = new Employeer
            //{ ID = "EP001" };

            //var id = myGenericObject.GetValue().ID;

            //Console.WriteLine("id : = {0}", id);

            //Dictionary<string, string> _phoneBook = new Dictionary<string, string>()
            //    {
            //    {"Trump", "0123.456.789" },
            //    {"Obama", "0987.654.321" },
            //    {"Putin", "0135.246.789" }
            //    };

            //foreach (KeyValuePair<string, string> entry in _phoneBook)
            //{
            //    Console.WriteLine($" -> {entry.Key} : {entry.Value}");
            //}

            //ArrayList arrayList = new ArrayList();
            //arrayList.Add("string");
            //arrayList.Add(true);
            //arrayList.Add(1.5);

            //foreach (var item in arrayList)
            //{
            //    Console.WriteLine("->{0}" , item);
            //}


            //var p = new Bird();
            //Console.WriteLine("Bird Eat -> {0} | Sound -> {1}", p.Eat(),p.GetSound());
            //var c = new Cow();
            //Console.WriteLine("Cow Eat -> {0} | Sound -> {1}", c.Eat(), c.GetSound());

            //var request = new CSharpCoBan.DataAccess.DO.AccountDTO();
            //var repo = new AccountRepository();

            //Console.WriteLine("mời nhập UserName:");
            //request.UserName = Console.ReadLine();

            //Console.WriteLine("mời nhập password:");
            //request.PassWord = Console.ReadLine();


            //Console.WriteLine("Nếu là tài khoản admin nhấn số 1, Không thì nhấn số 0:");
            //var isadmin = Console.ReadLine();
            //var checkIsNumber = CSharpCoban.Common.Validate.CheckNumber(isadmin);
            //if (!checkIsNumber)
            //{
            //    Console.WriteLine("sai định dạng số ");
            //}

            //request.IsAdmin = Convert.ToInt32(isadmin);


            //var result = repo.Account_Insert(request);
            //if (result < 0)
            //{
            //    Console.WriteLine("Thêm mới thất bại");
            //}




            //var list = repo.Account_GetList(new CSharpCoBan.DataAccess.DO.Request.Account_GetistRequestData
            //{
            //    UserName = ""
            //});

            //if (list != null)
            //{
            //    Console.WriteLine("-------Danh sách tài khoản---------------");
            //    foreach (var item in list)
            //    {
            //        Console.WriteLine("-------------------------------------------------------");
            //        Console.WriteLine("UserId: {0} |  UserName: {1} | IsAdmin: {2}", item.UserID, item.UserName, item.IsAdmin);
            //        Console.WriteLine("--------------------------------------------------------");
            //    }
            //}

            //Console.WriteLine("mời nhập UserName cần tìm ");
            //var UserName = Console.ReadLine();

            //var list_search = repo.Account_GetList(new CSharpCoBan.DataAccess.DO.Request.Account_GetistRequestData
            //{
            //    UserName = UserName
            //});

            //if (list_search != null)
            //{
            //    Console.WriteLine("-------Danh sách tài khoản đã search---------------");
            //    foreach (var item in list_search)
            //    {
            //        Console.WriteLine("-------------------------------------------------------");
            //        Console.WriteLine("UserId: {0} |  UserName: {1} | IsAdmin: {2}", item.UserID, item.UserName, item.IsAdmin);
            //        Console.WriteLine("--------------------------------------------------------");
            //    }
            //}


            var repoUser = new UserRepository();
            var list = repoUser.GetList();
            if (list != null)
            {
                Console.WriteLine("-------Danh sách tài khoản---------------");
                foreach (var item in list)
                {
                    Console.WriteLine("-------------------------------------------------------");
                    Console.WriteLine("UserId: {0} |  UserName: {1} | IsAdmin: {2}", item.UserID, item.UserName, item.IsAdmin);
                    Console.WriteLine("--------------------------------------------------------");
                }
            }
            Console.ReadKey();
        }
    }
}