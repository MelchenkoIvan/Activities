using API.Controllers;
using API.DTOs;
using API.DtoValidator;
using API.Services;
using Application.Activities;
using Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Linq;
using System.Reflection;

namespace UnitTestValidateDtos
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestvalidateLoginDtoisTrue()
        {
            bool result;

            ValidateDto validateDto = new ValidateDto() ;
 
            LoginDto loginDto = new LoginDto() {Email ="bob@test.com", Password ="P@$$w0rd" };
            result = validateDto.validateLoginDto(loginDto);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestvalidateRegostrDtoistrue()
        {
            bool result;

            ValidateDto validateDto = new ValidateDto();

            RegisterDto registerDto = new RegisterDto() { Email = "bob@test.com", Password = "P@$$w0rd",DisplayName= "bob", Username= "bob" };
            result = validateDto.validateRegostrDto(registerDto);

            Assert.IsTrue(result);
        }
        [TestMethod]
        public void TestActivityDto()
        {

            bool result;

            ValidateDto validateDto = new ValidateDto();

            ActivityDto activityDto = new ActivityDto() { Title = "sda", Description = "asd", Category = "asdasd", City = "asd" };
            result = validateDto.ActivityDto(activityDto);

            Assert.IsTrue(result);


        }
        [TestMethod]
        public void TestActivityParamsDto()
        {

            bool result;

            ValidateDto validateDto = new ValidateDto();

            ActivityParams activity = new ActivityParams() { IsGoing = true,IsHost = true ,StartDate = DateTime.Now };
            result = validateDto.ActivityParamsDto(activity);

            Assert.IsTrue(result);


        }

    }
}
