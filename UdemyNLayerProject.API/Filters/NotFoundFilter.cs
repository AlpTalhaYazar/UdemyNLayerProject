using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using UdemyNLayerProject.API.DTOs;
using UdemyNLayerProject.Core.Services;

namespace UdemyNLayerProject.API.Filters
{
    public class NotFoundFilter<TEntity> : IAsyncActionFilter where TEntity : class
    {
        private readonly IService<TEntity> _Service;

        public NotFoundFilter(IService<TEntity> Service)
        {
            this._Service = Service;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {

            int id = (int)context.ActionArguments.Values.FirstOrDefault();

            var product = await this._Service.GetByIdAsync(id);

            if (product != null)
            {
                await next();
            }
            else
            {
                ErrorDto errorDto = new ErrorDto();

                errorDto.Status = 404;

                errorDto.Errors.Add($"The {typeof(TEntity).Name} with id {id} could not be found in the database.");

                context.Result = new NotFoundObjectResult(errorDto);
            }
        }
    }
}
