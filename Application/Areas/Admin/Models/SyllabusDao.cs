using Application.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Application.Areas.Admin.Models
{
    public class SyllabusDao
    {
        public static bool Add(SyllabusViewModel model)
        {
            var tags = String.Join(",", model.Name);
            using (var cn = new SqlConnection(Common.CnStr))
            {
                using (var cmd = cn.CreateCommand())
                {
                    cmd.CommandText = "sp_syllabusCRUD";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ExamId", model.ExamId);
                    cmd.Parameters.AddWithValue("@Title", model.Title);
                    cmd.Parameters.AddWithValue("@Link", model.Link);
                    cmd.Parameters.AddWithValue("@CreateDate", DateTime.Now);
                    cmd.Parameters.AddWithValue("@CreateBy", SessionWrapper.UserId);
                    cmd.Parameters.AddWithValue("@Name", tags);
                    cmd.Parameters.AddWithValue("@flag", "Insert");
                    cn.Open();
                    cmd.ExecuteNonQuery();
                    cn.Close();
                }
            }
            return true;
        }

        public static List<SyllabusViewModel> Gets()
        {
            var list = new List<SyllabusViewModel>();
            using (var cn = new SqlConnection(Common.CnStr))
            {
                using (var cmd = cn.CreateCommand())
                {
                    cmd.CommandText = "sp_syllabusCRUD";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@flag", "Gets");
                    cn.Open();
                    var re = cmd.ExecuteReader();
                    while (re.Read())
                    {
                        list.Add(new SyllabusViewModel
                        {
                            Id = re.GetInt32(0),
                            ExamId = re.GetInt32(1),
                            Title = re.GetString(2),
                            Link = re.GetString(3),
                            CreateDate = re.GetDateTime(4),
                            CreateBy = re.GetInt32(5)
                        });
                    }
                    cn.Close();
                }
            }
            return list;
        }

        public static SyllabusViewModel Get(int id)
        {
            var obj = new SyllabusViewModel();
            using (var cn = new SqlConnection(Common.CnStr))
            {
                using (var cmd = cn.CreateCommand())
                {
                    cmd.CommandText = "sp_syllabusCRUD";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", id);
                    cmd.Parameters.AddWithValue("@flag", "Get");
                    cn.Open();
                    var re = cmd.ExecuteReader();
                    if (re.Read())
                    {
                        obj = new SyllabusViewModel
                        {
                            Id = re.GetInt32(0),
                            ExamId = re.GetInt32(1),
                            Title = re.GetString(2),
                            Link = re.GetString(3),
                            CreateDate = re.GetDateTime(4),
                            CreateBy = re.GetInt32(5)
                        };
                    }
                    cn.Close();
                }
            }
            return obj;
        }
    }
}