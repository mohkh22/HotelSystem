using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace HotelSystem.Application.Filters
{
    public class ValidateModelAttributer : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var paramaters = context.ActionArguments; 
            foreach (var param in paramaters)
            {
                if(param.Value == null)
                    context.Result =  new BadRequestObjectResult("Invalid Model");
                return;

            }

            if(!context.ModelState.IsValid)
            {
                context.Result = new BadRequestObjectResult(context.ModelState);
                return;
            }

            base.OnActionExecuting(context);

        }
    }
}
