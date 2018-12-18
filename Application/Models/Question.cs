using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Application.Models
{
    public class QuestionViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class QuestionDao
    {
        public static List<QuestionViewModel> Gets()
        {
            var list = new List<QuestionViewModel>();
            using(var cn = new SqlConnection(@"Data Source=(LocalDb)\MSSQLLocalDb;Initial Catalog=QuizeDb;Integrated Security=True"))
            {
                using(var cmd = cn.CreateCommand())
                {
                    cmd.CommandText = "select * from Question";
                    cn.Open();
                    var re = cmd.ExecuteReader();
                    if (re.Read())
                    {
                        list.Add(new QuestionViewModel
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
    }
}