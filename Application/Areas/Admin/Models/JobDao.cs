﻿using Application.Models;
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
            var tags = String.Join(",", model.TagName);
            using(var cn=new SqlConnection(Common.CnStr))
            {
                using(var cmd = cn.CreateCommand())
                {
                    cmd.CommandText = "sp_jobCRUD";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Title", model.Title);
                    cmd.Parameters.AddWithValue("@Description", model.Description);
                    cmd.Parameters.AddWithValue("@CreatedDate", DateTime.Now);
                    cmd.Parameters.AddWithValue("@CreatedBy", 1);
                    cmd.Parameters.AddWithValue("@ApplyStartDate", model.ApplyStartDate);
                    cmd.Parameters.AddWithValue("@ApplyEndDate", model.ApplyEndDate);
                    cmd.Parameters.AddWithValue("@Fees", model.Fees);
                    cmd.Parameters.AddWithValue("@ExamDate", model.ExamDate);
                    cmd.Parameters.AddWithValue("@Name", tags);
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
                            CreatedDate = re.GetDateTime(3),
                            CreatedBy = re.GetInt32(4),
                            ApplyStartDate = re.GetDateTime(5),
                            ApplyEndDate = re.GetDateTime(6),
                            Fees = re.GetDecimal(7),
                            ExamDate = re.GetDateTime(8)
                        });
                    }
                    cn.Close();
                }
            }
            return list;
        }

        public static JobViewModel Get(int id)
        {
            var obj = new JobViewModel();
            using (var cn = new SqlConnection(Common.CnStr))
            {
                using (var cmd = cn.CreateCommand())
                {
                    cmd.CommandText = "sp_jobCRUD";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", id);
                    cmd.Parameters.AddWithValue("@flag", "Get");
                    cn.Open();
                    var re = cmd.ExecuteReader();
                    if (re.Read())
                    {
                        obj = new JobViewModel
                        {
                            Id = re.GetInt32(0),
                            Title = re.GetString(1),
                            Description = re.GetString(2),
                            CreatedDate = re.GetDateTime(3),
                            CreatedBy = re.GetInt32(4),
                            ApplyStartDate = re.GetDateTime(5),
                            ApplyEndDate = re.GetDateTime(6),
                            Fees = re.GetDecimal(7),
                            ExamDate = re.GetDateTime(8)
                        };
                    }
                    cn.Close();
                }
            }
            return obj;
        }


        public static List<JobViewModel> GetsWithTags()
        {
            var list = new List<JobViewModel>();
            int jid = 0;
            using (var cn = new SqlConnection(Common.CnStr))
            {
                using (var cmd = cn.CreateCommand())
                {
                    cmd.CommandText = "sp_jobCRUD";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@flag", "GetsWithTags");
                    cn.Open();
                    var re = cmd.ExecuteReader();

                    if (re.Read())
                    {
                        jid = re.GetInt32(0);
                        var jList = new JobViewModel();
                        jList.Id = re.GetInt32(0);
                        jList.Title = re.GetString(1);
                        jList.Description = re.GetString(2);
                        jList.CreatedDate = re.GetDateTime(3);
                        jList.CreatedBy = re.GetInt32(4);
                        jList.ApplyStartDate = re.GetDateTime(5);
                        jList.ApplyEndDate = re.GetDateTime(6);
                        jList.Fees = re.GetDecimal(7);
                        jList.ExamDate = re.GetDateTime(8);
                        jList.Tags.Add(
                                    new TagViewModel
                                    {
                                        Id = re.GetInt32(9),
                                        Name=re.GetString(10)
                                    });
                        while (re.Read())
                        {
                            if (jid == re.GetInt32(0))
                            {
                                jList.Tags.Add(
                                    new TagViewModel
                                    {
                                        Id = re.GetInt32(9),
                                        Name = re.GetString(10)
                                    });
                            }
                            else
                            {
                                list.Add(jList);
                                jid = re.GetInt32(0);
                                jList = new JobViewModel();
                                jList.Id = re.GetInt32(0);
                                jList.Title = re.GetString(1);
                                jList.Description = re.GetString(2);
                                jList.CreatedDate = re.GetDateTime(3);
                                jList.CreatedBy = re.GetInt32(4);
                                jList.ApplyStartDate = re.GetDateTime(5);
                                jList.ApplyEndDate = re.GetDateTime(6);
                                jList.Fees = re.GetDecimal(7);
                                jList.ExamDate = re.GetDateTime(8);
                                jList.Tags.Add(
                                            new TagViewModel
                                            {
                                                Id = re.GetInt32(9),
                                                Name = re.GetString(10)
                                            });
                                
                            }
                        }
                        list.Add(jList);
                    }

                    cn.Close();
                }
            }
            return list;
        }


        public static IEnumerable<List<JobViewModel>> SplitList(List<JobViewModel> list, int size)
        {
            for (int i = 0; i < list.Count; i += size)
            {
                yield return list.GetRange(i, Math.Min(size, list.Count - i));
            }
        }
    }
}