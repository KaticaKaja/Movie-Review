using FluentValidation;
using Microsoft.AspNetCore.Http;
using MovieReview.Application.Exceptions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieReview.Api.Core
{
    public class GlobalExceptionHandler
    {
        private readonly RequestDelegate _next;

        public GlobalExceptionHandler(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                //presreli smo izuzetak i podesavamo sve sto je vec podeseno kad se desi izuzetak
                httpContext.Response.ContentType = "application/json";
                object response = new
                {
                    message = "Internal error, go to the logs to find out what the hell happened."
                };
                var statusCode = StatusCodes.Status500InternalServerError;

                switch (ex)
                {
                    case UnatuhorizedUseCaseException _:
                        statusCode = StatusCodes.Status403Forbidden;
                        response = new
                        {
                            message = "You are not allowed to execute this operation."
                        };
                        break;
                    case EntityNotFoundException _:
                        statusCode = StatusCodes.Status404NotFound;
                        response = new
                        {
                            message = "Resource not found."
                        };
                        break;
                    case ValidationException validationException:
                        statusCode = StatusCodes.Status422UnprocessableEntity;
                        response = new
                        {
                            message = "Failed due to validation errors.",
                            errors = validationException.Errors.Select(x => new
                            {
                                x.PropertyName,
                                x.ErrorMessage
                            })
                        };
                        break;

                        //bilo bi dobro da u default case-u ostane 500 kao default ali da ulogujemo da bi videli sta to nismo predvideli kao problem/exception
                }

                httpContext.Response.StatusCode = statusCode;

                if (response != null)
                {
                    await httpContext.Response.WriteAsync(JsonConvert.SerializeObject(response));
                    return;
                }

                await Task.FromResult(httpContext.Response);
            }
        }
    }
}
