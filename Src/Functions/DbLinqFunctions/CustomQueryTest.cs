using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HQF.Tutorial.EntityFramework.Commons.DbContexts;
using Xunit;
using Xunit.Abstractions;

namespace DbLinqFunctions
{
   public class CustomQueryTest
   {

       private ITestOutputHelper _outputHelper;

       public CustomQueryTest(ITestOutputHelper outputHelper)
       {
           _outputHelper = outputHelper;
       }

       [Fact]
        public void TestCustomQuery()
        {
            using (var db = new TreeNodeDbContext())
            {
                var sql = @"SELECT CONVERT(date,CreateTime) as  [Day],
                COUNT(CASE WHEN ParentId = 0 then 1 else 0 end) As RootCount,
                    COUNT(CASE WHEN ParentId != 0 then 1 else 0 end) As SubCount
                FROM[TreeNodes]
                Group by  CONVERT(date, CreateTime)";

               var datas= db.Database.SqlQuery<SummaryInfo>(sql);

                foreach (var data in datas)
                {
                    _outputHelper.WriteLine("Day [{0}],RootCount[{1}],SubCount[{2}]",
                        data.Day,data.RootCount,data.SubCount);

                }


            }
        }

       [Fact]
       public void TestCustomQueryWithParameters()
       {
           using (var db = new TreeNodeDbContext())
           {
               var sql = @"SELECT CONVERT(date,CreateTime) as  [Day],
                COUNT(CASE WHEN ParentId = 0 then 1 else 0 end) As RootCount,
                    COUNT(CASE WHEN ParentId != 0 then 1 else 0 end) As SubCount
                FROM[TreeNodes]
                Where CreateTime>=@beginTime And CreateTime<=@endTime
                Group by  CONVERT(date, CreateTime)";

                var paras=new List<SqlParameter>();
                paras.Add(new SqlParameter("beginTime",DateTime.Parse("2017-02-01")));
                paras.Add(new SqlParameter("endTime",DateTime.Parse("2017-02-01")));

               var datas = db.Database.SqlQuery<SummaryInfo>(sql,paras.ToArray<object>());

               foreach (var data in datas)
               {
                   _outputHelper.WriteLine("Day [{0}],RootCount[{1}],SubCount[{2}]",
                       data.Day, data.RootCount, data.SubCount);

               }


           }
       }

    }

    class SummaryInfo
    {
        public DateTime Day { get; set; }

        public int RootCount { get; set; }

        public int SubCount { get; set; }
    }
}
