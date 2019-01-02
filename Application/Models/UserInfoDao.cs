using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Helpers;

namespace Application.Models
{
    public class UserInfoDao
    {
        public static bool Add(UserInfoViewModel model)
        {
            using(var cn=new SqlConnection(Common.CnStr))
            {
                using(var cmd = cn.CreateCommand())
                {
                    cmd.CommandText = "sp_userCRUD";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@FirstName",model.FirstName);
                    cmd.Parameters.AddWithValue("@LastName",model.LastName);
                    cmd.Parameters.AddWithValue("@Email",model.Email);
                    cmd.Parameters.AddWithValue("@Password",Crypto.HashPassword(model.Password));
                    cmd.Parameters.AddWithValue("@Mobile",model.Mobile);
                    cmd.Parameters.AddWithValue("@IsActive", 1);
                    cmd.Parameters.AddWithValue("@Role","User");
                    cmd.Parameters.AddWithValue("@flag", "Insert");
                    cn.Open();
                    cmd.ExecuteNonQuery();
                    cn.Close();
                }
            }
            return true;
        }

        public static UserInfoViewModel IsLogin(string email,string password)
        {
            var obj = new UserInfoViewModel();
            using (var cn = new SqlConnection(Common.CnStr))
            {
                using (var cmd = cn.CreateCommand())
                {
                    cmd.CommandText = "sp_userCRUD";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@flag", "IsLogin");
                    cn.Open();
                    var re=cmd.ExecuteReader();
                    if (re.Read())
                    {
                        var hashPassword = re.GetString(4);
                        var isLogin = Crypto.VerifyHashedPassword(hashPassword, password);
                        if (isLogin)
                        {
                            obj.Id = re.GetInt32(0);
                            obj.FirstName = re.GetString(1);
                            obj.LastName = re.GetString(2);
                            obj.Email = re.GetString(3);
                            obj.Mobile = re.GetString(5);
                            obj.Role = re.GetString(6);
                            obj.IsActive =re.GetByte(7);
                        }
                    }
                    cn.Close();
                }
            }
            return obj;
        }
    }
}