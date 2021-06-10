using API.Controllers;
using API.DTOs;
using API.Services;
using Domain;
using Microsoft.AspNetCore.Identity;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace XUnitTestActivitiesController
{
    public class UnitTest1
    {
        [Fact]
        public async Task RegisterNewUser_ReturnUser_WhenValidModelPosted()
        {
            

            var mockUserManager = new Mock<UserManager<AppUser>>();
            var signInManager = new Mock<SignInManager<AppUser>>();
            var tokenService = new Mock<TokenService>();
            mockUserManager
                .Setup(x => x.CreateAsync(It.IsAny<AppUser>(), It.IsAny<string>()))
                .ReturnsAsync(IdentityResult.Success);

            var sut = new AccountController(mockUserManager.Object, signInManager.Object, tokenService.Object);
            sut.ModelState.AddModelError("", "invalid data");


            var actual = await sut.Register(registerDto);

            var viewResult = Assert.IsType<UserDto>(actual);
            var model = Assert.IsAssignableFrom<List<UserDto>>(viewResult);
            Assert.Same(registerDto, model);


        }
        RegisterDto registerDto = new RegisterDto() { DisplayName = "Iavnnb", Email = "testtt@test.com", Password = "P@$$w0rd", Username = "BlakaKab" };

    }
}
