using Application.Areas.Admin.Models;
using Application.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Application.Areas.Admin.Models
{
    public class QuestionDao
    {
        public static bool Add(QuestionViewModel model,string Choice1, string Choice2, string Choice3, string Choice4,int IsRight)
        {
            using (var cn = new SqlConnection(Common.CnStr))
            {
                using (var cmd = cn.CreateCommand())
                {
                    cmd.CommandText = "sp_QuestionCRUD";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Name", model.Name);
                    cmd.Parameters.AddWithValue("@IsActive", model.IsActive);
                    cmd.Parameters.AddWithValue("@QuizeTypeId", model.QuizeTypeId);
                    cmd.Parameters.AddWithValue("@Choice1", Choice1);
                    cmd.Parameters.AddWithValue("@Choice2", Choice2);
                    cmd.Parameters.AddWithValue("@Choice3", Choice3);
                    cmd.Parameters.AddWithValue("@Choice4", Choice4);
                    cmd.Parameters.AddWithValue("@IsRight", IsRight);
                    cmd.Parameters.AddWithValue("@flag", "Insert");
                    cn.Open();
                    cmd.ExecuteNonQuery();
                    cn.Close();
                    return true;
                }
            }
        }

        public static List<QuestionViewModel> Gets()
        {
            var list = new List<QuestionViewModel>();
            using (var cn = new SqlConnection(Common.CnStr))
            {
                using (var cmd = cn.CreateCommand())
                {
                    cmd.CommandText = "sp_QuestionCRUD";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@flag", "Gets");
                    cn.Open();
                    var re = cmd.ExecuteReader();
                    while (re.Read())
                    {
                        list.Add(new QuestionViewModel
                        {
                            Id = re.GetInt32(0),
                            Name = re.GetString(1),
                            IsActive=re.GetByte(2),
                            QuizeTypeId=re.GetInt32(3)
                        });
                    }
                    cn.Close();
                }
            }
            return list;
        }

        public static QuestionViewModel Get(int id)
        {
            var obj = new QuestionViewModel();
            using (var cn = new SqlConnection(Common.CnStr))
            {
                using (var cmd = cn.CreateCommand())
                {
                    cmd.CommandText = "sp_QuestionCRUD";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", id);
                    cmd.Parameters.AddWithValue("@flag", "Get");
                    cn.Open();
                    var re = cmd.ExecuteReader();
                    if (re.Read())
                    {
                        obj = new QuestionViewModel
                        {
                            Id = re.GetInt32(0),
                            Name = re.GetString(1),
                            IsActive = re.GetByte(2),
                            QuizeTypeId = re.GetInt32(3)
                        };
                    }
                    cn.Close();
                }
            }
            return obj;
        }

        public static List<QuestionViewModel> GetsQuize(int id)
        {
            var list = new List<QuestionViewModel>();
            int qid = 0;
            using (var cn = new SqlConnection(Common.CnStr))
            {
                using (var cmd = cn.CreateCommand())
                {
                    cmd.CommandText = "sp_QuestionCRUD";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@QuizeTypeId", id);
                    cmd.Parameters.AddWithValue("@flag", "GetQuestion");
                    cn.Open();
                    var re = cmd.ExecuteReader();
                    if (re.Read())
                    {
                        qid = re.GetInt32(2);
                        var cList = new QuestionViewModel();
                        cList.QuizeTypeId = re.GetInt32(0);
                        cList.Id = re.GetInt32(2);
                        cList.Name = re.GetString(3);
                        cList.Choices.Add(
                                    new QuestionChoiceViewModel
                                    {
                                        Id = re.GetInt32(4),
                                        Choice = re.GetString(5),
                                        IsRight = Convert.ToByte(re["IsRight"].ToString() == "1" ? 1 : 0)
                                    });
                        while (re.Read())
                        {
                            if (qid == re.GetInt32(2))
                            {
                                cList.Choices.Add(
                                    new QuestionChoiceViewModel
                                    {
                                        Id = re.GetInt32(4),
                                        Choice = re.GetString(5),
                                        IsRight = Convert.ToByte(re["IsRight"].ToString() == "1" ? 1 : 0)
                                    });
                            }
                            else
                            {
                                list.Add(cList);
                                qid = re.GetInt32(2);
                                cList = new QuestionViewModel();
                                cList.QuizeTypeId = re.GetInt32(0);
                                cList.Id = re.GetInt32(2);
                                cList.Name = re.GetString(3);
                                cList.Choices.Add(
                                    new QuestionChoiceViewModel
                                    {
                                        Id = re.GetInt32(4),
                                        Choice = re.GetString(5),
                                        IsRight = Convert.ToByte(re["IsRight"].ToString() == "1" ? 1 : 0)
                                    });
                            }
                        }
                    }
                    
                    cn.Close();
                }
            }
            return list;
        }

        public static List<QuestionChoiceViewModel> GetsQuizeChoiceData(int id)
        {
            var list = new List<QuestionChoiceViewModel>();
            
            using (var cn = new SqlConnection(Common.CnStr))
            {
                using (var cmd = cn.CreateCommand())
                {
                    cmd.CommandText = "sp_QuestionCRUD";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@QuizeTypeId", id);
                    cmd.Parameters.AddWithValue("@flag", "GetQuestion");
                    cn.Open();
                    var re = cmd.ExecuteReader();
                    while (re.Read())
                    {
                        list.Add(new QuestionChoiceViewModel
                        {
                            QuestionId=re.GetInt32(2),
                            Id = re.GetInt32(4),
                            Choice = re.GetString(5),
                            IsRight = Convert.ToByte(re["IsRight"].ToString()=="1"?1:0)
                        });
                    }
                    cn.Close();
                }
            }
            return list;
        }

        public static IEnumerable<List<QuestionViewModel>> SplitList(List<QuestionViewModel> list, int size)
        {
            for (int i = 0; i < list.Count; i += size)
            {
                yield return list.GetRange(i, Math.Min(size, list.Count - i));
            }
        }
    }
}