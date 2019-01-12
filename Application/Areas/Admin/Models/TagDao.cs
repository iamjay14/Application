using Application.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Application.Areas.Admin.Models
{
    public class TagDao
    {
        public static int Add(TagViewModel model)
        {
            using (var cn = new SqlConnection(Common.CnStr))
            {
                using (var cmd = cn.CreateCommand())
                {
                    cmd.CommandText = "sp_tagCRUD";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Name", model.Name);
                    cmd.Parameters.AddWithValue("@CreateDate", model.CreateDate);
                    cmd.Parameters.AddWithValue("@CreatedBy", 1);
                    cmd.Parameters.AddWithValue("@flag", "Insert");
                    cmd.Parameters.AddWithValue("@scope", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cn.Open();
                    cmd.ExecuteNonQuery();
                    int id = (int)cmd.Parameters["@scope"].Value;
                    cn.Close();
                    return id;
                }
            }
        }

        public static List<TagViewModel> Gets()
        {
            var list = new List<TagViewModel>();
            using (var cn = new SqlConnection(Common.CnStr))
            {
                using (var cmd = cn.CreateCommand())
                {
                    cmd.CommandText = "sp_tagCRUD";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@flag", "Gets");
                    cn.Open();
                    var re = cmd.ExecuteReader();
                    while (re.Read())
                    {
                        list.Add(new TagViewModel
                        {
                            Id = re.GetInt32(0),
                            Name = re.GetString(1),
                            CreateDate = re.GetDateTime(2),
                            CreateBy = re.GetInt32(3)
                        });
                    }
                    cn.Close();
                }
            }
            return list;
        }

        public static TagViewModel Get(int id)
        {
            var obj = new TagViewModel();
            using (var cn = new SqlConnection(Common.CnStr))
            {
                using (var cmd = cn.CreateCommand())
                {
                    cmd.CommandText = "sp_tagCRUD";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", id);
                    cmd.Parameters.AddWithValue("@flag", "Get");
                    cn.Open();
                    var re = cmd.ExecuteReader();
                    if (re.Read())
                    {
                        obj.Id = re.GetInt32(0);
                        obj.Name = re.GetString(1);
                        obj.CreateDate = re.GetDateTime(2);
                        obj.CreateBy = re.GetInt32(3);
                    }
                    cn.Close();
                }
            }
            return obj;
        }
    }
}