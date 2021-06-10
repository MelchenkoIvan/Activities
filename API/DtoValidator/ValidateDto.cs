using API.DTOs;
using Application.Activities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DtoValidator
{
    public class ValidateDto
    {
        public bool validateLoginDto(LoginDto ld)
        {
            if(ld.Email.GetType() == typeof(string) && ld.Password.GetType() == typeof(string))
            {
                return true;
            }
            return false;
        }
        public bool validateRegostrDto(RegisterDto registerDto)
        {
            if (registerDto.Email.GetType() == typeof(string) && registerDto.Password.GetType() == typeof(string) 
                && registerDto.Username.GetType() == typeof(string) && registerDto.DisplayName.GetType() == typeof(string))
            {
                return true;
            }
            return false;
        }
        public bool ActivityDto(ActivityDto activityDto)
        {
            if (activityDto.Title.GetType() == typeof(string) && activityDto.Description.GetType() == typeof(string)&&
                activityDto.Category.GetType() == typeof(string) && activityDto.City.GetType() == typeof(string))
            {
                return true;
            }
            return false;
        }
        public bool ActivityParamsDto(ActivityParams activityParams)
        {
            if (activityParams.IsGoing.GetType() == typeof(bool) && activityParams.IsHost.GetType() == typeof(bool)
                && activityParams.StartDate.GetType() == typeof(DateTime))
            {
                return true;
            }
            return false;
        }

    }
}
