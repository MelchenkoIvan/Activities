
using Microsoft.AspNetCore.Identity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace UnitTestReactivities
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethodLogin()
        {
            
            var userManager = new Mock<UserManager<AppUser>>();
            
        }
    }
}
