using HotelProject.Core.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace HotelProject.API.Filters
{
    public class ValidateFilterAttribute : ActionFilterAttribute
    {
        public override void OnResultExecuting(ResultExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                var errors = context
                    .ModelState
                    .Values
                    .SelectMany(x => x.Errors)
                    .Select(x => x.ErrorMessage)
                    .ToList();

                context.Result = new BadRequestObjectResult(
                    CustomResponseDTO<EmptyResult>.Fail(400, errors)
                );
            }
        }
    }
}
