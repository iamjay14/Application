using Application.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Application.Areas.Admin.Models
{
    public class QuestionChoiceDao
    {
        public static bool Add(QuestionChoiceViewModel model)
        {
            using (var cn = new SqlConnection(Common.CnStr))
            {
                using (var cmd = cn.CreateCommand())
                {
                    cmd.CommandText = "sp_QuestionChoiceCRUD";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@QuestionId", model.QuestionId);
                    cmd.Parameters.AddWithValue("@Choice", model.Choice);
                    cmd.Parameters.AddWithValue("@IsRight", model.IsRight);
                    cmd.Parameters.AddWithValue("@flag", "Insert");
                    cn.Open();
                    cmd.ExecuteNonQuery();
                    cn.Close();
                    return true;
                }
            }
        }

        public static List<QuestionChoiceViewModel> Gets()
        {
            var list = new List<QuestionChoiceViewModel>();
            using (var cn = new SqlConnection(Common.CnStr))
            {
                using (var cmd = cn.CreateCommand())
                {
                    cmd.CommandText = "sp_QuestionChoiceCRUD";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@flag", "Gets");
                    cn.Open();
                    var re = cmd.ExecuteReader();
                    while (re.Read())
                    {
                        list.Add(new QuestionChoiceViewModel
                        {
                            Id = re.GetInt32(0),
                            QuestionId=re.GetInt32(1),
                            Choice=re.GetString(2),
                            IsRight=re.GetByte(3)
                        });
                    }
                    cn.Close();
                }
            }
            return list;
        }

        public static QuestionChoiceViewModel Get(int id)
        {
            var obj = new QuestionChoiceViewModel();
            using (var cn = new SqlConnection(Common.CnStr))
            {
                using (var cmd = cn.CreateCommand())
                {
                    cmd.CommandText = "sp_QuestionChoiceCRUD";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", id);
                    cmd.Parameters.AddWithValue("@flag", "Get");
                    cn.Open();
                    var re = cmd.ExecuteReader();
                    if (re.Read())
                    {
                        obj = new QuestionChoiceViewModel
                        {
                            Id = re.GetInt32(0),
                            QuestionId = re.GetInt32(1),
                            Choice = re.GetString(2),
                            IsRight = re.GetByte(3)
                        };
                    }
                    cn.Close();
                }
            }
            return obj;
        }
    }
}

