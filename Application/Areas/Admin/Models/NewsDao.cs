using Application.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Application.Areas.Admin.Models
{
    public class NewsDao
    {
        public static bool Add(NewsViewModel model)
        {
            var tags = String.Join(",", model.TagName);
            using (var cn = new SqlConnection(Common.CnStr))
            {
                using (var cmd = cn.CreateCommand())
                {
                    cmd.CommandText = "sp_newsCRUD";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Title", model.Title);
                    cmd.Parameters.AddWithValue("@Description", model.Description);
                    cmd.Parameters.AddWithValue("@CreatedDate", DateTime.Now);
                    cmd.Parameters.AddWithValue("@CreatedBy", 1);
                    cmd.Parameters.AddWithValue("@Name", tags);
                    cmd.Parameters.AddWithValue("@flag", "Insert");
                    cn.Open();
                    cmd.ExecuteNonQuery();
                    cn.Close();
                }
            }
            return true;
        }

        public static List<NewsViewModel> Gets()
        {
            var list = new List<NewsViewModel>();
            using (var cn = new SqlConnection(Common.CnStr))
            {
                using (var cmd = cn.CreateCommand())
                {
                    cmd.CommandText = "sp_newsCRUD";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@flag", "Gets");
                    cn.Open();
                    var re = cmd.ExecuteReader();
                    while (re.Read())
                    {
                        list.Add(new NewsViewModel
                        {
                            Id = re.GetInt32(0),
                            Title = re.GetString(1),
                            Description = re.GetString(2),
                            CreatedDate = re.GetDateTime(3),
                            CreatedBy = re.GetInt32(4)
                        });
                    }
                    cn.Close();
                }
            }
            return list;
        }

        public static NewsViewModel Get(int id)
        {
            var obj =new NewsViewModel();
            using (var cn = new SqlConnection(Common.CnStr))
            {
                using (var cmd = cn.CreateCommand())
                {
                    cmd.CommandText = "sp_newsCRUD";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", id);
                    cmd.Parameters.AddWithValue("@flag", "Get");
                    cn.Open();
                    var re = cmd.ExecuteReader();
                    if (re.Read())
                    {
                        obj = new NewsViewModel
                        {
                            Id = re.GetInt32(0),
                            Title = re.GetString(1),
                            Description = re.GetString(2),
                            CreatedDate = re.GetDateTime(3),
                            CreatedBy = re.GetInt32(4)
                        };
                    }
                    cn.Close();
                }
            }
            return obj;
        }
    }
}