using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using System;
using System.Text.Json;

namespace JWTASPNetCore.Middware
{
    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception error)
            {
                var response = context.Response;
                response.ContentType = "application/json";
                var responseObject = new
                {
                    DevMsg = error.Message,
                    UserMsg = "Có lỗi xảy ra vui lòng liên hệ MISA để được trợ giúp",
                    errors = error.Data
                };
                switch (error)
                {
                    case WebException e:
                        response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        break;
                    case KeyNotFoundException e:
                        // not found error
                        response.StatusCode = (int)HttpStatusCode.NotFound;
                        break;
                    default:
                        // unhandled error
                        response.StatusCode = (int)HttpStatusCode.InternalServerError;
#if DEBUG
                        Console.WriteLine(error.Message);
#endif
                        break;
                }
                var result = JsonSerializer.Serialize(responseObject);
                await response.WriteAsync(result);
            }
        }
    }
}
