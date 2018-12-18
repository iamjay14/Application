using Application.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Application.Areas.Admin.Models
{
    public class JobDao
    {
        public static bool Add(JobViewModel model)
        {
            using(var cn=new SqlConnection(Common.CnStr))
            {
                using(var cmd = cn.CreateCommand())
                {
                    cmd.CommandText = "sp_jobCRUD";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Title", model.Title);
                    cmd.Parameters.AddWithValue("@Description", model.Description);
                    cmd.Parameters.AddWithValue("@TagId", 1);
                    cmd.Parameters.AddWithValue("@CreatedDate", DateTime.Now);
                    cmd.Parameters.AddWithValue("@CreatedBy", 1);
                    cmd.Parameters.AddWithValue("@ApplyStartDate", model.ApplyStartDate);
                    cmd.Parameters.AddWithValue("@ApplyEndDate", model.ApplyEndDate);
                    cmd.Parameters.AddWithValue("@Fees", model.Fees);
                    cmd.Parameters.AddWithValue("@ExamDate", model.ExamDate);
                    cmd.Parameters.AddWithValue("@flag", "Insert");
                    cn.Open();
                    cmd.ExecuteNonQuery();
                    cn.Close();
                }
            }
            return true;
        }

        public static List<JobViewModel> Gets()
        {
            var list = new List<JobViewModel>();
            using(var cn=new SqlConnection(Common.CnStr))
            {
                using(var cmd = cn.CreateCommand())
                {
                    cmd.CommandText = "sp_jobCRUD";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@flag", "Gets");
                    cn.Open();
                    var re = cmd.ExecuteReader();
                    while (re.Read())
                    {
                        list.Add(new JobViewModel
                        {
                            Id = re.GetInt32(0),
                            Title = re.GetString(1),
                            Description = re.GetString(2),
                            TagId = re.GetInt32(3),
                            CreatedDate = re.GetDateTime(4),
                            CreatedBy = re.GetInt32(5),
                            ApplyStartDate = re.GetDateTime(6),
                            ApplyEndDate = re.GetDateTime(7),
                            Fees = re.GetDecimal(8),
                            ExamDate = re.GetDateTime(9)
                        });
                    }
                    cn.Close();
                }
            }
            return list;
        }
    }
}