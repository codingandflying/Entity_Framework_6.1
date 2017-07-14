using HQF.Tutorial.EntityFramework.Commons;
using HQF.Tutorial.EntityFramework.Commons.DbContexts;
using Xunit;
using Xunit.Abstractions;

namespace HQF.Tutorial.EntityFramework.xUnitTest
{
    public class PreGeneratedMappingViewsTest : TestBase
    {
        public PreGeneratedMappingViewsTest(ITestOutputHelper outputHelper) : base(outputHelper)
        {
        }

        [Fact]
        public void Start()
        {
            using (var dbContext = new SimpleDbContext())
            {
                foreach (var category in dbContext.Categories)
                    TestOutputHelper.WriteLine("Hello, {0} {1}", category.Name, category.Description);
            }
        }

        [Fact]
        public void StartWithPreGenerate()
        {
            using (var dbContext = new SimpleDbContext())
            {
                foreach (var category in dbContext.Categories)
                    TestOutputHelper.WriteLine("Hello, {0} {1}", category.Name, category.Description);
            }
        }
    }
}