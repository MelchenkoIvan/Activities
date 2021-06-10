using Microsoft.AspNetCore.Identity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using Xunit;


namespace UnitTestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        [Fact]
        public void TestMethodLogin()
        {
            var userManager = new Mock<UserManager<AppUser>>();
        }
    }
}
