﻿using CSharpCoban.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpCoBan.DataAccess
{
    public class Function
    {
        /// <summary>
        /// Hàm dạng tham trị
        /// </summary>
        /// <param name="sothunhat"></param>
        /// <param name="sothu2"></param>
        /// <returns></returns>
        public int TinhTong(string sothunhat, string sothu2)
        {
            var validate = new CSharpCoban.Common.Validate();
            try
            {
                var isvalidFirstNumber = validate.ValidateInputData(sothunhat);
                if (isvalidFirstNumber == false)
                {
                    return -1;
                }

                var isvalidSecondNumber = validate.ValidateInputData(sothu2);
                if (isvalidSecondNumber == false)
                {
                    return -2;
                }


                return Convert.ToInt32(sothunhat) + Convert.ToInt32(sothu2);

            }
            catch (Exception ex)
            {

                throw ex;
               
            }
        }

        public void Tong_ThamChieu(ref int so)
        {
            so = so * so;
        }

        public void Tong_ThamChieu_Out(out int so)
        {
            so = 1500;
        }

        public  void UserInput(string s)
        {
            if (s.Length > 2)
            {
                Exception e = new DataTooLongExeption();
                throw e;    // lỗi văng ra
            }
            //Other code - no exeption
        }

    }
}