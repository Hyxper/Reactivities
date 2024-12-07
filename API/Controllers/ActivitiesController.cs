
using Microsoft.AspNetCore.Mvc;
using Domain;
using Application.Activities;
using Application.Validators;

namespace API.Controllers
{
    [ApiController]
    public class ActivitiesController : BaseApiController
    { 
        [HttpGet]
        public async Task<ActionResult<List<Activity>>> GetActivities(CancellationToken ct)
        {
            return await Mediator.Send(new List.Query(), ct);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetActivity([FromRoute] Guid id)
        {
            var data = await Mediator.Send(new Details.Query { Id = id });

            if(data.Id == Guid.Empty)
            {
                return NotFound();
            }
            else
            {
                return Ok(data);
            }
        }

        [HttpPost]
        // [FromBody] is used to bind the request body to the parameter. ApiController attribute is smart enough to know that the parameter is coming from the body of the request, so we don't need to specify it.
        public async Task<IActionResult> CreateActivity(Activity activity)
        {
            //could use model state to check if the model is valid, or a third party library like FluentValidation to check my activity is real.

            var validator = new ActivityValidator.RequiredFieldsValidator();
            
            try
            {
                await Mediator.Send(new Create.Command { Activity = activity });
                return Ok();
            }
            catch (NullReferenceException)
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditActivity([FromRoute] Guid id, [FromBody]Activity activity)
        {
            try
            {
                activity.Id = id;
                await Mediator.Send(new Edit.Command { Activity = activity });
                return Ok();
            }
            catch (NullReferenceException)
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteActivity([FromRoute] Guid id)
        {
            try
            {
                await Mediator.Send(new Delete.Command { Id = id });
                return Ok();
            }
            catch (NullReferenceException)
            {
                return BadRequest();
            }
        }



    }
}
