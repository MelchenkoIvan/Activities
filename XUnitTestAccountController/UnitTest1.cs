using API.DTOs;
using API.Services;
using Domain;
using Fluent.Infrastructure.FluentModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace XUnitTestAccountController
{
    public class UnitTest1
    {
        private Mock<UserManager<AppUser>> _userManager;
        private Mock<SignInManager<AppUser>> _signInManager;
        private Mock<TokenService> _tokenService;

        public static Mock<UserManager<TUser>> MockUserManager<TUser>(List<TUser> ls) where TUser : class
        {
            var store = new Mock<IUserStore<TUser>>();
            var mgr = new Mock<UserManager<TUser>>(store.Object, null, null, null, null, null, null, null, null);
            mgr.Object.UserValidators.Add(new UserValidator<TUser>());
            mgr.Object.PasswordValidators.Add(new PasswordValidator<TUser>());

            mgr.Setup(x => x.DeleteAsync(It.IsAny<TUser>())).ReturnsAsync(IdentityResult.Success);
            mgr.Setup(x => x.CreateAsync(It.IsAny<TUser>(), It.IsAny<string>())).ReturnsAsync(IdentityResult.Success).Callback<TUser, string>((x, y) => ls.Add(x));
            mgr.Setup(x => x.UpdateAsync(It.IsAny<TUser>())).ReturnsAsync(IdentityResult.Success);

            return mgr;
        }

        [Fact]
        public void Handle_GivenValidInput_ReturnsCreatedResponse(LoginDto loginDto)
        {
            var newUser = new AppUser() { Email = "bob@test.com" };
            var password = "P@ssw0rd";

            var user =  _userManager.Setup(a =>  a.Users.FirstOrDefault(x => x.Email == loginDto.Email));
           

            var result = _signInManager.Setup(b => b.CheckPasswordSignInAsync(user, loginDto.Password, false)) ;


            Assert.Equal(2, model.Count());

        }

         
        List<LoginDto> lDto = new List<LoginDto>
        {
            new LoginDto(){Email = "bob@test.com", Password ="P@ssw0rd"},
            new LoginDto(){Email = "tom@test.com", Password ="P@ssw0rd"}
        };
       
        

    }
}
