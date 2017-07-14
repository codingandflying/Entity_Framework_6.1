using System.Linq;
using HQF.Tutorial.EntityFramework.Commons.DbContexts;
using Xunit;
using Xunit.Abstractions;

namespace DbLinqFunctions
{
    public class DbFunctionTest
    {
        public DbFunctionTest(ITestOutputHelper outputHelper)
        {
            _outputHelper = outputHelper;
        }

        private readonly ITestOutputHelper _outputHelper;

        [Fact]
        public void GroupByCreateDate()
        {
            using (var db = new TreeNodeDbContext())
            {
                //using System.Data.Entity.DbFunctions.TruncateTime to extract date from datetime.
                var mydate = from node in db.TreeNodes
                    group node by System.Data.Entity.DbFunctions.TruncateTime(node.CreateTime)
                    into g
                    select new {g.Key, CategoryCount = g.Count()};

                foreach (var data in mydate)
                    _outputHelper.WriteLine("{0} ,[{1}]", data.Key, data.CategoryCount);
            }
        }

        [Fact]
        public void GroupByCreateDateAndParentId()

        {
            using (var db = new TreeNodeDbContext())
            {
                var mydate = from node in db.TreeNodes
                    group node by System.Data.Entity.DbFunctions.TruncateTime(node.CreateTime)
                    into g
                    select new
                    {
                        g.Key,
                        RootCount = g.Count(t => t.ParentId == 0),
                        SubLevelCount = g.Count(t => t.ParentId != 0)
                    };

                foreach (var data in mydate)
                    _outputHelper.WriteLine("{0} ,[{1}],[{2}]", data.Key, data.RootCount, data.SubLevelCount);


            }
        }


        [Fact]
        public void GroupByCreateTime()
        {
            using (var db = new TreeNodeDbContext())
            {
                var mydate = from node in db.TreeNodes
                    group node by node.CreateTime
                    into g
                    select new {g.Key, CategoryCount = g.Count()};

                foreach (var data in mydate)
                    _outputHelper.WriteLine(data.Key.ToLongDateString() + data.CategoryCount);
            }
        }
    }
}