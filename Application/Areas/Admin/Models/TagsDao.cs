using Application.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Application.Areas.Admin.Models
{
    public class TagsDao
    {
        public static bool Add(TagsViewModel model)
        {
            using (var cn = new SqlConnection(Common.CnStr))
            {
                using (var cmd = cn.CreateCommand())
                {
                    cmd.CommandText = "sp_tagsCRUD";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@TypeId", model.TypeId);
                    cmd.Parameters.AddWithValue("@Type", model.Type);
                    cmd.Parameters.AddWithValue("@TagId", model.TagId);
                    cmd.Parameters.AddWithValue("@flag", "Insert");
                    cn.Open();
                    cmd.ExecuteNonQuery();
                    cn.Close();
                }
            }
            return true;
        }

        public static List<TagsViewModel> Gets()
        {
            var list = new List<TagsViewModel>();
            using (var cn = new SqlConnection(Common.CnStr))
            {
                using (var cmd = cn.CreateCommand())
                {
                    cmd.CommandText = "sp_tagsCRUD";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@flag", "Gets");
                    cn.Open();
                    var re = cmd.ExecuteReader();
                    while (re.Read())
                    {
                        list.Add(new TagsViewModel
                        {
                            Id = re.GetInt32(0),
                            TypeId = re.GetInt32(1),
                            Type = re.GetString(2),
                            TagId = re.GetInt32(3)
                        });
                    }
                    cn.Close();
                }
            }
            return list;
        }
    }
}