using CSharpCoBan.DataAccess.DBHelper;
using CSharpCoBan.DataAccess.DO;
using CSharpCoBan.DataAccess.DO.Request;
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
            var result = 0;
            try
            {
                // Bước 1: Mở connection 
                var sqlconn = new SqlConnectionDB();
                var conn = sqlconn.DoConnect();

                // Bước 2: Khởi tạo SQlCommand 
                var cmd = new SqlCommand("SP_User_Insert", conn);
                // Chỉ cho command biết được đnag dùng store hay dùng commandtext
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                //Bước 3: truyền tham số 
                cmd.Parameters.AddWithValue("@UserName", accountDTO.UserName);
                cmd.Parameters.AddWithValue("@Password", accountDTO.PassWord);
                cmd.Parameters.AddWithValue("@IsAdmin", accountDTO.IsAdmin);
                cmd.Parameters.Add("@ResponseCode", System.Data.SqlDbType.Int).Direction = System.Data.ParameterDirection.Output;


                //Bước 4:nhận kết quả 

                // -Nếu là các câu lệnh làm thay đổi dữ liệu(insert / update / delete)

                //sẽ nhận kết quả ở hàm excecuteNonQuery->trả về số dòng được thay đổi
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
            catch (Exception)
            {

                throw;
            }

            return result;
        }

        public List<AccountDTO> Account_GetList(Account_GetistRequestData requestData)
        {
            var list = new List<AccountDTO>();
            try
            {
                // Bước 1: Mở connection 
                var sqlconn = new SqlConnectionDB();
                var conn = sqlconn.DoConnect();

                // Bước 2: Khởi tạo SQlCommand 
                var cmd = new SqlCommand("SP_User_GetList", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                // //Bước 3: thêm param cho store procedure 
                cmd.Parameters.AddWithValue("@UserName", requestData.UserName);

                //Bước 4:nhận kết quả ở excecuteReader
                //-Nếu là các câu lệnh không làm thay đổi dữ liệu (select) thì nhận kết quả ở hàm
                // excecuteReader->trả về danh sách dạng table
                var rs = cmd.ExecuteReader();

                // 4.1 thực hiện đọc ExecuteReader và convert nó sang  List<AccountDTO> 

                while (rs.Read())
                {
                    var account = new AccountDTO();
                    var userId = rs["UserID"] != null ? Convert.ToInt32(rs["UserID"]) : 0;
                    var userName = rs["UserName"] != null ? rs["UserName"].ToString() : "";
                    var isAdmin = rs["IsAdmin"] != null ? Convert.ToInt32(rs["IsAdmin"]) : 0;

                    account.UserID = userId;
                    account.UserName = userName;
                    account.IsAdmin = isAdmin;

                    list.Add(account);
                }


            }
            catch (Exception ex)
            {

                throw;
            }

            return list;
        }
    }
}
