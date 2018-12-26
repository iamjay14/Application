using Application.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Application.Areas.Admin.Models
{
    public class QuizeTypeDao
    {
        public static bool Add(QuizeTypeViewModel model)
        {
            using (var cn = new SqlConnection(Common.CnStr))
            {
                using (var cmd = cn.CreateCommand())
                {
                    cmd.CommandText = "sp_QuizeTypeCRUD";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Name", model.Name);
                    cmd.Parameters.AddWithValue("@CategoryId", model.CategoryId);
                    cmd.Parameters.AddWithValue("@flag", "Insert");
                    cn.Open();
                    cmd.ExecuteNonQuery();
                    cn.Close();
                    return true;
                }
            }
        }

        public static List<QuizeTypeViewModel> Gets()
        {
            var list = new List<QuizeTypeViewModel>();
            using (var cn = new SqlConnection(Common.CnStr))
            {
                using (var cmd = cn.CreateCommand())
                {
                    cmd.CommandText = "sp_QuizeTypeCRUD";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@flag", "Gets");
                    cn.Open();
                    var re = cmd.ExecuteReader();
                    while (re.Read())
                    {
                        list.Add(new QuizeTypeViewModel
                        {
                            Id = re.GetInt32(0),
                            Name = re.GetString(1),
                            CategoryId=re.GetInt32(2)
                        });
                    }
                    cn.Close();
                }
            }
            return list;
        }

        public static QuizeTypeViewModel Get(int id)
        {
            var obj = new QuizeTypeViewModel();
            using (var cn = new SqlConnection(Common.CnStr))
            {
                using (var cmd = cn.CreateCommand())
                {
                    cmd.CommandText = "sp_QuizeTypeCRUD";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", id);
                    cmd.Parameters.AddWithValue("@flag", "Get");
                    cn.Open();
                    var re = cmd.ExecuteReader();
                    if (re.Read())
                    {
                        obj = new QuizeTypeViewModel
                        {
                            Id = re.GetInt32(0),
                            Name = re.GetString(1),
                            CategoryId=re.GetInt32(2)
                        };
                    }
                    cn.Close();
                }
            }
            return obj;
        }
    }
}