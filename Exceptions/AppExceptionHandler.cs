using AuthorWebApiProject.Models;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using System.Text.Json;

namespace AuthorWebApiProject.Exceptions
{
    public class AppExceptionHandler : IExceptionHandler
    {
        public async ValueTask<bool> TryHandleAsync(HttpContext context, Exception exception, CancellationToken cancellationToken)
        {
            var response = new ErrorResponse();
            if(exception is AuthorNotFoundException)
            {
                response.StatusCode = StatusCodes.Status404NotFound;
                response.Title = "Author Not Found";
                response.ExceptionMessage = "Wrong input";
            }
            else
            {
                response.StatusCode = StatusCodes.Status500InternalServerError;
                response.Title = "Internal Server Error";
                response.ExceptionMessage = "An unexpected error occurred.";
            }
            
            

            await context.Response.WriteAsJsonAsync(response, cancellationToken);

            return true;
        }
    }
}
