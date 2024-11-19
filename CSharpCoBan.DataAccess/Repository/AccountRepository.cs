using CSharpCoBan.DataAccess.DBHelper;
using CSharpCoBan.DataAccess.DO;
using CSharpCoBan.DataAccess.Interface;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpCoBan.DataAccess.Repository
{
    public class AccountRepository : IAccountRepository
    {
        public int Login(string username, string password)
        {
            var result = 0;
            try
            {

                // Bước 1: Mở connection 
                var sqlconn = new SqlConnectionDB();
                var conn = sqlconn.DoConnect();

                // Bước 2: Khởi tạo SQlCommand 
                var cmd = new SqlCommand("SP_AccountLogin", conn);
                // Chỉ cho command biết được đnag dùng store hay dùng commandtext
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                //Bước 3: 
                cmd.Parameters.AddWithValue("@UserName", username);
                cmd.Parameters.AddWithValue("@Password", password);
                cmd.Parameters.Add("@ResponseCode", System.Data.SqlDbType.Int).Direction = System.Data.ParameterDirection.Output;

                //Bước 4:nhận kết quả 
                cmd.ExecuteNonQuery();
                conn.Close();


                if (cmd.Parameters["@ResponseCode"].Value != DBNull.Value)
                {
                    result = Convert.ToInt32(cmd.Parameters["@ResponseCode"].Value);
                }
                else
                {
                    result = 0;
                }

            }
            catch (Exception ex)
            {

                throw;
            }

            return result;
        }

        public int Account_Insert(AccountDTO accountDTO)
        {
            throw new NotImplementedException();
        }


    }
}
