using HotelSystem.Application.Response;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelSystem.Application.Exceptions
{
    public class GlobalExceptionMiddleware(RequestDelegate _next)
    {
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleException(context, ex);
            }
        }

        public static Task HandleException (HttpContext context, Exception ex)
        {
            context.Response.ContentType = "application/json";

            switch(ex)
            {
                case BadRequestException badRequestException:
                    context.Response.StatusCode = StatusCodes.Status400BadRequest;
                    return context.Response.WriteAsJsonAsync(new AppError (badRequestException.Message, StatusCodes.Status400BadRequest));
                case NotFoundException notFoundException:
                    context.Response.StatusCode = StatusCodes.Status404NotFound;
                    return context.Response.WriteAsJsonAsync(new AppError(notFoundException.Message, StatusCodes.Status404NotFound));
                case ConflictException conflict:
                    context.Response.StatusCode = StatusCodes.Status409Conflict;
                    return context.Response.WriteAsJsonAsync(new AppError(conflict.Message, StatusCodes.Status409Conflict));
                case UnauthorizedAccessException unauthorized:
                    context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                    return context.Response.WriteAsJsonAsync(new AppError(unauthorized.Message, StatusCodes.Status401Unauthorized));
                default:
                    context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                    return context.Response.WriteAsJsonAsync(new AppError(ex.Message, StatusCodes.Status500InternalServerError));

            }

        }
    }


}
