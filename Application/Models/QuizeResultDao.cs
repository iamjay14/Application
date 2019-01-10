using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Application.Models
{
    public class QuizeResultDao
    {
        public static bool Add(QuizeResultViewModel model)
        {
            using(var cn=new SqlConnection(Common.CnStr))
            {
                using(var cmd = cn.CreateCommand())
                {
                    cmd.CommandText = "sp_quizeResultCRUD";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@QuizeTypeId", model.QuizeTypeId);
                    cmd.Parameters.AddWithValue("@UserId", model.UserId);
                    cmd.Parameters.AddWithValue("@Attempt", model.Attempt);
                    cmd.Parameters.AddWithValue("@Result", model.Result);
                    cmd.Parameters.AddWithValue("@flag", "Insert");
                    cn.Open();
                    cmd.ExecuteNonQuery();
                    cn.Close();
                }
            }
            return true;
        }

        public static List<QuizeResultViewModel> GetsByUser(int qid,int uid)
        {
            var list = new List<QuizeResultViewModel>();
            using (var cn = new SqlConnection(Common.CnStr))
            {
                using (var cmd = cn.CreateCommand())
                {
                    cmd.CommandText = "sp_quizeResultCRUD";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@QuizeTypeId", qid);
                    cmd.Parameters.AddWithValue("@UserId", uid);
                    cmd.Parameters.AddWithValue("@flag", "GetsByUser");
                    cn.Open();
                    var re=cmd.ExecuteReader();
                    while (re.Read())
                    {
                        list.Add(new QuizeResultViewModel
                        {
                            Id = re.GetInt32(0),
                            QuizeTypeId = re.GetInt32(1),
                            UserId = re.GetInt32(2),
                            Attempt = re.GetInt32(3),
                            Result = re.GetDecimal(4)
                        });
                    }
                    cn.Close();
                }
            }
            return list;
        }
    }
}