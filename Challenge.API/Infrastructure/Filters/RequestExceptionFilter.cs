using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Net;
using System;
using Microsoft.Extensions.Hosting;
using Challenge.Application.Base;
using FluentValidation;
using System.Linq;

namespace Challenge.API.Infrastructure.Filters
{
    public class RequestExceptionFilter : IExceptionFilter
    {
        [Obsolete]
        private readonly IHostingEnvironment environment;
        private readonly ILogger<RequestExceptionFilter> logger;

        [Obsolete]
        public RequestExceptionFilter(IHostingEnvironment environment, ILogger<RequestExceptionFilter> logger)
        {
            this.environment = environment ?? throw new ArgumentNullException(nameof(environment));
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public void OnException(ExceptionContext context)
        {
            logger.LogError(new EventId(context.Exception.HResult),
                context.Exception,
                context.Exception.Message);
            if (context.Exception.GetType() == typeof(CommonBaseException))
            {
                JsonErrorResponse json = null;
                var innerException = context.Exception.InnerException;

                if (innerException == null)
                {
                    json = new JsonErrorResponse
                    {
                        Messages = new string[] { context.Exception.Message },
                        MessageType = "02",
                        DeveloperMessage = context.Exception.Message
                    };

                    context.Result = new BadRequestObjectResult(json);
                    context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                }
                else
                {
                    string[] errors = null;

                    try
                    {
                        errors = ((ValidationException)innerException).Errors.Select(x => x.ErrorMessage).ToArray();
                    }
                    catch (Exception)
                    {
                    }

                    if (errors != null)
                    {
                        json = new JsonErrorResponse
                        {
                            Messages = errors,
                            MessageType = "01",
                            DeveloperMessage = context.Exception.Message
                        };

                        context.Result = new BadRequestObjectResult(json);
                        context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    }
                    else
                    {
                        json = new JsonErrorResponse
                        {
                            Messages = new string[] { context.Exception.Message },
                            MessageType = "03",
                            DeveloperMessage = innerException.Message
                        };

                        context.Result = new BadRequestObjectResult(json);
                        context.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    }
                }
            }
            else
            {
                var json = new JsonErrorResponse
                {
                    Messages = new[] { "Hubo un problema al procesar la solicitud, intente nuevamente por favor." },
                    MessageType = "04",
                    DeveloperMessage = context.Exception.Message,
                    StackTrace = context.Exception.StackTrace
                };

                context.Result = new InternalServerErrorObjectResult(json);
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            }
            context.ExceptionHandled = true;
        }
    }

    public class InternalServerErrorObjectResult : ObjectResult
    {
        public InternalServerErrorObjectResult(object error)
            : base(error)
        {
            StatusCode = StatusCodes.Status500InternalServerError;
        }
    }
}
