using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit.Abstractions;

namespace HQF.Tutorial.EntityFramework.xUnitTest
{
    public class TestBase
    {
        protected ITestOutputHelper TestOutputHelper { get;  }

        public TestBase(ITestOutputHelper outputHelper)
        {
            TestOutputHelper = outputHelper;
        }
    }
}
