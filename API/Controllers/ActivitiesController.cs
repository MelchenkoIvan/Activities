using API.DtoValidator;
using Application.Activities;
using Application.Core;
using Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace API.Controllers
{
   
    public class ActivitiesController : BaseApiController
    {

        /** 
    * Controller for manipulations with ACTIVITIES
    */


        /** 
    * Get list of activities COMMAND
    */
        [HttpGet]
        public async Task<IActionResult> GetActivities([FromQuery] ActivityParams param)
        {
            ValidateDto vd = new ValidateDto();
            bool res = vd.ActivityParamsDto(param);
            if (res)
            {
                return HandlePagedResult(await Mediator.Send(new List.Query { Params = param }));
            };
            return StatusCode(500);
        }


        /** 
    * Get activity COMMAND
    */
        [HttpGet("{id}")]
        public async Task<IActionResult> GetActivity(Guid id)
        {
            return HandleResult(await Mediator.Send(new Details.Query { Id = id }));
        }


        /** 
    * Create activity COMMAND
    */

        [HttpPost]
        public async Task<IActionResult> CreateActivity(Activity activity)
        {
            return HandleResult(await Mediator.Send(new Create.Command { Activity = activity }));
        }

        /** 
    * Edit activity COMMAND
    */
        [Authorize(Policy = "IsActivityHost")]
        [HttpPut("{id}")]
        public async Task<IActionResult> EditActivity(Guid id, Activity activity)
        {
            activity.Id = id;
            return HandleResult(await Mediator.Send(new Edit.Command { Activity = activity }));
        }

        /** 
    * Delete activity COMMAND
    */
        [Authorize(Policy = "IsActivityHost")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteActivity(Guid id)
        {
            return HandleResult(await Mediator.Send(new Delete.Command { Id = id }));
        }


        /** 
    * Attend activity COMMAND
    */
        [HttpPost("{id}/attend")]
        public async Task<IActionResult> Attend(Guid id)
        {
            return HandleResult(await Mediator.Send(new UpdateAttendencee.Command { Id = id }));
        }
    }
}
