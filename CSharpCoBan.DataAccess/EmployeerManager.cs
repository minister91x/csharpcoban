
using CSharpCoBan.DataAccess.STRUCT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CSharpCoBan.DataAccess
{
    public class EmployeerManager
    {
        List<Employeer> list = new List<Employeer>();

        public string Employeer_Insert(string id, string name, string ngaysinh, string ngayvao, string heso)
        {
            var checkId = CSharpCoban.Common.Validate.CheckID(id);
            if (checkId == false)
            {
                return "ID không hợp lệ";
            }

            var checkName = CSharpCoban.Common.Validate.CheckString(name);
            if (checkName == false)
            {
                return "Tên không hợp lệ";
            }

            var checkngaysinh = CSharpCoban.Common.Validate.CheckDateTime(ngaysinh);
            if (checkngaysinh == false)
            {
                return "Ngày sinh không hợp lệ";
            }
            var checkngayvao = CSharpCoban.Common.Validate.CheckDateTime(ngayvao);
            if (checkngayvao == false)
            {
                return "Ngày vào không hợp lệ";
            }

            var checkheso = CSharpCoban.Common.Validate.CheckHeSo(heso);
            if (checkheso == false)
            {
                return "Hệ số không hợp lệ";
            }
            DateTime dateofbith;
            // Khởi tạo Struct 
            var empl = new Employeer();
            empl.ID = id;
            empl.HoVaTen = name;
            empl.NgaySinh = DateTime.ParseExact(ngaysinh, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
            empl.NgayVao = DateTime.ParseExact(ngaysinh, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
            empl.Heso = Convert.ToInt32(heso);

            list.Add(empl);

            return "Thêm mới thành công !";
        }

        public List<Employeer> Employeer_GetList()
        {
            //var list_emp = new List<Employeer>();
            // if (list.Count > 0)
            // {
            //     list_emp = list;

            // }
            // return list_emp;

            return list;
        }

    }
}
