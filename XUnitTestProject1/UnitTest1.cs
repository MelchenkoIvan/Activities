using Microsoft.AspNet.Identity;
using Moq;
using System;
using Xunit;

namespace XUnitTestProject1
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var userManager = new Mock<UserManager<AppUser>>();

        }
    }
}
