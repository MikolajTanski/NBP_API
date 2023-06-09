﻿using NBPAPI.Middelware.Exception;

namespace NBPAPI.Middelware
{
    public class ErrorHandling : IMiddleware
    {
        private readonly ILogger<ErrorHandling> _logger;
        public ErrorHandling(ILogger<ErrorHandling> logger)
        {
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next.Invoke(context);
            }
            catch (BadRequestException badRequestException)
            {
                context.Response.StatusCode = 400;
                await context.Response.WriteAsJsonAsync(badRequestException.Message);
            }
            catch (NotFoundException notFoundException)
            {
                context.Response.StatusCode = 404;
                await context.Response.WriteAsJsonAsync(notFoundException.Message);
            }
            catch (SystemException e)
            {
                _logger.LogError(e, e.Message);

                context.Response.StatusCode = 500;
                await context.Response.WriteAsJsonAsync("Something went wrong");
            }
        }
    }
}
