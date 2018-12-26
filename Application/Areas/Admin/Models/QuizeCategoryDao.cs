using Application.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Application.Areas.Admin.Models
{
    public class QuizeCategoryDao
    {
        public static bool Add(QuizeCategoryViewModel model)
        {
            using(var cn=new SqlConnection(Common.CnStr))
            {
                using(var cmd = cn.CreateCommand())
                {
                    cmd.CommandText = "sp_quizeCategoryCRUD";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Name", model.Name);
                    cmd.Parameters.AddWithValue("@flag", "Insert");
                    cn.Open();
                    cmd.ExecuteNonQuery();
                    cn.Close();
                    return true;
                }
            }
        }

        public static List<QuizeCategoryViewModel> Gets()
        {
            var list = new List<QuizeCategoryViewModel>();
            using(var cn=new SqlConnection(Common.CnStr))
            {
                using(var cmd = cn.CreateCommand())
                {
                    cmd.CommandText = "sp_quizeCategoryCRUD";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@flag", "Gets");
                    cn.Open();
                    var re=cmd.ExecuteReader();
                    while (re.Read())
                    {
                        list.Add(new QuizeCategoryViewModel
                        {
                            Id = re.GetInt32(0),
                            Name = re.GetString(1)
                        });
                    }
                    cn.Close();
                }
            }
            return list;
        }

        public static QuizeCategoryViewModel Get(int id)
        {
            var obj = new QuizeCategoryViewModel();
            using (var cn = new SqlConnection(Common.CnStr))
            {
                using (var cmd = cn.CreateCommand())
                {
                    cmd.CommandText = "sp_quizeCategoryCRUD";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", id);
                    cmd.Parameters.AddWithValue("@flag", "Get");
                    cn.Open();
                    var re = cmd.ExecuteReader();
                    if (re.Read())
                    {
                        obj=new QuizeCategoryViewModel
                        {
                            Id = re.GetInt32(0),
                            Name = re.GetString(1)
                        };
                    }
                    cn.Close();
                }
            }
            return obj;
        }
    }
}